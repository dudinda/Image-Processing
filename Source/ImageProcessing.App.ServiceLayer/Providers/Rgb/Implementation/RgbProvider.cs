using System.Drawing;

using ImageProcessing.App.ServiceLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Cache;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Services.Factories.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Rgb.Implementation
{
    /// <inheritdoc cref="IRgbProvider"/>
    public sealed class RgbProvider : IRgbProvider
    {
        private readonly IRgbFilterFactory _rgb;
        private readonly IColorMatrixService _service;
        private readonly IColorMatrixFactory _matrix;

        public RgbProvider(
            IRgbFilterFactory rgb,
            IColorMatrixService service,
            IColorMatrixFactory matrix,
            ICacheService<Bitmap> cache)
        {
            _rgb = rgb;
            _matrix = matrix;
            _service = service;
        }

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbFltr filter)
            => _rgb.Get(filter).Filter(bmp);

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbChannels color)
            => _rgb.Get(color).Filter(bmp);

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, ClrMatrix matrix)
            => _service.Apply(bmp, _matrix.Get(matrix).Matrix);

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, ReadOnly2DArray<double> matrix)
            => _service.Apply(bmp, matrix);
    }
}
