using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Core.View;
using ImageProcessing.PresentationLayer.Views.ViewComponent.DataChart;

namespace ImageProcessing.PresentationLayer.Views.QualityMeasure
{
    /// <summary>
    /// Represents the base behavior of
    /// a quality measure window.
    /// </summary>
    public interface IQualityMeasureView : IView,
        IDataChart
    {

    }
}
