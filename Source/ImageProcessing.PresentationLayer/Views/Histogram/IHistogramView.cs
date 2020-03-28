using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;
using ImageProcessing.PresentationLayer.Views.ViewComponent.DataChart;

namespace ImageProcessing.PresentationLayer.Views.Histogram
{
    public interface IHistogramView : IView,
        IDataChart
    {
        double YAxisMaximum { get; set; }

        void Init(RandomVariable action);
    }
}
