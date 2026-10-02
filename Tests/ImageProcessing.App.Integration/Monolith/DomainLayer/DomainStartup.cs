using ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.StructuringElement.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.ColorMatrix.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Convolution.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Distribution.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Distribution.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Morphology.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Morphology.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rgb.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rotation.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Rotation.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Scaling.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Scaling.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Transformation.Implementation;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain.Transformation.Interface;
using ImageProcessing.App.Presentation.IntegrationTests.Monolith.Microkernel.MVP;
using ImageProcessing.App.Domain.Services.Factories.ColorMatrix;
using ImageProcessing.App.Domain.Services.Factories.Convolution;
using ImageProcessing.App.Domain.Services.Factories.Distribution;
using ImageProcessing.App.Domain.Services.Factories.Morphology;
using ImageProcessing.App.Domain.Services.Factories.Rgb;
using ImageProcessing.App.Domain.Services.Factories.Rotation;
using ImageProcessing.App.Domain.Services.Factories.Scaling;
using ImageProcessing.App.Domain.Services.Factories.Transformation;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.Presentation.IntegrationTests.Monolith.Domain
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
