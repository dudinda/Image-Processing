using System;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Implementation.StructringElement;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;

namespace ImageProcessing.App.DomainLayer.Factory.StructuringElement.Implementation
{
    /// <inheritdoc cref="IStructuringElementFactory"/>
    public sealed class StructuringElementFactory : IStructuringElementFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="StructElem"/> represents an
        /// enumeration for the types implementing the <see cref="IStructuringElementFactory"/>.
        /// </summary>
        public IStructuringElement Get(StructElem filter)
            => filter
        switch
        {
            StructElem.CrossShaped
                => new CrossShapedElement(),
            StructElem.Elliptical
                => new EllipticalElement(),
            StructElem.Rectangular
                => new RectangularElement(),

            _   => throw new NotImplementedException(nameof(filter))
        };            
    }
}
