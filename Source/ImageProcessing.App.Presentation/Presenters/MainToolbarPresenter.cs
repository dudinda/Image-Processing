using System;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Container;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal class MainToolbarPresenter : BasePresenter<IMainView>,
        ISubscriber<SetSourceEventArgs>, ISubscriber<UndoRedoEventArgs>
    {
        public override IMainView View
           => field ??= Controller.IoC.Resolve<IMainView>();

        private readonly ILogger<MainToolbarPresenter> _logger;

        public MainToolbarPresenter(
            ILogger<MainToolbarPresenter> logger)
        {
            _logger = logger;
        }

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        public async Task OnEventHandler(object publisher, SetSourceEventArgs e)
        {
            try
            {
                View.SetCursor(CursorType.Wait);
                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                       block: new PipelineBlock(View.LoadedImage)
                    )
                );
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UndoRedo);
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
                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                       block: new PipelineBlock(copy), action
                    )
                );

                if (state != MenuBtnState.ImageEmpty)
                {
                    state = MenuBtnState.ImageLoaded;
                }

                View.SetMenuState(state);
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UndoRedo);
                _logger.LogError(ex.Message);
            }
        }
    }
}
