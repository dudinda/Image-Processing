using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Providers.Rotation;
using ImageProcessing.App.Domain.Providers.Scaling;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Pipeline;
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
    public class MainTrackbarPresenter : BasePresenter<IMainView>, ISubscriber<TrackBarEventArgs>
    {
        public override IMainView View
          => field ??= Controller.IoC.Resolve<IMainView>();

        private readonly ILogger<MainTrackbarPresenter> _logger;
        private readonly IScalingProvider _scale;
        private readonly IRotationProvider _rotation;
        private readonly IBitmapCopyService _reference;
        private readonly IRenderPipeline _pipeline;


        public MainTrackbarPresenter(
            ILogger<MainTrackbarPresenter> logger,
            IRenderPipeline pipeline,
            IBitmapCopyService reference,
            IScalingProvider scale,
            IRotationProvider rotation)
        {
            _scale = scale;
            _rotation = rotation;
            _reference = reference;
            _logger = logger;
            _pipeline = pipeline;
        }

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        /// <inheritdoc cref="TrackBarEventArgs"/>
        public async Task OnEventHandler(object publisher, TrackBarEventArgs e)
        {
            var container = ImageContainer.Unknown;

            try
            {
                container = e.Container;

                if (!View.ImageIsDefault)
                {
                    var scale = View.GetZoomFactor();
                    var rad = View.GetRotationFactor();

                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    var block = new PipelineBlock(copy)
                        .Add<Bitmap, Bitmap>(
                            (bmp) => _scale.Scale(bmp, scale, scale))
                        .Add<Bitmap, Bitmap>(
                            (bmp) => _rotation.Rotate(bmp, rad))
                        .Add<Bitmap>(
                            (bmp) => PaintBlock(bmp));

                    _pipeline.Register(block);
                    await _pipeline.Render().ConfigureAwait(true);
                    
                }
            }
            catch (ArgumentException ex)
            {
                View.SetDefaultImage();
            }
            catch (Exception ex)
            {
                OnError(publisher, Errors.Zoom);
                _logger.LogError(ex.Message);
            }
        }

        private void PaintBlock(Bitmap bmp)
        {
            var size = bmp.Size;
            View.SetImage(bmp);
            View.SetImageCenter(size);
            View.Refresh();
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
