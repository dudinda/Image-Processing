using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Providers.Rotation;
using ImageProcessing.App.Domain.Providers.Scaling;
using ImageProcessing.App.Domain.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Container;
using ImageProcessing.App.Presentation.Properties;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

using Microsoft.Extensions.Logging;

namespace ImageProcessing.App.Presentation.Presenters
{
    public class MainTrackbarPresenter : BasePresenter<IMainView>,
        ISubscriber<TrackBarEventArgs>
    {
        public override IMainView View
          => field ??= Controller.IoC.Resolve<IMainView>();

        private readonly ILogger<MainTrackbarPresenter> _logger;
        private readonly IScalingProvider _scale;
        private readonly IRotationProvider _rotation;
        private readonly IBitmapCopyService _reference;


        public MainTrackbarPresenter(
            ILogger<MainTrackbarPresenter> logger,
            IBitmapCopyService reference,
            IScalingProvider scale,
            IRotationProvider rotation)
        {
            _scale = scale;
            _rotation = rotation;
            _reference = reference;
            _logger = logger;
        }

        public override void Run()
        {
            Aggregator.Subscribe(this, View);
        }

        /// <inheritdoc cref="TrackBarEventArgs"/>
        public async Task OnEventHandler(object publisher, TrackBarEventArgs e)
        {
            try
            {
                if (!View.ImageIsDefault)
                {
                    var scale = View.GetZoomFactor();
                    var rad = View.GetRotationFactor();

                    var copy = await _reference.GetCopy().ConfigureAwait(true);
                    Aggregator.PublishFromAll(publisher,
                        new AttachBlockToPaintEventArgs(
                            block: new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _scale.Scale(bmp, scale, scale))
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _rotation.Rotate(bmp, rad))
                        )
                     );
                }
            }
            catch (ArgumentException ex)
            {
                View.SetDefaultImage();
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.Zoom);
                _logger.LogError(ex.Message);
            }
        }
    }
}
