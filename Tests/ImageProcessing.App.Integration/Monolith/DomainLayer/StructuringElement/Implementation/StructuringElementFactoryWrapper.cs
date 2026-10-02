
using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.StructuringElement.Interface;
using ImageProcessing.App.ServiceLayer.Models.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Factories.Morphology.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.StructuringElement.Implementation
{
    internal class StructuringElementFactoryWrapper : IStructuringElementFactoryWrapper
    {
        private readonly StructuringElementFactory _factory
            = new StructuringElementFactory();

        public virtual IStructuringElement Get(StructElem model)
            => _factory.Get(model);

    }
}
