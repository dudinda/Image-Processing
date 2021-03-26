using System;

using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
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
    }
}
