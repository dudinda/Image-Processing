using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.Core.Factory.Morphology;
using ImageProcessing.Core.Model.Morphology.Base;
using ImageProcessing.DomainModel.Model.Morphology;
using ImageProcessing.DomainModel.Model.Morphology.Closing;
using ImageProcessing.DomainModel.Model.Morphology.Opening;
using ImageProcessing.DomainModel.Model.Morphology.Subtraction;

namespace ImageProcessing.DomainModel.Factory.Filters.Implementation.Morphology
{
    public class MorphologyFactory : IMorphologyFactory
    {
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

                default: throw new NotSupportedException();
            }
        }
    }
}
