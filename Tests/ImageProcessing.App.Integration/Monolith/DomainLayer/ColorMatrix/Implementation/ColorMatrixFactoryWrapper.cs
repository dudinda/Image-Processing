using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Models.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.ColorMatrix.Interface;
using ImageProcessing.App.ServiceLayer.Services.Factories.ColorMatrix;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.ColorMatrix.Implementation
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
