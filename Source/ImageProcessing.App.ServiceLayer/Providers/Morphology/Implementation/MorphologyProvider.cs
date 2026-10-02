using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Providers.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Cache;
using ImageProcessing.App.ServiceLayer.Services.Factories.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Morphology;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Morphology.Implementation
{
    /// <inheritdoc cref="IMorphologyProvider"/>
    public sealed class MorphologyProvider : IMorphologyProvider
    {
        private readonly IMorphologyService _morphologyService;
        private readonly IMorphologyFactory _morphologyFactory;
        private readonly IStructuringElementFactory _kernelFactory;
        private readonly ICacheService<Bitmap> _cache;

        public MorphologyProvider(
            IMorphologyService morphologyService,
            IMorphologyFactory morphologyFactory,
            ICacheService<Bitmap> cache,
            IStructuringElementFactory kernelFactory)
        {
            _morphologyService = morphologyService;
            _morphologyFactory = morphologyFactory;
            _kernelFactory = kernelFactory;
            _cache = cache;
        }

        /// <inheritdoc/>
        public Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphOperator filter)
            => _morphologyService
                    .ApplyOperator(lvalue, rvalue,
                        _morphologyFactory.GetBinary(filter)         
            );

        /// <inheritdoc/>
        public Bitmap ApplyCustomUnary(Bitmap bmp, BitMatrix kernel, MorphOperator filter)
            => _morphologyService
                    .ApplyOperator(bmp, kernel,
                        _morphologyFactory.Get(filter)
            );

        /// <inheritdoc/>
        public Bitmap ApplyUnary(Bitmap bmp, StructElem kernel, (int width, int height) dim, MorphOperator filter)
        {
            return _cache.GetOrCreate(filter,
                () =>
                _morphologyService
                    .ApplyOperator(bmp,
                        _kernelFactory.Get(kernel).GetKernel(dim),
                        _morphologyFactory.Get(filter)
                )
            );
        }
    }
}
