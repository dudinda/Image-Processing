using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents a window where a user can select
    /// settings for algorithms of the domain.
    /// </summary>
    public interface ISettingsView : IView, IDisposable,
        IDropdown<RotationMethod, ScalingMethod, Luma>
    {

    }
}
