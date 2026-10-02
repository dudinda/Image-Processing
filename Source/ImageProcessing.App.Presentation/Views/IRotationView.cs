using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
{
    public interface IRotationView : IView, IFormState,
        IDisposable, IDropdown<RotationMethod>, ITooltip
    {
        double Radians { get; }
    }
}
