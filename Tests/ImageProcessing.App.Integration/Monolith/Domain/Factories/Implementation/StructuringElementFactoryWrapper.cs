
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Interface;
using ImageProcessing.App.Domain.Models.Morphology;
using ImageProcessing.App.Domain.Services.Factories.Morphology.Implementation;

namespace ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Implementation
{
    internal class StructuringElementFactoryWrapper : IStructuringElementFactoryWrapper
    {
        private readonly StructuringElementFactory _factory
            = new StructuringElementFactory();

        public virtual IStructuringElement Get(StructElem model)
            => _factory.Get(model);

    }
}
