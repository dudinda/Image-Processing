using ImageProcessing.Common.Enums;
using ImageProcessing.Core.MVP.Model;
using ImageProcessing.DomainModel.Convolution.Interface;

namespace ImageProcessing.DomainModel.Factory.Convolution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionFilter"/>.
    /// </summary>
    public interface IConvolutionFilterFactory : IModelFactory<IConvolutionFilter, ConvolutionFilter>
    {

    }
}
