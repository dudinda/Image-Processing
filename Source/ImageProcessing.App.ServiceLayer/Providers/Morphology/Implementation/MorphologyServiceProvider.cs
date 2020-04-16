using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.DomainModel.Factory.Morphology.Interface;
using ImageProcessing.App.DomainModel.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.ServiceLayer.Providers.Interface.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.Utility.DataStructure.BitMatrix.Implementation;

namespace ImageProcessing.App.ServiceLayer.Providers.Implementation.Morphology
{
    public sealed class MorphologyServiceProvider : IMorphologyServiceProvider
    {
        private readonly IMorphologyService _morphologyService;
        private readonly IMorphologyFactory _morphologyFactory;
        private readonly IStructuringElementFactory _kernelFactory;
        private readonly ICacheService<Bitmap> _cache;

        public MorphologyServiceProvider(IMorphologyService morphologyService,
                                         IMorphologyFactory morphologyFactory,
                                         ICacheService<Bitmap> cache,
                                         IStructuringElementFactory kernelFactory)
        {
            _morphologyService = Requires.IsNotNull(
                morphologyService, nameof(morphologyService));
            _morphologyFactory = Requires.IsNotNull(
                morphologyFactory, nameof(morphologyFactory));
            _kernelFactory = Requires.IsNotNull(
                kernelFactory, nameof(kernelFactory));
            _cache = Requires.IsNotNull(
                cache, nameof(cache));
        }

        /// <inheritdoc/>
        public Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphologyOperator filter)
        {
            Requires.IsNotNull(lvalue, nameof(lvalue));
            Requires.IsNotNull(rvalue, nameof(rvalue));

            return _morphologyService
                       .ApplyOperator(lvalue, rvalue,
                           _morphologyFactory.GetBinary(filter)         
            );
        }

        /// <inheritdoc/>
        public Bitmap ApplyCustomUnary(Bitmap bmp, BitMatrix kernel, MorphologyOperator filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));
            Requires.IsNotNull(kernel, nameof(kernel));

            return _morphologyService
                       .ApplyOperator(bmp, kernel,
                           _morphologyFactory.Get(filter)
            );
        }

        /// <inheritdoc/>
        public Bitmap ApplyUnary(Bitmap bmp, StructuringElem kernel, (int width, int height) dim, MorphologyOperator filter)
        {
            Requires.IsNotNull(bmp, nameof(bmp));

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
