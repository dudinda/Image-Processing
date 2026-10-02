using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.Morphology.Implementation.Operator;
using ImageProcessing.App.DomainLayer.Factories.Morphology.Operator.Interface;
using ImageProcessing.App.ServiceLayer.Models.Morphology;

namespace ImageProcessing.App.DomainLayer.Factories.Morphology.Operator.Implementation
{
    /// <inheritdoc cref="IMorphologyFactory" />
    public sealed class MorphologyFactory : IMorphologyFactory
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
