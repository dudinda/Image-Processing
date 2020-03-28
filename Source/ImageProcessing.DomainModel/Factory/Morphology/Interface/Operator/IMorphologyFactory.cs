
using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.Base;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.DomainModel.Factory.Morphology.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IMorphologyUnary"/>
    /// and <see cref="IMorphologyBinary"/>.
    /// </summary>
    public interface IMorphologyFactory : IBaseFactory<IMorphologyUnary, MorphologyOperator>
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="MorphologyOperator"/> represents an
        /// enumeration for types implementing the <see cref="IMorphologyBinary"/>.
        /// </summary>
        IMorphologyBinary BinaryFilter(MorphologyOperator filter);
    }
}
