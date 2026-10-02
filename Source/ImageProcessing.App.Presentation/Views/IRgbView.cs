using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
{
    public interface IRgbView : IView, IFormState,
        IDisposable, IDropdown<RgbFltr>, ITooltip
        
    {
        /// <summary>
        /// Get a color combination from the
        /// rgb colors menu.
        /// </summary>
        RgbChannels GetSelectedChannels();
    }
}
