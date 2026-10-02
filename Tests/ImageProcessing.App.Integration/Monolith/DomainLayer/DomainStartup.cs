using ImageProcessing.App.Integration.Monolith.ServiceLayer.StructuringElement.Implementation;
using ImageProcessing.App.Integration.Monolith.ServiceLayer.StructuringElement.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.ColorMatrix.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.ColorMatrix.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Convolution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Distribution.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Distribution.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Morphology.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Morphology.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rgb.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rgb.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rotation.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Rotation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Scaling.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Scaling.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Transformation.Implementation;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer.Transformation.Interface;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.Microkernel.MVP;
using ImageProcessing.App.ServiceLayer.Services.Factories.ColorMatrix;
using ImageProcessing.App.ServiceLayer.Services.Factories.Convolution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Distribution;
using ImageProcessing.App.ServiceLayer.Services.Factories.Morphology;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rgb;
using ImageProcessing.App.ServiceLayer.Services.Factories.Rotation;
using ImageProcessing.App.ServiceLayer.Services.Factories.Scaling;
using ImageProcessing.App.ServiceLayer.Services.Factories.Transformation;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer
{
    internal sealed class DomainStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new MicrokernelStartup().Build(builder);
            new Startup().Build(builder);

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
