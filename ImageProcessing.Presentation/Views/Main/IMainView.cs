using ImageProcessing.Presentation.Views.Base;
using System.Drawing;
using System;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {

        Bitmap SrcImage { get; set; }
        Bitmap DstImage { get; set; }

        event Action ApplyConvolutionFilter;
        event Action ApplyRGBFilter;
        event Action ApplyHistogramTransformation;
    }
}
