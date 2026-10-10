using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.FileDialog;
using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Domain.Win.Code.Extensions;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Container;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class MainPresenter : BasePresenter<IMainView>,
        ISubscriber<AttachBlockToRendererEventArgs>, ISubscriber<OpenFileDialogEventArgs>,
        ISubscriber<SaveAsFileDialogEventArgs>, ISubscriber<SetSourceEventArgs>,
        ISubscriber<SaveWithoutFileDialogEventArgs>, ISubscriber<ShowTooltipOnErrorEventArgs>,
        ISubscriber<UndoRedoEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<FormIsLoadedEventArgs>
    {
        private readonly ILogger<MainPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IRenderPipeline _pipeline;
        private readonly INonBlockDialogService _dialog;

        public MainPresenter(
            IBitmapCopyService reference,
            INonBlockDialogService dialog,
            IRenderPipeline pipeline,
            ILogger<MainPresenter> logger)
        {
            _logger = logger;
            _dialog = dialog;
            _reference = reference;
            _pipeline = pipeline;
            _pipeline.BeginRender();
        }

        public override void Run()
        {
            Controller.Run<MainMenuPresenter>();
            Controller.Run<MainTrackbarPresenter>();
            base.Run();
        }

        /// <inheritdoc cref="OpenFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, OpenFileDialogEventArgs e)
        {
            try
            {
                  var result = await _dialog.OpenFileDialog().ConfigureAwait(true);

                if (result.Image != null)
                {
                    View.LoadedImage = result.Image;
                    View.SetCursor(CursorType.Wait);
                    _pipeline.Register(
                        new PipelineBlock(result.Image)
                            .Add<Bitmap>(
                                (bmp) => View.SetPathToFile(result.Path))
                            .Add<Bitmap>(
                                (bmp) => RenderBlock(publisher, bmp)));

                    View.SetMenuState(MenuBtnState.ImageLoaded);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.OpenFile);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="SaveAsFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, SaveAsFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    await _dialog.SaveFileAsDialog(copy).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="SaveWithoutFileDialogEventArgs"/>
        public async Task OnEventHandler(object publisher, SaveWithoutFileDialogEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    await Task.Run(() => copy.SaveByPath(View.GetPathToFile())).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                OnError(publisher, Errors.SaveFile);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="AttachBlockToRendererEventArgs"/>
        public async Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault && e.Block is IPipelineBlock block)
                {
                    View.SetCursor(CursorType.Wait);
                    _pipeline.Register(block
                            .Add<Bitmap>(
                                (bmp) => RenderBlock(publisher, bmp)));
                }
            }
            catch (OperationCanceledException ex)
            {
                OnError(publisher, Errors.CancelOperation);
                _logger.LogInformation(ex.Message);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Pipeline);
                _logger.LogError(ex.Message);
            }
        }


        /// <inheritdoc cref="UndoRedoEventArgs"/>
        public async Task OnEventHandler(object publisher, UndoRedoEventArgs e)
        {
            try
            {
                var copy = View.TryUndoRedo(e.Action);
                var action = e.Action == UndoRedoAction.Redo ?
                   UndoRedoAction.Undo : UndoRedoAction.Redo;

                Enum.TryParse<MenuBtnState>(copy.Tag?.ToString(), out var state);

                View.SetCursor(CursorType.Wait);
                _pipeline.Register(
                        new PipelineBlock(copy)
                            .Add<Bitmap>(
                                (bmp) => RenderBlock(publisher, bmp)));

                if(state != MenuBtnState.ImageEmpty)
                {
                    state = MenuBtnState.ImageLoaded;
                }

                View.SetMenuState(state);
                Aggregator.PublishFromAll(publisher, new ContainerUpdatedEventArgs(copy));
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.UndoRedo);
                _logger.LogError(ex.Message);
            }
        }

        /// <inheritdoc cref="ShowTooltipOnErrorEventArgs"/>
        public Task OnEventHandler(object publisher, ShowTooltipOnErrorEventArgs e)
        {
            try
            {
                View.Tooltip(e.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            
            return Task.CompletedTask;
        }

        public async Task OnEventHandler(object publisher, SetSourceEventArgs e)
        {
            try
            {
                View.SetCursor(CursorType.Wait);
                _pipeline.Register(
                    new PipelineBlock(new Bitmap(View.LoadedImage))
                        .Add<Bitmap>(
                            (bmp) => RenderBlock(publisher, bmp)));
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.UndoRedo);
                _logger.LogError(ex.Message);
            }
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            try
            {
                Controller.Dispose();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, FormIsLoadedEventArgs e)
        {
            try
            {
                _pipeline.BeginRender();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        private async Task RenderBlock(object publisher, Bitmap bmp, UndoRedoAction action = UndoRedoAction.Undo)
        {
            await _reference.SetCopy(bmp);

            View.AddToUndoRedo((Bitmap)View.GetImageCopy(), action);
            View.SetImageCopy(bmp);
            View.SetImage(bmp);
            View.SetImageCenter(bmp.Size);
            View.Refresh();
            View.ResetTrackBarValue();

            if (Enum.TryParse<MenuBtnState>(bmp.Tag?.ToString(), out var tag))
            {
                View.GetImageCopy().Tag = tag;
            }

            if(!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }

            Aggregator.PublishFromAll(publisher, new EnableControlEventArgs(tag));
            Aggregator.PublishFromAll(publisher, new ContainerUpdatedEventArgs(bmp));
            Aggregator.PublishFrom(publisher, new RestoreFocusEventArgs());
        }

        private void OnError(object publisher, string error)
        {
            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
            else
            {
                View.SetCursor(CursorType.Wait);
            }

            Aggregator.PublishFrom(publisher, new ShowTooltipOnErrorEventArgs(error));
        }
    }
}
