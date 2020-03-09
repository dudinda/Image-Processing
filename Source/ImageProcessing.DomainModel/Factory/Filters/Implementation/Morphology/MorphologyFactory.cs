using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Morphology;
using ImageProcessing.Core.Model.Morphology.Base;
using ImageProcessing.DomainModel.Model.Morphology;
using ImageProcessing.DomainModel.Model.Morphology.BlackHat;
using ImageProcessing.DomainModel.Model.Morphology.Closing;
using ImageProcessing.DomainModel.Model.Morphology.MorphologicalGradient;
using ImageProcessing.DomainModel.Model.Morphology.Opening;
using ImageProcessing.DomainModel.Model.Morphology.Subtraction;
using ImageProcessing.DomainModel.Model.Morphology.TopHat;

namespace ImageProcessing.DomainModel.Factory.Filters.Implementation.Morphology
{
    /// <summary>
    /// Provides a factory method for all types
    /// marked by <see cref="IMorphologyBase"/>.
    /// </summary>
    public class MorphologyFactory : IMorphologyFactory
    {
        /// <summary>
        /// A factory method
        /// where <see cref="MorphologyOperator"/> represents
        /// enumeration for types marked by <see cref="IMorphologyBase"/>.
        /// </summary>
        public IMorphologyBase GetFilter(MorphologyOperator filter)
        {
            switch (filter)
            {
                case MorphologyOperator.Addition:
                    return new AdditionOperator();
                case MorphologyOperator.Subtraction:
                    return new SubtractionOperator();
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

                default: throw new NotSupportedException();
            }
        }
    }
}
