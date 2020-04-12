using System;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.DomainModel.Factory.Morphology.Interface;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Addition;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.BlackHat;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Closing;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Dilation;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Erosion;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.MorphologicalGradient;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Opening;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.Subtraction;
using ImageProcessing.App.DomainModel.Model.Morphology.Implementation.TopHat;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.BinaryOperator;
using ImageProcessing.App.DomainModel.Model.Morphology.Interface.UnaryOperator;

namespace ImageProcessing.App.DomainModel.Factory.Morphology.Implementation
{
    /// <inheritdoc cref="IMorphologyFactory" />
    public sealed class MorphologyFactory : IMorphologyFactory
    {
        /// <inheritdoc/>
        public IMorphologyBinary GetBinary(MorphologyOperator filter)
            => filter
        switch
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
        /// enumeration for the types implementing the <see cref="IMorphologyUnary"/>.
        /// </summary>
        public IMorphologyUnary Get(MorphologyOperator filter)
            => filter
        switch
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
