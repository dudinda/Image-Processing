using System;
using System.Threading.Tasks;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs;
using ImageProcessing.Core.EventAggregator.Implementation.EventArgs.Convolution;
using ImageProcessing.Core.EventAggregator.Interface.Subscriber;

namespace ImageProcessing.Presentation.Presenters.Main
{
    partial class MainPresenter : ISubscriber<ApplyConvolutionFilterEventArgs>,
                                  ISubscriber<ShowConvolutionFilterPresenterEventArgs>,
                                  ISubscriber<RGBFilterEventArgs>,
                                  ISubscriber<RGBColorFilterEventArgs>,
                                  ISubscriber<DistributionEventArgs>,
                                  ISubscriber<ImageContainerEventArgs>,
                                  ISubscriber<FileDialogEventArgs>,
                                  ISubscriber<ToolbarActionEventArgs>,
                                  ISubscriber<RandomVariableEventArgs>,
                                  ISubscriber<ZoomEventArgs>,
                                  ISubscriber<CloseFormEventArgs>
    {
        public async Task OnEventHandler(ApplyConvolutionFilterEventArgs e)
            => await ApplyConvolutionFilter(e).ConfigureAwait(true);

        public async Task OnEventHandler(ShowConvolutionFilterPresenterEventArgs e)
            => await ShowConvolutionFiltersMenu(e).ConfigureAwait(true);

        public async Task OnEventHandler(RGBFilterEventArgs e)
            => await ApplyRGBFilter(e).ConfigureAwait(true);

        public async Task OnEventHandler(RGBColorFilterEventArgs e)
            => await ApplyColorFilter(e).ConfigureAwait(true);

        public async Task OnEventHandler(DistributionEventArgs e)
            => await ApplyHistogramTransformation(e).ConfigureAwait(true);

        public async Task OnEventHandler(ImageContainerEventArgs e)
            => await Replace(e).ConfigureAwait(true);

        public async Task OnEventHandler(ZoomEventArgs e)
            => await Zoom(e).ConfigureAwait(true);

        public async Task OnEventHandler(CloseFormEventArgs e)
            => CloseForm();

        public async Task OnEventHandler(FileDialogEventArgs e)
        {
            switch (e.Arg)
            {
                case FileDialogAction.Open:
                    await OpenImage().ConfigureAwait(true);
                    break;
                case FileDialogAction.SaveWithoutDialog:
                    await SaveImage().ConfigureAwait(true);
                    break;
                case FileDialogAction.SaveAs:
                    await SaveImageAs().ConfigureAwait(true);
                    break;

                default:
                    throw new NotImplementedException(nameof(e.Arg));
            }
        }

        public async Task OnEventHandler(ToolbarActionEventArgs e)
        {
            switch (e.Arg)
            {
                case ToolbarAction.Shuffle:
                    await Shuffle().ConfigureAwait(true);
                    break;
                case ToolbarAction.Undo:
                case ToolbarAction.Redo:
                    break;

                default:
                    throw new NotImplementedException(nameof(e.Arg));
            }
        }

        public async Task OnEventHandler(RandomVariableEventArgs e)
        {
            switch (e.Action)
            {
                case RandomVariable.CDF:
                case RandomVariable.PMF:
                    BuildFunction(e);
                    break;

                case RandomVariable.Expectation:
                case RandomVariable.Entropy:
                case RandomVariable.StandardDeviation:
                case RandomVariable.Variance:
                    await GetRandomVariableInfo(e);
                    break;

                default:
                    throw new NotImplementedException(nameof(e.Action));
            }
        }
    }
}
