using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.Transformation.Implementation;
using ImageProcessing.App.DomainLayer.Factories.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Models.Transformation;

namespace ImageProcessing.App.DomainLayer.Factories.Transformation.Implementation
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
