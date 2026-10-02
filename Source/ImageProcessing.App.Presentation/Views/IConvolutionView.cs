using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
{
    /// <summary>
    /// Represents the base behavior of a
    /// convolution kernel control panel.
    /// </summary>
    public interface IConvolutionView : IView, IFormState,
        ITooltip, IDisposable, IDropdown<ConvKernel>
    {

    }
}
