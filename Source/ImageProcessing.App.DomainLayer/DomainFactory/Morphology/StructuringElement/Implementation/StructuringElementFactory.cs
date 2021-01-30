using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.StructringElement;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainLayer.DomainFactory.StructuringElement.Implementation
{
    /// <inheritdoc cref="IStructuringElementFactory"/>
    public sealed class StructuringElementFactory : IStructuringElementFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="StructElem"/> represents an
        /// enumeration for the types implementing the <see cref="IStructuringElementFactory"/>.
        /// </summary>
        public IStructuringElement Get(StructElem element)
            => element
        switch
        {
            StructElem.CrossShaped
                => new CrossShapedElement(),
            StructElem.Elliptical
                => new EllipticalElement(),
            StructElem.Rectangular
                => new RectangularElement(),

            _   => throw new NotImplementedException(nameof(element))
        };            
    }
}
