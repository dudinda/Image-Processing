using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.Morphology
{
    /// <inheritdoc cref="IMorphologyServiceProvider"/>
    public sealed class MorphologyServiceProvider : IMorphologyServiceProvider
    {
        private readonly IMorphologyService _morphologyService;
        private readonly IMorphologyFactory _morphologyFactory;
        private readonly IStructuringElementFactory _kernelFactory;
        private readonly ICacheService<Bitmap> _cache;

        public MorphologyServiceProvider(
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
