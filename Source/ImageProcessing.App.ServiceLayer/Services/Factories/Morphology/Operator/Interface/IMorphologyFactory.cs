using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories;
using ImageProcessing.App.DomainLayer.Models.Morphology.Interface.Operator.BinaryOperator;
using ImageProcessing.App.DomainLayer.Models.Morphology.Interface.Operator.UnaryOperator;

namespace ImageProcessing.App.DomainLayer.Factories.Morphology.Operator.Interface
{
    /// <summary>
    /// Provides a factory method for all the types
    /// implementing the <see cref="IMorphologyUnary"/>
    /// and <see cref="IMorphologyBinary"/>.
    /// </summary>
    public interface IMorphologyFactory : IModelFactory<IMorphologyUnary, MorphOperator>
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="MorphOperator"/> represents an
        /// enumeration for the types implementing the <see cref="IMorphologyBinary"/>.
        /// </summary>
        IMorphologyBinary GetBinary(MorphOperator filter);
    }
}
