using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Factories;
using ImageProcessing.App.Domain.Models.Convolution;

namespace ImageProcessing.App.Domain.Services.Factories.Convolution
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionKernel"/>.
    /// </summary>
    public interface IConvolutionFactory : IModelFactory<IConvolutionKernel, ConvKernel>
    {

    }
}
