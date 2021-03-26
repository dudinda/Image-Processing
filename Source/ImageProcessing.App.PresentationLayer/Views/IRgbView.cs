using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    public interface IRgbView : IView,
        IDisposable, IDropdown<RgbFltr>, ITooltip
        
    {
        /// <summary>
        /// Get a color combination from the
        /// rgb colors menu.
        /// </summary>
        RgbChannels GetSelectedChannels(RgbChannels color);
    }
}
