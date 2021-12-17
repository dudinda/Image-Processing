using System.Drawing;

using ImageProcessing.App.DomainLayer.Code.Enums;
using ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Morphology.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Morphology.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Interface;
using ImageProcessing.App.ServiceLayer.Providers.Implementation.Morphology;
using ImageProcessing.Utility.DataStructure.BitMatrixSrc.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Providers.Morphology.Implementation
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
