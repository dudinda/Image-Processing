
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ConvolutionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.DistributionArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.MainArgs.Show;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.ToolbarArgs;
using ImageProcessing.App.DomainLayer.DomainEvents.QualityMeasureArgs;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.Presenters.Main
{
    internal sealed partial class MainPresenter
        : ISubscriber<RenderEventArgs>,
          ISubscriber<ShowConvolutionFilterPresenterEventArgs>,
          ISubscriber<ShowQualityMeasureEventArgs>,
          ISubscriber<DistributionEventArgs>,
          ISubscriber<ImageContainerEventArgs>,
          ISubscriber<RandomVariableInfoEventArgs>,
          ISubscriber<RandomVariableFunctionEventArgs>,
          ISubscriber<ZoomEventArgs>,
          ISubscriber<CloseFormEventArgs>,
          ISubscriber<OpenFileDialogEventArgs>,
          ISubscriber<SaveAsFileDialogEventArgs>,
          ISubscriber<SaveWithoutFileDialogEventArgs>,
          ISubscriber<ShowRgbFiltersEventArgs>,
          ISubscriber<ShuffleEventArgs>
    {
        public void OnEventHandler(RenderEventArgs e)
            => AttachToRenderer(e);

        public void OnEventHandler(ShowConvolutionFilterPresenterEventArgs e)
            => ShowConvolutionFiltersMenu(e);

        public void OnEventHandler(DistributionEventArgs e)
            => ApplyHistogramTransformation(e);

        public void OnEventHandler(ImageContainerEventArgs e)
            => Replace(e);

        public void OnEventHandler(ZoomEventArgs e)
            => Zoom(e);

        public void OnEventHandler(CloseFormEventArgs e)
            => CloseForm(e);

        public void OnEventHandler(RandomVariableInfoEventArgs e)
            => GetRandomVariableInfo(e);

        public void OnEventHandler(RandomVariableFunctionEventArgs e)
            => BuildFunction(e);

        public void OnEventHandler(SaveAsFileDialogEventArgs e)
            => SaveImageAs(e);
        
        public void OnEventHandler(OpenFileDialogEventArgs e)
            => OpenImage(e);

        public void OnEventHandler(SaveWithoutFileDialogEventArgs e)
            => SaveImage(e);

        public void OnEventHandler(ShuffleEventArgs e)
            => Shuffle(e);

        public void OnEventHandler(ShowQualityMeasureEventArgs e)
            => ShowQualityMeasureForm(e);

        public void OnEventHandler(ShowRgbFiltersEventArgs e)
            => ShowRgbFiltersMenu(e);
        
    }
}
