using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents the base behavior of a scaling control panel.
    /// </summary>
    public interface IScalingView : IView, IFormState,
        IDropdown<ScalingMethod>, ITooltip
    {
        (string, string) Parameters { get; }
    }
}
