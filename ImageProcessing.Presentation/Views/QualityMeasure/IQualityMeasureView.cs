using ImageProcessing.Presentation.Views.Base;
using System;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.Presentation.Views.QualityMeasure
{
    public interface IQualityMeasureView : IView
    {
        Chart GetChart { get; }

        event Action<Bitmap> BuildHistogram;
    }
}
