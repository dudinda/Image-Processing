using System;

using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents the base behavior of
    /// a quality measure window.
    /// </summary>
    public interface IQualityMeasureView : IView,
        IDataChart, IDisposable
    {
       
    }
}
