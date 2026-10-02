using System;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Models.Morphology.Implementation.StructringElement;
using ImageProcessing.App.DomainLayer.Factories.Morphology.StructuringElement.Interface;
using ImageProcessing.App.ServiceLayer.Models.Morphology;

namespace ImageProcessing.App.DomainLayer.Factories.Morphology.StructuringElement.Implementation
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
