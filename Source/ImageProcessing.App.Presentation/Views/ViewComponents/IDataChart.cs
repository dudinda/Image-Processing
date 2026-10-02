using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.App.Presentation.Views.ViewComponents
{
    /// <summary>
    /// Represents a view component with a <see cref="Chart"/>.
    /// </summary>
    public interface IDataChart
    {
        /// <summary>
        /// Get a chart.
        /// </summary>
        Chart DataChart { get; }
    }
}
