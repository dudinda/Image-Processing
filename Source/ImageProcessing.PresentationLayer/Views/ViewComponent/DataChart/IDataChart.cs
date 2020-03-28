using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.PresentationLayer.Views.ViewComponent.DataChart
{
    public interface IDataChart
    {
        Chart GetChart { get; }
    }
}
