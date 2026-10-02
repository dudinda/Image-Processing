
using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.Factories.Morphology.StructuringElement.Implementation;
using ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Interface;
using ImageProcessing.App.ServiceLayer.Models.Morphology;

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
