using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents the base behavior of a
    /// convolution kernel control panel.
    /// </summary>
    public interface IConvolutionView : IView,
        ITooltip, IDisposable, IDropdown<ConvKernel>
    {

    }
}
