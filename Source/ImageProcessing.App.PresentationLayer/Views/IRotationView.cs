using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    public interface IRotationView : IView, IFormState,
        IDisposable, IDropdown<RotationMethod>, ITooltip
    {
        double Radians { get; }
    }
}
