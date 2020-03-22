using System;

using ImageProcessing.Common.Enums;
using ImageProcessing.DomainModel.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.StructringElement.CrossShaped;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.StructringElement.Elliptical;
using ImageProcessing.DomainModel.Model.Morphology.Implementation.StructringElement.Rectangular;
using ImageProcessing.DomainModel.Model.Morphology.Interface.StructuringElement;

namespace ImageProcessing.DomainModel.Factory.StructuringElement.Implementation
{
    public sealed class StructuringElementFactory : IStructuringElementFactory
    {
        /// <summary>
        /// A factory method
        /// where the <see cref="StructuringElem"/> represents an
        /// enumeration for types implementing the <see cref="IStructuringElementFactory"/>.
        /// </summary>
        public IStructuringElement Get(StructuringElem filter)
        {
            switch (filter)
            {
                case StructuringElem.Elliptical:
                    return new EllipticalElement();
                case StructuringElem.Rectangular:
                    return new RectangularElement();
                case StructuringElem.CrossShaped:
                    return new CrossShapedElement();

                default: throw new NotImplementedException(nameof(filter));
            }
        }
    }
}
