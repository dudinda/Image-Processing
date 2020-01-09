using ImageProcessing.ConvulationFilters;

namespace ImageProcessing.DomainModel.Factory.Filters.Interface
{
    /// <summary>
    /// Interface that Convol methods are required to implement.
    /// </summary>
    /// <seealso cref="BaseFactory"/>
    public interface IConvolutionFilterFactory : IFilterFactory<AbstractConvolutionFilter>
    {

    }
}
