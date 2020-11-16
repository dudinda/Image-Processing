using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.Microkernel.MVP.View;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.PresentationLayer.Views.ColorMatrix
{
    public interface IColorMatrixView : IView,
        IDropdown<ClrMatrix>, ITooltip
    {
        void ResetGrid();
        void SetGrid(ReadOnly2DArray<double> matrix);
        ReadOnly2DArray<double> GetGrid();
        void SetEnabledCells(bool isEnabled);
        void SetEnabledDropDown(bool isEnabled);
        void SetVisibleApply(bool isVisible);
        void SetVisibleApplyCustom(bool isVisible);
    }
}
