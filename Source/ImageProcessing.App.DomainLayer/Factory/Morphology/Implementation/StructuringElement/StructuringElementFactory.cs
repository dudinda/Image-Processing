using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.StructringElement.CrossShaped;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.StructringElement.Elliptical;
using ImageProcessing.App.DomainLayer.Model.Morphology.Implementation.StructringElement.Rectangular;
using ImageProcessing.App.DomainLayer.Model.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainLayer.Factory.StructuringElement.Implementation
{
    /// <inheritdoc cref="IStructuringElementFactory"/>
    public sealed class StructuringElementFactory : IStructuringElementFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="StructuringElem"/> represents an
        /// enumeration for the types implementing the <see cref="IStructuringElementFactory"/>.
        /// </summary>
        public IStructuringElement Get(StructuringElem filter)
            => filter
        switch
        {
            StructuringElem.CrossShaped
                => new CrossShapedElement(),
            StructuringElem.Elliptical
                => new EllipticalElement(),
            StructuringElem.Rectangular
                => new RectangularElement(),

            _   => throw new NotImplementedException(nameof(filter))
        };            
    }
}