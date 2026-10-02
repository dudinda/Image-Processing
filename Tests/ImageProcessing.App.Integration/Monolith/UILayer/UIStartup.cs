using ImageProcessing.App.Integration.Monolith.Presentation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.UndoRedo.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Main.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Main.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rotation.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Settings.Interface;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Transformation.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.UI.Forms;
using ImageProcessing.App.Integration.Monolith.UI.UIModel.Factories.Implementation;
using ImageProcessing.App.Integration.Monolith.UI.UIModel.Factories.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Form;
using ImageProcessing.App.Presentation.UnitTests.TestsComponents.Wrappers.Forms;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Services.FormEventBinders.ColorMatrix;
using ImageProcessing.App.UI.Services.FormEventBinders.Convolution;
using ImageProcessing.App.UI.Services.FormEventBinders.Distribution;
using ImageProcessing.App.UI.Services.FormEventBinders.Main;
using ImageProcessing.App.UI.Services.FormEventBinders.Rgb;
using ImageProcessing.App.UI.Services.FormEventBinders.Rotation;
using ImageProcessing.App.UI.Services.FormEventBinders.Scaling;
using ImageProcessing.App.UI.Services.FormEventBinders.Settings;
using ImageProcessing.App.UI.Services.FormEventBinders.Transformation;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.UI
{
    internal sealed class UIStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new PresentationStartup().Build(builder);

            builder
                .RegisterTransient<IRgbFormEventBinder, RgbFormEventBinderWrapper>()
                .RegisterTransient<IColorMatrixFormEventBinder, ColorMatrixFormEventBinderWrapper>()
                .RegisterTransient<IConvolutionFormEventBinder, ConvolutionFormEventBinderWrapper>()
                .RegisterTransient<IDistributionFormEventBinder, DistributionFormEventBinderWrapper>()
                .RegisterTransient<ISettingsFormEventBinder, SettingsFormEventBinderWrapper>()
                .RegisterTransient<ITransformationFormEventBinder, TransformationFormEventBinderWrapper>()
                .RegisterTransient<IRotationFormEventBinder, RotationFormEventBinderWrapper>()
                .RegisterTransient<IScalingFormEventBinder, ScalingFormEventBinderWrapper>()
                .RegisterTransient<IMainFormEventBinder, MainFormEventBinderWrapper>()
                .RegisterTransientInstance<IMenuStateFactoryWrapper>(
                Substitute.ForPartsOf<MenuStateFactoryWrapper>())
                .RegisterTransientInstance<IColorMatrixFormEventBinderWrapper>(
                Substitute.ForPartsOf<ColorMatrixFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<IConvolutionFormEventBinderWrapper>(
                Substitute.ForPartsOf<ConvolutionFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<IDistributionFormEventBinderWrapper>(
                Substitute.ForPartsOf<DistributionFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<IRgbFormEventBinderWrapper>(
                Substitute.ForPartsOf<RgbFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<IMainFormEventBinderWrapper>(
                Substitute.ForPartsOf<MainFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<IRotationFormEventBinderWrapper>(
                Substitute.ForPartsOf<RotationFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<IScalingFormEventBinderWrapper>(
                Substitute.ForPartsOf<ScalingFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<ITransformationFormEventBinderWrapper>(
                Substitute.ForPartsOf<TransformationFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransientInstance<ISettingsFormEventBinderWrapper>(
                Substitute.ForPartsOf<SettingsFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterSingletonInstance<IMainView>(
                Substitute.ForPartsOf<MainFormWrapper>(
                    builder.Resolve<IMainFormEventBinderWrapper>(),
                    builder.Resolve<IUndoRedoServiceWrapper>(),
                    builder.Resolve<IMenuStateFactoryWrapper>()))
                .RegisterTransientInstance<IColorMatrixView>(
                Substitute.ForPartsOf<ColorMatrixFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<IColorMatrixFormEventBinderWrapper>()))
                .RegisterTransientInstance<IConvolutionView>(
                Substitute.ForPartsOf<ConvolutionFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<IConvolutionFormEventBinderWrapper>()))
                .RegisterTransientInstance<IDistributionView>(
                Substitute.ForPartsOf<DistributionFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<IDistributionFormEventBinderWrapper>()))
                .RegisterTransientInstance<IRgbView>(
                Substitute.ForPartsOf<RgbFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<IRgbFormEventBinderWrapper>()))
                .RegisterTransientInstance<IRotationView>(
                Substitute.ForPartsOf<RotationFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<IRotationFormEventBinderWrapper>()))
                .RegisterTransientInstance<IScalingView>(
                Substitute.ForPartsOf<ScalingFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<IScalingFormEventBinderWrapper>()))
                .RegisterSingletonInstance<ISettingsView>(
                Substitute.ForPartsOf<SettingsFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<ISettingsFormEventBinderWrapper>()))
                .RegisterTransientInstance<ITransformationView>(
                Substitute.ForPartsOf<TransformationFormWrapper>(
                    builder.Resolve<IMainView>(),
                    builder.Resolve<ITransformationFormEventBinderWrapper>()));
        }
    }
}
