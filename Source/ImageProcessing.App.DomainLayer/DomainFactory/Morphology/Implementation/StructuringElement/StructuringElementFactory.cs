using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.StructringElement;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainLayer.Factory.StructuringElement.Implementation
{
    /// <inheritdoc cref="IStructuringElementFactory"/>
    internal sealed class StructuringElementFactory : IStructuringElementFactory
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
