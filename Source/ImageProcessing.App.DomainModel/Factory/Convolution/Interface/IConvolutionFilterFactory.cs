using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainModel.Convolution.Interface;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainModel.Factory.Convolution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionFilter"/>.
    /// </summary>
    public interface IConvolutionFilterFactory : IModelFactory<IConvolutionFilter, ConvolutionFilter>
    {

    }
}
