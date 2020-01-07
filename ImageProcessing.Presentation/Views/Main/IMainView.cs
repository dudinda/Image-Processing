
using System.Drawing;
using System.Windows.Forms;
using System;

using ImageProcessing.RGBFilters.ColorFilter.Colors;
using ImageProcessing.Presentation.Views.Base;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {
        event Action SaveImage;
        event Action OpenImage;
        event Action<string> ApplyConvolutionFilter;
        event Action<string, (string, string)> ApplyHistogramTransformation;
        event Action<string> ApplyRGBFilter;
        event Action<RGBColor> ApplyRGBColorFilter;
        event Action Shuffle;
        event Action<Keys> GetRandomVariableInfo;
        event Action UndoLast;
        event Action BuildPmf;
        event Action BuildCdf;
        event Action BuildLuminanceIntervals;

        (string, string) Parameters { get; }
        string Path { get; set; }
        Bitmap SrcImage { get; set; }
        Bitmap DstImage { get; set; }
        bool SrcIsNull { get; }
        bool DstIsNull { get; }

        void InitSrcImageZoom();
        void InitDstImageZoom();

    }
}
