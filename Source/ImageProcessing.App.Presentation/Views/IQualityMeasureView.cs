using System;

using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
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
