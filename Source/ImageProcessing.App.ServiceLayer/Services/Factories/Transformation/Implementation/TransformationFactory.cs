using System;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.Transformation.Implementation;
using ImageProcessing.App.ServiceLayer.Models.Transformation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Transformation;

namespace ImageProcessing.App.ServiceLayer.Factories.Transformation.Implementation
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
