
using ImageProcessing.App.Common.Enums;
using ImageProcessing.Framework.Core.MVP.View;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.DataChart;

namespace ImageProcessing.App.PresentationLayer.Views.Histogram
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
