using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Pipeline;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Domain.Win.Services.Draw;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Toolbar;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class MainPresenter : BasePresenter<IMainView>,
        ISubscriber<AttachBlockToRendererEventArgs>, ISubscriber<AttachBlockToPaintEventArgs>,
        ISubscriber<ShowTooltipOnErrorEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<FormIsLoadedEventArgs>, ISubscriber<MouseDownEventArgs>,
        ISubscriber<MouseMoveEventArgs>, ISubscriber<MouseUpEventArgs>
    {
        private readonly ILogger<MainPresenter> _logger;
        private readonly IBitmapCopyService _reference;
        private readonly IRenderPipeline _pipeline;
        private readonly IDrawService _draw;

        public MainPresenter(
            IBitmapCopyService reference,
            IDrawService draw,
            IRenderPipeline pipeline,
            ILogger<MainPresenter> logger)
        {
            _logger = logger;
            _draw = draw;
            _reference = reference;
            _pipeline = pipeline;
        }

        public override void Run()
        {
            Controller.Run<MainMenuPresenter>();
            Controller.Run<MainTrackbarPresenter>();
            Controller.Run<MainToolbarPresenter>();
            base.Run();
        }

        /// <inheritdoc cref="AttachBlockToRendererEventArgs"/>
        public Task OnEventHandler(object publisher, AttachBlockToRendererEventArgs e)
        {
            try
            {
                if (e.Block is IPipelineBlock block)
                {
                    View.SetCursor(CursorType.Wait);
                    _pipeline.Register(block
                        .Add<Bitmap>(
                            (bmp) => RenderBlock(publisher, bmp, e.Action)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Pipeline);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, AttachBlockToPaintEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault && e.Block is IPipelineBlock block)
                {
                    View.SetCursor(CursorType.Wait);
                    _pipeline.Register(block
                            .Add<Bitmap>(
                                (bmp) => PaintBlock(bmp)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Pipeline);
                _logger.LogError(ex.Message);
            }

            return Task.CompletedTask;
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

        public async Task OnEventHandler(object publisher, MouseDownEventArgs e)
        {
            try
            {
                _draw.Capture(e.Start);
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Zoom);
                _logger.LogError(ex.Message);
            }
        }

        public async Task OnEventHandler(object publisher, MouseMoveEventArgs e)
        {
            try
            {
                if (View.IsCaptureRegion && View.IsLeftPressed())
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    var block = new PipelineBlock(copy);
                    _pipeline.Register(block
                        .Add<Bitmap, Bitmap>(
                            (bmp) => _draw.DrawRectangle(bmp, e.Position))
                        .Add<Bitmap>(
                            (bmp) => PaintBlock(bmp)));
                }
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Zoom);
                _logger.LogError(ex.Message);
            }
        }

        public async Task OnEventHandler(object publisher, MouseUpEventArgs e)
        {
            try
            {
                if(View.IsCaptureRegion)
                {
                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    var area = _draw.GetRectangle(e.Position);
                    _pipeline.Register(
                        new PipelineBlock(copy)
                            .Add<Bitmap>(
                                (bmp) => PaintBlock(bmp)
                             )
                         );
                    Aggregator.PublishFromAll(publisher, new AreaSelectedEventArgs(area));
                } 
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Zoom);
                _logger.LogError(ex.Message);
            }
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

        private void PaintBlock(Bitmap bmp)
        {
            View.SetImage(bmp);
            View.SetImageCenter(bmp.Size);
            View.Refresh();
            if (!_pipeline.Any())
            {
                View.SetCursor(CursorType.Default);
            }
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
