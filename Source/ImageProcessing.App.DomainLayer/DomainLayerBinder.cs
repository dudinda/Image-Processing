
using ImageProcessing.App.DomainLayer.Factory.Convolution.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Implementation;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.Factory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Color.Interface;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Implementation;
using ImageProcessing.App.DomainLayer.Factory.RgbFilters.Rgb.Interface;
using ImageProcessing.App.DomainLayer.Factory.StructuringElement.Implementation;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.DomainLayer
{
    public static class DomainLayerBinder
    {
        public static void Build(IDependencyResolution builder)
        {
            builder.RegisterTransient<IConvolutionFilterFactory, ConvolutionFilterFactory>()
                   .RegisterTransient<IMorphologyFactory, MorphologyFactory>()
                   .RegisterTransient<IStructuringElementFactory, StructuringElementFactory>()
                   .RegisterTransient<IDistributionFactory, DistributionFactory>()
                   .RegisterTransient<IRgbFilterFactory, RgbFilterFactory>()
                   .RegisterScoped<IColorFactory, ColorFactory>();
        }
    }
}
