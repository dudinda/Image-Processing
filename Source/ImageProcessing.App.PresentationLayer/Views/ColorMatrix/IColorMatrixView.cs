using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.ColorMatrix
{
    public interface IColorMatrixView : IView,
        IDropdown<ClrMatrix>
    {
        void SetEnabledCells(bool isEnabled);
        void SetEnabledDropDown(bool isEnabled);
        void SetVisibleApply(bool isVisible);
        void SetVisibleApplyCustom(bool isVisible);
    }
}
