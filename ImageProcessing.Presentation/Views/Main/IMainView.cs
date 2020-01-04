using ImageProcessing.Presentation.Views.Base;

using System;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {
        event Action ApplyConvolutionFilter;
        event Action ApplyRGBFilter;
        event Action ApplyHistogramTransformation;
    }
}
