using System;

using ImageProcessing.App.PresentationLayer.Views.ViewComponent.DataChart;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.QualityMeasure
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
