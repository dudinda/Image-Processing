using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Rgb.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.ColorMatrix.Interface;
using ImageProcessing.Utility.DataStructure.ReadOnly2DArray.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Rgb.Implementation
{
    /// <inheritdoc cref="IRgbServiceProvider"/>
    internal sealed class RgbServiceProvider : IRgbServiceProvider
    {
        private readonly IRgbFilterFactory _rgb;
        private readonly IColorMatrixService _service;
        private readonly IColorMatrixFactory _matrix;
        private readonly ICacheService<Bitmap> _cache;

        public RgbServiceProvider(
            IRgbFilterFactory rgb,
            IColorMatrixService service,
            IColorMatrixFactory matrix,
            ICacheService<Bitmap> cache)
        {
            _rgb = rgb;
            _matrix = matrix;
            _service = service;
            _cache = cache;
        }

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbFltr filter)
            => _cache.GetOrCreate(filter, 
               () => _rgb.Get(filter).Filter(bmp)
            );

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, RgbChannels color)
            => _cache.GetOrCreate(color,
               () => _rgb.Get(color).Filter(bmp)
            );

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, ClrMatrix matrix)
            => _cache.GetOrCreate(matrix,
               () => _service.Apply(bmp, _matrix.Get(matrix).Matrix)
            );

        /// <inheritdoc/>
        public Bitmap Apply(Bitmap bmp, ReadOnly2DArray<double> matrix)
            => _service.Apply(bmp, matrix);
    }
}
