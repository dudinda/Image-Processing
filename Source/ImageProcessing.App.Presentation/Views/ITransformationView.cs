using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
{
    /// <summary>
    /// Represents a behavior of an affine transformation
    /// control panel.
    /// </summary>
    public interface ITransformationView : IView,
        IDropdown<AffTransform>, ITooltip, IFormState
    {

    }
}
