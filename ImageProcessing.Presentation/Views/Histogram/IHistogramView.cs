using ImageProcessing.Presentation.Views.Base;

using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.Presentation.Views.Histogram
{
    public interface IHistogramView : IView
    {
        Chart GetChart { get; }
    }
}
