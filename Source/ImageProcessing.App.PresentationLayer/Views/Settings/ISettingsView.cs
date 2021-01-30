using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Settings
{
    public interface ISettingsView : IView, IDisposable,
        IDropdown<RotationMethod, ScalingMethod, Luma>
    {

    }
}
