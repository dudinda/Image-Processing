using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.PresentationLayer.Views
{
    /// <summary>
    /// Represents a control panel which allows to apply
    /// a predefined and custom color matrix.
    /// </summary>
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

        /// <summary>
        /// Enable cells of a color matrix.
        /// </summary>
        /// <param name="isEnabled"></param>
        void SetEnabledCells(bool isEnabled);

        /// <summary>
        /// Enable the dropdown to select a color matrix.
        /// </summary>
        void SetEnabledDropDown(bool isEnabled);

        /// <summary>
        /// Set visible the button to apply a color matrix.
        /// </summary>
        void SetVisibleApply(bool isVisible);

        /// <summary>
        /// Set visible the button to apply a color matrix. 
        /// </summary>
        void SetVisibleApplyCustom(bool isVisible);
    }
}
