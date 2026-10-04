using ImageProcessing.App.Domain.Code.Collections;

namespace ImageProcessing.App.Domain.Models.ColorMatrix
{
    public interface IColorMatrix
    {
        ReadOnly2DArray<double> Matrix { get; }
    }
}
