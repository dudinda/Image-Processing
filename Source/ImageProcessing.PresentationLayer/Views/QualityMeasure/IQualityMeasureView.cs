using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Core.View;

namespace ImageProcessing.PresentationLayer.Views.QualityMeasure
{
    public interface IQualityMeasureView : IView
    {
        Chart GetChart { get; }
    }
}
