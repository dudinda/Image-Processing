using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Convolution.Interface;

namespace ImageProcessing.DomainModel.Factory.Convolution.Interface
{
    /// <summary>
    /// Interface that ConvolutionFilterFactory methods are required to implement.
    /// </summary>
    public interface IConvolutionFilterFactory : IBaseFactory<IConvolutionFilter, ConvolutionFilter>
    {

    }
}
