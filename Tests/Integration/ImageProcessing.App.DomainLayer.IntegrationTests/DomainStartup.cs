using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Color.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.DomainLayer
{
    public sealed class DomainStartup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            builder
                .RegisterTransient<IConvolutionFilterFactory>()
                .RegisterTransient<IMorphologyFactory>()
                .RegisterTransient<IStructuringElementFactory>()
                .RegisterTransient<IDistributionFactory>()
                .RegisterTransient<IRgbFilterFactory>()
                .RegisterTransient<IColorFactory>();
        }
    }
}
