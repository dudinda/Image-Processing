using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.Microkernel.MVP.View;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.PresentationLayer.Views
{
    public interface IColorMatrixView : IView,
        IDropdown<ClrMatrix>, ITooltip
    {
        /// <summary>
        /// Set a color matrix.
        /// </summary>
        /// <param name="matrix"></param>
        void SetGrid(ReadOnly2DArray<double> matrix);

        /// <summary>
        /// Get a color matrix as a <see cref="ReadOnly2DArray{T}"/>.
        /// </summary>
        ReadOnly2DArray<double> GetGrid();

        void SetEnabledCells(bool isEnabled);

        void SetEnabledDropDown(bool isEnabled);

        void SetVisibleApply(bool isVisible);

        void SetVisibleApplyCustom(bool isVisible);
    }
}
