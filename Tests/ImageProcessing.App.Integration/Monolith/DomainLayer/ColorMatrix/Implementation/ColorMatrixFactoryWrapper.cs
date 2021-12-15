using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainModel.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Interface;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Implementation
{
    internal class ColorMatrixFactoryWrapper : IColorMatrixFactoryWrapper
    {
        private readonly IColorMatrixFactory _factory;

        public ColorMatrixFactoryWrapper(IColorMatrixFactory factory)
        {
            _factory = factory;
        }

        public virtual IColorMatrix Get(ClrMatrix matrix)
            => _factory.Get(matrix);
    }
}
