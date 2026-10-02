using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Models.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Domain.Services.Factories.ColorMatrix;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Implementation
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
