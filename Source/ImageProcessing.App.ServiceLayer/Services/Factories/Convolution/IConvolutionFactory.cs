using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Convolution;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Convolution
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionKernel"/>.
    /// </summary>
    public interface IConvolutionFactory : IModelFactory<IConvolutionKernel, ConvKernel>
    {

    }
}
