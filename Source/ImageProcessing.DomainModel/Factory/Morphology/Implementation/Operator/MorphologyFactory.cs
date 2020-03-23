using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.Morphology.Interface;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Addition;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.BlackHat;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Closing;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Dilation;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Erosion;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.MorphologicalGradient;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Opening;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.TopHat;
using ImageProcessing.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.DomainModel.Factory.Morphology.Implementation
{
    /// <inheritdoc cref="IMorphologyFactory" />
    public sealed class MorphologyFactory : IMorphologyFactory
    {
        /// <inheritdoc/>
        public IMorphologyBinary BinaryFilter(MorphologyOperator filter)
        => filter switch
        {
            MorphologyOperator.Addition
                => new AdditionOperator(),
            MorphologyOperator.Subtraction
                => new SubtractionOperator(),

            _   => throw new NotImplementedException(nameof(filter))
        };

        /// <summary>
        /// A factory method
        /// where the <see cref="MorphologyOperator"/> represents an
        /// enumeration for types implementing the <see cref="IMorphologyUnary"/>.
        /// </summary>
        public IMorphologyUnary Get(MorphologyOperator filter)
        => filter switch
        {
            MorphologyOperator.Dilation
                => new DilationOperator(),
            MorphologyOperator.Erosion
                => new ErosionOperator(),
            MorphologyOperator.Opening
                => new OpeningOperator(),
            MorphologyOperator.Closing
                => new ClosingOperator(),
            MorphologyOperator.TopHat
                => new TopHatOperator(),
            MorphologyOperator.BlackHat
                => new BlackHatOperator(),
            MorphologyOperator.Gradient
                => new MorphologicalGradientOperator(),

            _   => throw new NotImplementedException(nameof(filter))
        };       
    }
}
