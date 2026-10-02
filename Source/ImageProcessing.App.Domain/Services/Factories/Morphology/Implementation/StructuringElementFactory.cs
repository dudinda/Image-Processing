using System;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.Morphology.Implementation.StructringElement;
using ImageProcessing.App.Domain.Models.Morphology;
using ImageProcessing.App.Domain.Services.Factories.Morphology;

namespace ImageProcessing.App.Domain.Services.Factories.Morphology.Implementation
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
