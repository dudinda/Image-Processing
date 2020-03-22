using ImageProcessing.Common.Utility.BitMatrix.Implementation;

namespace ImageProcessing.DomainModel.Model.Morphology.Interface.StructuringElement
{
    public interface IStructuringElement
    {
        BitMatrix GetKernel((int width, int height) dimension);
    }
}
