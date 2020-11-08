
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.BinaryOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.Microkernel.MVP.Model;

namespace ImageProcessing.App.DomainLayer.Factory.Morphology.Interface
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
