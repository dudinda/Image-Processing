using System.Windows.Forms.DataVisualization.Charting;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.View;
using ImageProcessing.PresentationLayer.Views.ViewComponent.DataChart;

namespace ImageProcessing.PresentationLayer.Views.Histogram
{
    /// <summary>
    /// Represents the base behavior of
    /// a histogram data chart window.
    /// </summary>
    public interface IHistogramView : IView,
        IDataChart
    {
        /// <summary>
        /// Set a maximum value on the y axis.
        /// </summary>
        double YAxisMaximum { get; set; }

        /// <summary>
        /// Initialize a random variable function. 
        /// </summary>
        /// <param name="action"></param>
        void Init(RandomVariable action);
    }
}
