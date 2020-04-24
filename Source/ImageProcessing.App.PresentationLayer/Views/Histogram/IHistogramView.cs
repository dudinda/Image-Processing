using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.DataChart;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Histogram
{
    /// <summary>
    /// Represents the base behavior of
    /// a histogram data chart window.
    /// </summary>
    public interface IHistogramView : IView,
        IDataChart, IDisposable
    {
        /// <summary>
        /// Set a maximum value on the y axis.
        /// </summary>
        double YAxisMaximum { get; set; }

        /// <summary>
        /// Initialize a random variable function. 
        /// </summary>
        void Init(RandomVariableFunction action);
    }
}
