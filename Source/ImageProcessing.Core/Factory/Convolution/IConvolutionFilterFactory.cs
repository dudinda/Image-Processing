using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.Convolution;

namespace ImageProcessing.Core.Factory.Convolution
{
    /// <summary>
    /// Interface that Convol methods are required to implement.
    /// </summary>
    /// <seealso cref="BaseFactory"/>
    public interface IConvolutionFilterFactory : IFilterFactory<AbstractConvolutionFilter>
    {

    }
}
