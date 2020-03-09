using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.Morphology.Base;

namespace ImageProcessing.Core.Factory.Morphology
{
    public interface IMorphologyFactory : IFilterFactory<IMorphologyBase, MorphologyOperator>
    {

    }
}
