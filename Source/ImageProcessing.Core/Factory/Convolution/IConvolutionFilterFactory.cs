using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.Core.Factory.ConvolutionFactory
{
    /// <summary>
    /// Interface that ConvolutionFactory methods are required to implement.
    /// </summary>
    public interface IConvolutionFilterFactory : IFilterFactory<AbstractConvolutionFilter, ConvolutionFilter>
    {

    }
}
