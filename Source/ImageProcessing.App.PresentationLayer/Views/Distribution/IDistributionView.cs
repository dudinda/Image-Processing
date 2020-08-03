using System;

using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.QualityMeasure;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Distribution
{
    public interface IDistributionView : IView,
        IQualityMeasure, IDisposable, IError
    {

    }
}
