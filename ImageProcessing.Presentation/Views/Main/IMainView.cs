
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
        event Action SaveImageAs;
        event Action OpenImage;
        event Action Shuffle;
        event Action UndoLast;
        event Action BuildPmf;
        event Action BuildCdf;
        event Action BuildLuminanceIntervals;
        event Action<string> ApplyConvolutionFilter;
        event Action<string, (string, string)> ApplyHistogramTransformation;
        event Action<string> ApplyRGBFilter;
        event Action<string> ApplyRGBColorFilter;
        event Action<Keys> GetRandomVariableInfo;


        (string, string) Parameters { get; }
        bool SrcIsNull { get; }
        bool DstIsNull { get; }

        string Path { get; set; }
        Bitmap SrcImage { get; set; }
        Bitmap DstImage { get; set; }
        bool IsGreenChannelChecked { get; set; }
        bool IsRedChannelChecked { get; set; }
        bool IsBlueChannelChecked { get; set; }

        void ShowError(string message);
        void InitSrcImageZoom();
        void InitDstImageZoom();

    }
}
