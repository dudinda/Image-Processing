using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Transformation.Interface;

namespace ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Implementation
{
    internal sealed class TransformationFactory : ITransformationFactory
    {
        public ITransformation Get(AffTransform transformation)
            => transformation
        switch
         {
             AffTransform.Translation
                 => new TranslationTransformation(),
             AffTransform.Scale
                 => new ScaleTransformation(),
 
             _   => throw new NotImplementedException(nameof(transformation))
         };
    }
}
