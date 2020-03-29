using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.DataChart
{
    /// <summary>
    /// Represents a view component with a <see cref="Chart"/>.
    /// </summary>
    public interface IDataChart
    {
        /// <summary>
        /// Get a chart.
        /// </summary>
        Chart GetChart { get; }
    }
}
