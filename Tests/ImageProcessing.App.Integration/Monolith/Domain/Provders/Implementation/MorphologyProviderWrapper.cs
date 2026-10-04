using System.Drawing;

using ImageProcessing.App.Domain.Code.Collections;
using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Domain.Providers.Morphology.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Providers.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Morphology.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Providers.Morphology.Implementation
{
    internal class MorphologyProviderWrapper : IMorphologyProviderWrapper
    {
        private readonly MorphologyProvider _provider;

        public IMorphologyServiceWrapper MorphologyService { get; }
        public IMorphologyFactoryWrapper MorphologyFactory { get; }
        public IStructuringElementFactoryWrapper KernelFactory { get; }
        public ICacheServiceWrapper CacheService { get; }

        public MorphologyProviderWrapper(
            IMorphologyServiceWrapper service,
            IMorphologyFactoryWrapper factory,
            ICacheServiceWrapper cache,
            IStructuringElementFactoryWrapper kernel)
        {
            MorphologyService = service;
            MorphologyFactory = factory;
            KernelFactory = kernel;
            CacheService = cache;

            _provider = new MorphologyProvider(service, factory, cache, kernel);
        }

        public virtual Bitmap ApplyBinary(Bitmap lvalue, Bitmap rvalue, MorphOperator filter)
            => _provider.ApplyBinary(lvalue, rvalue, filter);

        public virtual Bitmap ApplyCustomUnary(Bitmap bmp, BitMatrix kernel, MorphOperator filter)
            => _provider.ApplyCustomUnary(bmp, kernel, filter);

        public virtual Bitmap ApplyUnary(Bitmap bmp, StructElem kernel, (int width, int height) dim, MorphOperator filter)
            => _provider.ApplyUnary(bmp, kernel, dim, filter);
  
    }
}
