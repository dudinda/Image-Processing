using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;

namespace ImageProcessing.PresentationLayer.Views.Histogram
{
    public interface IHistogramView : IView
    {
        Chart GetChart { get; }
        double YAxisMaximum { get; set; }

        void Init(RandomVariable action);
    }
}
