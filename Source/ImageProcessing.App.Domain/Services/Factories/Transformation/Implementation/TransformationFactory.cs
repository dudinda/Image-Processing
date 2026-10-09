using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Transformation;
using ImageProcessing.App.Domain.Models.Transformation.Implementation;
using ImageProcessing.App.Domain.Services.Factories.Transformation;

namespace ImageProcessing.App.Domain.Factories.Transformation.Implementation
{
    public sealed class TransformationFactory : ITransformationFactory
    {
        public ITransformation Get(AffTransform transformation)
            => transformation
        switch
         {
             AffTransform.Translation
                 => new TranslationTransformation(),
             AffTransform.CyclicTranslation
                 => new CyclicTranslationTransformation(),
             AffTransform.Scale
                 => new ScaleTransformation(),
             AffTransform.Shear
                 => new ShearTransformation(),
 
             _   => throw new NotImplementedException(nameof(transformation))
         };
    }
}
