using ImageProcessing.App.Common.Enums;
using ImageProcessing.Framework.Core.MVP.Model;
using ImageProcessing.App.DomainModel.Convolution.Interface;

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
