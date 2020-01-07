using ImageProcessing.Presentation.Views.Base;
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.Presentation.Views.QualityMeasure
{
    public interface IQualityMeasureView : IView
    {
        event Action<Bitmap> BuildHistogram;

        Chart GetChart { get; }
    }
}
