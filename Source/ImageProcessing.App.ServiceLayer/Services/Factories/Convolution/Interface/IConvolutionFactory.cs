using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.Convolution.Interface;

namespace ImageProcessing.App.DomainLayer.Factories.Convolution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionKernel"/>.
    /// </summary>
    public interface IConvolutionFactory : IModelFactory<IConvolutionKernel, ConvKernel>
    {

    }
}
