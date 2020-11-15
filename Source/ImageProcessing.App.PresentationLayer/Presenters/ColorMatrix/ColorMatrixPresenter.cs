using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.ColorMatrix;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Base;
using ImageProcessing.App.PresentationLayer.ViewModel.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.LockerService.Operation.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Controller.Interface;

namespace ImageProcessing.App.PresentationLayer.Presenters.ColorMatrix
{
    internal sealed class ColorMatrixPresenter : BasePresenter<IColorMatrixView, ColorMatrixViewModel>,
        ISubscriber<ApplyColorMatrixEventArgs>,
        ISubscriber<ContainerUpdatedEventArgs>
    {
        private readonly IRgbServiceProvider _provider;
        private readonly IAsyncOperationLocker _locker;

        public ColorMatrixPresenter(
            IAppController controller,
            IRgbServiceProvider provider,
            IAsyncOperationLocker locker) : base(controller)
        {
            _provider = provider;
            _locker = locker;
        }

        public async Task OnEventHandler(object publisher, ApplyColorMatrixEventArgs e)
        {
            try
            {
                var filter = View.Dropdown;

                if (filter != ClrMatrix.Unknown)
                {
                    var copy = await _locker.LockOperationAsync(
                        () => new Bitmap(ViewModel.Source)
                    ).ConfigureAwait(true);

                    Controller.Aggregator.PublishFromAll(
                        e.Publisher,
                        new AttachBlockToRendererEventArgs(
                            block: new PipelineBlock(copy)
                                .Add<Bitmap, Bitmap>(
                                    (bmp) => _provider.Apply(bmp, filter))
                        )
                     );
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public async Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            if (e.Container == ImageContainer.Source)
            {
                await _locker.LockOperationAsync(() =>
                    ViewModel.Source = new Bitmap(e.Bmp)
                ).ConfigureAwait(true);
            }
        }
    }
}
