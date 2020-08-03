using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Rgb
{
    public interface IRgbView : IView,
        IDisposable, IDropdown<RgbFilter>, ITooltip
        
    {
        /// <summary>
        /// Get a color combination from the
        /// rgb colors menu.
        /// </summary>
        RgbColors GetSelectedColors(RgbColors color);
    }
}
