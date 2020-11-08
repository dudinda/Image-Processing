using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.Operator;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.BinaryOperator;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.UnaryOperator;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface;

namespace ImageProcessing.App.DomainLayer.Factory.Morphology.Implementation
{
    /// <inheritdoc cref="IMorphologyFactory" />
    internal sealed class MorphologyFactory : IMorphologyFactory
    {
        /// <inheritdoc/>
        public IMorphologyBinary GetBinary(MorphOperator filter)
            => filter
        switch
        {
            MorphOperator.Addition
                => new AdditionOperator(),
            MorphOperator.Subtraction
                => new SubtractionOperator(),

            _   => throw new NotImplementedException(nameof(filter))
        };

        /// <summary>
        /// A factory method
        /// where the <see cref="MorphologyOperators"/> represents an
        /// enumeration for the types implementing the <see cref="IMorphologyUnary"/>.
        /// </summary>
        public IMorphologyUnary Get(MorphOperator filter)
            => filter
        switch
        {
            MorphOperator.Dilation
                => new DilationOperator(),
            MorphOperator.Erosion
                => new ErosionOperator(),
            MorphOperator.Opening
                => new OpeningOperator(),
            MorphOperator.Closing
                => new ClosingOperator(),
            MorphOperator.TopHat
                => new TopHatOperator(),
            MorphOperator.BlackHat
                => new BlackHatOperator(),
            MorphOperator.Gradient
                => new MorphologicalGradientOperator(),

            _   => throw new NotImplementedException(nameof(filter))
        };       
    }
}
