using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Core.View;

namespace ImageProcessing.Presentation.Views.Main
{
    public interface IMainView : IView
    {
        event Action SaveImage;
        event Action SaveImageAs;
        event Action OpenImage;
        event Action Shuffle;
        event Action UndoLast;
        event Action BuildLuminanceIntervals;
        event Action<string> ApplyConvolutionFilter;
        event Action<string, (string, string)> ApplyHistogramTransformation;
        event Action<string> ApplyRGBFilter;
        event Action<string> ApplyRGBColorFilter;
        event Action<string> ReplaceImage;
        event Action<string> BuildPmf;
        event Action<string> BuildCdf;
        event Action<string> Zoom;
        event Action<Keys> GetRandomVariableInfo;
        
        (string, string) Parameters { get; }
        bool SrcIsNull { get; }
        bool DstIsNull { get; }
        Size SourceFactorZoom { get; }
        Size DestinationFactorZoom { get; }

        string PathToFile { get; set; }
        Image SrcImage { get; set; }
        Image DstImage { get; set; }
        Image SrcImageCopy { get; set; }
        Image DstImageCopy { get; set; }
        bool IsGreenChannelChecked { get; set; }
        bool IsRedChannelChecked { get; set; }
        bool IsBlueChannelChecked { get; set; }
        Size SourceSize { get; set; }
        Size DestinationSize { get; set; }
    
        void ShowError(string message);

    }
}
