using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Convolution.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionKernel"/>.
    /// </summary>
    public interface IConvolutionFactory : IModelFactory<IConvolutionKernel, ConvKernel>
    {

    }
}
