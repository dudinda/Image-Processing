using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Core.View;

namespace ImageProcessing.Presentation.Views.QualityMeasure
{
    public interface IQualityMeasureView : IView
    {
        Chart GetChart { get; }
    }
}
