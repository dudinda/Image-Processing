
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Filter;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.DomainModel.Factory.Morphology.Interface
{
    public interface IMorphologyFactory : IFilterFactory<IMorphologyUnary, MorphologyOperator>
    {
        IMorphologyBinary BinaryFilter(MorphologyOperator filter);
    }
}
