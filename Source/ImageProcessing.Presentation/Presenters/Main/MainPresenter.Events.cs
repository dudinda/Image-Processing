using System;
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.EventAggregator.Interface.Subscriber;
using ImageProcessing.DomainModel.EventArgs;

namespace ImageProcessing.Presentation.Presenters.Main
{
    partial class MainPresenter : ISubscriber<ConvolutionFilterEventArgs>,
                                  ISubscriber<RGBFilterEventArgs>, 
                                  ISubscriber<RGBColorFilterEventArgs>,
                                  ISubscriber<DistributionEventArgs>,
                                  ISubscriber<ImageContainerEventArgs>,
                                  ISubscriber<FileDialogEventArgs>,
                                  ISubscriber<ToolbarActionEventArgs>,
                                  ISubscriber<RandomVariableEventArgs>
    {
        public void OnEventHandler(ConvolutionFilterEventArgs e)
        {
            ApplyConvolutionFilter(e.Arg);
        }

        public void OnEventHandler(RGBFilterEventArgs e)
        {
            ApplyRGBFilter(e.Arg);
        }

        public void OnEventHandler(RGBColorFilterEventArgs e)
        {
            ApplyColorFilter(e.Arg);
        }

        public void OnEventHandler(DistributionEventArgs e)
        {
            ApplyHistogramTransformation(e.Arg, e.Parameters);
        }

        public void OnEventHandler(ImageContainerEventArgs e)
        {
            Replace(e.Arg);
        }

        public void OnEventHandler(FileDialogEventArgs e)
        {
            switch(e.Arg)
            {
                case FileDialogAction.Open:
                    OpenImage();
                    break;
                case FileDialogAction.Save:
                    SaveImage();
                    break;
                case FileDialogAction.SaveAs:
                    SaveImageAs();
                    break;

                default: throw new NotImplementedException(nameof(e.Arg));
            }
        }

        public void OnEventHandler(ToolbarActionEventArgs e)
        {
            switch(e.Arg)
            {
                case ToolbarAction.Shuffle:
                    Shuffle();
                    break;
                case ToolbarAction.Undo:
                    break;
                case ToolbarAction.Redo:
                    break;
                    
                default: throw new NotImplementedException(nameof(e.Arg));
            }
        }

        public void OnEventHandler(RandomVariableEventArgs e)
        {
            switch(e.Action)
            {
                case RandomVariable.CDF:
                case RandomVariable.PMF:
                    BuildFunction(e.Arg, e.Action);
                    break;

                case RandomVariable.Expectation:
                case RandomVariable.Entropy:
                case RandomVariable.StandardDeviation:
                case RandomVariable.Variance:
                    GetRandomVariableInfo(e.Arg, e.Action);
                    break;

                default: throw new NotImplementedException(nameof(e.Action));
            }
        }
    }
}
