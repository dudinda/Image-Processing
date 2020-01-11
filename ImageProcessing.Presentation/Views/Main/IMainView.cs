﻿using System.Drawing;
using System.Windows.Forms;
using System;

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
        event Action<Keys> BuildPmf;
        event Action<Keys> BuildCdf;
        event Action<Keys> GetRandomVariableInfo;


        (string, string) Parameters { get; }
        bool SrcIsNull { get; }
        bool DstIsNull { get; }

        string Path { get; set; }
        Image SrcImage { get; set; }
        Image DstImage { get; set; }
        bool IsGreenChannelChecked { get; set; }
        bool IsRedChannelChecked { get; set; }
        bool IsBlueChannelChecked { get; set; }

        void ShowError(string message);
        void InitSrcImageZoom();
        void InitDstImageZoom();

    }
}
