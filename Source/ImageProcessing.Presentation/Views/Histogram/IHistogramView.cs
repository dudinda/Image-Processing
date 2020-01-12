using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Core.View;

namespace ImageProcessing.Presentation.Views.Histogram
{
    public interface IHistogramView : IView
    {
        Chart GetChart { get; }
    }
}
