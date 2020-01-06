using ImageProcessing.Presentation.Views.Base;
using System.Drawing;
using System;
using ImageProcessing.RGBFilters.ColorFilter.Colors;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {
        double FirstParameter { get; }
        double SecondParameter { get; }

        string Path { get; set; }
        Bitmap SrcImage { get; set; }
        Bitmap DstImage { get; set; }

        bool SrcIsNull { get; }
        bool DstIsNull { get; }

        void InitSrcImageZoom();
        void InitDstImageZoom();

        (double, double) Parameters { get; }

        event Action SaveImage;
        event Action OpenImage;
        event Action<string> ApplyConvolutionFilter;
        event Action<string> ApplyRGBFilter;
        event Action<RGBColor> ApplyRGBColorFilter;
        event Action<string, (double, double)> ApplyHistogramTransformation;
        event Action Shuffle;
        event Action BuildPmf;
        event Action BuildCdf;
        event Action BuildLuminanceIntervals;
    }
}
