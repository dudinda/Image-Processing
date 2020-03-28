using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Convolution.Interface;
using ImageProcessing.DomainModel.Factory.Base;

namespace ImageProcessing.DomainModel.Factory.Convolution.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IConvolutionFilter"/>.
    /// </summary>
    public interface IConvolutionFilterFactory : IBaseFactory<IConvolutionFilter, ConvolutionFilter>
    {

    }
}
