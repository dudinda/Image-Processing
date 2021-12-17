using ImageProcessing.App.DomainLayer.DomainFactory.ColorMatrix.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Convolution.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Distribution.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Morphology.Interface.StructuringElement;
using ImageProcessing.App.DomainLayer.DomainFactory.Rgb.RgbFilter.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Rotation.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Scaling.Interface;
using ImageProcessing.App.DomainLayer.DomainFactory.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Implementation;
using ImageProcessing.App.Integration.Monolith.DomainLayer.StructuringElement.Interface;
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

            builder
                .RegisterTransientInstance<IColorMatrixFactoryWrapper>(
                Substitute.ForPartsOf<ColorMatrixFactoryWrapper>(
                    builder.Resolve<IColorMatrixFactory>()))
                .RegisterTransientInstance<IStructuringElementFactoryWrapper>(
                Substitute.ForPartsOf<StructuringElementFactoryWrapper>())
                .RegisterTransientInstance<IConvolutionFactoryWrapper>(
                Substitute.ForPartsOf<ConvoltuionFactoryWrapper>(
                    builder.Resolve<IConvolutionFactory>()))
                .RegisterTransientInstance<IDistributionFactoryWrapper>(
                Substitute.ForPartsOf<DistributionFactoryWrapper>(
                    builder.Resolve<IDistributionFactory>()))
                .RegisterTransientInstance<IMorphologyFactoryWrapper>(
                Substitute.ForPartsOf<MorphologyFactoryWrapper>(
                    builder.Resolve<IMorphologyFactory>()))
                .RegisterTransientInstance<IRgbFactoryWrapper>(
                Substitute.ForPartsOf<RgbFactoryWrapper>(
                    builder.Resolve<IRgbFilterFactory>()))
                .RegisterTransientInstance<IRotationFactoryWrapper>(
                Substitute.ForPartsOf<RotationFactoryWrapper>(
                    builder.Resolve<IRotationFactory>()))
                .RegisterTransientInstance<IScalingFactoryWrapper>(
                Substitute.ForPartsOf<ScalingFactoryWrapper>(
                    builder.Resolve<IScalingFactory>()))
                .RegisterTransientInstance<ITransformationFactoryWrapper>(
                Substitute.ForPartsOf<TransformationFactoryWrapper>(
                    builder.Resolve<ITransformationFactory>()));
        }
    }
}
