
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.Core.Model.Morphology.BinaryOperator;
using ImageProcessing.Core.Model.Morphology.UnaryOperator;

namespace ImageProcessing.Core.Factory.Morphology
{
    public interface IMorphologyFactory : IFilterFactory<IMorphologyUnary, MorphologyOperator>
    {
        IMorphologyBinary BinaryFilter(MorphologyOperator filter);
    }
}
