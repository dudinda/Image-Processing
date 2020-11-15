using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.Microkernel.MVP.View;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.PresentationLayer.Views.ColorMatrix
{
    public interface IColorMatrixView : IView,
        IDropdown<ClrMatrix>
    {
        ReadOnly2DArray<double> GetGrid();
    }
}
