using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.Channel.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.RgbFilters.Recommendation.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.StructuringElement.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Implementation;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface;
using ImageProcessing.App.DomainLayer.Factory.Distribution.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Distribution.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Distribution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Morphology.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rgb.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rotation.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Scaling.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Transformation.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Microkernel.MVP;
using ImageProcessing.App.ServiceLayer.Services.Settings.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Settings.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.DomainLayer
{
    internal sealed class DomainStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new Startup().Build(builder);
            new MicrokernelStartup().Build(builder);

            var colorMatrix = Substitute.ForPartsOf<ColorMatrixFactoryWrapper>(builder.Resolve<IColorMatrixFactory>());
            var convolution = Substitute.ForPartsOf<ConvoltuionFactoryWrapper>(builder.Resolve<IConvolutionFactory>());
            var distribution = Substitute.ForPartsOf<DistributionFactoryWrapper>(builder.Resolve<IDistributionFactory>());
            var morphology = Substitute.ForPartsOf<MorphologyFactoryWrapper>(builder.Resolve<IMorphologyFactory>());
            var rgb = Substitute.ForPartsOf<RgbFactoryWrapper>(builder.Resolve<IRgbFilterFactory>());
            var rotation = Substitute.ForPartsOf<RotationFactoryWrapper>(builder.Resolve<IRotationFactory>());
            var scaling = Substitute.ForPartsOf<ScalingFactoryWrapper>(builder.Resolve<IScalingFactory>());
            var transformation = Substitute.ForPartsOf<TransformationFactoryWrapper>(builder.Resolve<ITransformationFactory>());

            builder
                .RegisterTransientInstance<IColorMatrixFactoryWrapper>(colorMatrix)
                .RegisterTransientInstance<IConvolutionFactoryWrapper>(convolution)
                .RegisterTransientInstance<IDistributionFactoryWrapper>(distribution)
                .RegisterTransientInstance<IMorphologyFactoryWrapper>(morphology)
                .RegisterTransientInstance<IRgbFactoryWrapper>(rgb)
                .RegisterTransientInstance<IRotationFactoryWrapper>(rotation)
                .RegisterTransientInstance<IScalingFactoryWrapper>(scaling)
                .RegisterTransientInstance<ITransformationFactoryWrapper>(transformation);
        }
    }
}
