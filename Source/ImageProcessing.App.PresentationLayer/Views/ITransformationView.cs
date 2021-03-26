using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents a behavior of an affine transformation
    /// control panel.
    /// </summary>
    public interface ITransformationView : IView,
        IDropdown<AffTransform>, ITooltip
    {

    }
}
