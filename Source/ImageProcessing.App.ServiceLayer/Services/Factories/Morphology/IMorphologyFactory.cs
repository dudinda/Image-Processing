using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Factories;
using ImageProcessing.App.ServiceLayer.Models.Morphology;

namespace ImageProcessing.App.ServiceLayer.Services.Factories.Morphology
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
