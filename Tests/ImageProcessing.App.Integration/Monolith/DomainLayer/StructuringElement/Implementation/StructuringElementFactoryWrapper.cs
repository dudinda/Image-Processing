
using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.StructuringElement.Implementation;
using ImageProcessing.App.DomainLayer.DomainModel.Morphology.Interface.StructuringElement;
using ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Interface;

namespace ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Implementation
{
    internal class StructuringElementFactoryWrapper : IStructuringElementFactoryWrapper
    {
        private readonly StructuringElementFactory _factory
            = new StructuringElementFactory();

        public virtual IStructuringElement Get(StructElem model)
            => _factory.Get(model);

    }
}
