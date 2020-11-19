using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.TransformationArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModel.Transformation;
using ImageProcessing.App.PresentationLayer.Views.Transformation;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.Transformation
{
    internal sealed class TransformationPresenter : BasePresenter<ITransformationView, TransformationViewModel>,
        ISubscriber<ApplyTransformationEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>
    {
        private readonly ITransformationProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public TransformationPresenter(
            IAppController controller,
            ITransformationProvider provider,
            IAsyncOperationLocker locker) : base(controller)
        {
            _provider = provider;
            _locker = locker;
        }

        public async Task OnEventHandler(object publisher, ApplyTransformationEventArgs e)
        {
            try
            {
                var (xStr, yStr) = e.Parameters;

                var x = Convert.ToDouble(xStr);
                var y = Convert.ToDouble(yStr);

                var copy = await _locker.LockOperationAsync(
                    () => new Bitmap(ViewModel.Source)
                ).ConfigureAwait(true);

                var transformation = View.Dropdown;

                Controller.Aggregator.PublishFromAll(
                    e.Publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Apply(bmp, x, y, transformation))
                    )
                 );
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.ApplyTransformation);
            }
        }

        public async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                if (e.Container == ImageContainer.Source)
                {
                    await _locker.LockOperationAsync(() =>
                        ViewModel.Source = new Bitmap(e.Bmp)
                    ).ConfigureAwait(true);
                }
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
            }
        }

        public async Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            View.Focus();
        }
    }
}
