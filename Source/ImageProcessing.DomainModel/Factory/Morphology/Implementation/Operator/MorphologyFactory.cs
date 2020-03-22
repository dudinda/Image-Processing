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
        {
            switch (filter)
            {
                case MorphologyOperator.Addition:
                    return new AdditionOperator();
                case MorphologyOperator.Subtraction:
                    return new SubtractionOperator();
               
                default: throw new NotImplementedException();
            }
        }

        /// <summary>
        /// A factory method
        /// where the <see cref="MorphologyOperator"/> represents an
        /// enumeration for types implementing the <see cref="IMorphologyUnary"/>.
        /// </summary>
        public IMorphologyUnary Get(MorphologyOperator filter)
        {
            switch (filter)
            {        
                case MorphologyOperator.Dilation:
                    return new DilationOperator();
                case MorphologyOperator.Erosion:
                    return new ErosionOperator();
                case MorphologyOperator.Opening:
                    return new OpeningOperator();
                case MorphologyOperator.Closing:
                    return new ClosingOperator();
                case MorphologyOperator.TopHat:
                    return new TopHatOperator();
                case MorphologyOperator.BlackHat:
                    return new BlackHatOperator();
                case MorphologyOperator.Gradient:
                    return new MorphologicalGradientOperator();

                default: throw new NotImplementedException();
            }
        }
    }
}
