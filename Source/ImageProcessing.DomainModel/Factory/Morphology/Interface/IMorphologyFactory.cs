
using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.DomainModel.Factory.Morphology.Interface
{
    public interface IMorphologyFactory : IBaseFactory<IMorphologyUnary, MorphologyOperator>
    {
        IMorphologyBinary BinaryFilter(MorphologyOperator filter);
    }
}
