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
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Services.Providers;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.UI
{
    public class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new Presentation.Startup().Build(builder);

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
                .RegisterTransient<IMenuStateFactoryWrapper>(factory =>
                        Substitute.ForPartsOf<MenuStateFactoryWrapper>())
                .RegisterTransient<IColorMatrixFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<ColorMatrixFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<IConvolutionFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<ConvolutionFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<IDistributionFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<DistributionFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<IRgbFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<RgbFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<IMainFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<MainFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<IRotationFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<RotationFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<IScalingFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<ScalingFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<ITransformationFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<TransformationFormEventBinderWrapper>(
                        builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterTransient<ISettingsFormEventBinderWrapper>(factory =>
                    Substitute.ForPartsOf<SettingsFormEventBinderWrapper>(
                    builder.Resolve<IEventAggregatorWrapper>()))
                .RegisterSingleton<IMainView>(factory =>
                    Substitute.ForPartsOf<MainFormWrapper>(
                        builder.Resolve<IMainFormEventBinderWrapper>(),
                        builder.Resolve<IUndoRedoServiceWrapper>(),
                        builder.Resolve<IMenuStateFactoryWrapper>()))
                .RegisterTransient<IColorMatrixView>(factory =>
                    Substitute.ForPartsOf<ColorMatrixFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<IColorMatrixFormEventBinderWrapper>()))
                .RegisterTransient<IConvolutionView>(factory =>
                    Substitute.ForPartsOf<ConvolutionFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<IConvolutionFormEventBinderWrapper>()))
                .RegisterTransient<IDistributionView>(factory =>
                    Substitute.ForPartsOf<DistributionFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<IDistributionFormEventBinderWrapper>()))
                .RegisterTransient<IRgbView>(factory =>
                    Substitute.ForPartsOf<RgbFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<IRgbFormEventBinderWrapper>()))
                .RegisterTransient<IRotationView>(factory =>
                    Substitute.ForPartsOf<RotationFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<IRotationFormEventBinderWrapper>()))
                .RegisterTransient<IScalingView>(factory =>
                    Substitute.ForPartsOf<ScalingFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<IScalingFormEventBinderWrapper>()))
                .RegisterSingleton<ISettingsView>(factory =>
                    Substitute.ForPartsOf<SettingsFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<ISettingsFormEventBinderWrapper>()))
                .RegisterTransient<ITransformationView>(factory =>
                    Substitute.ForPartsOf<TransformationFormWrapper>(
                        builder.Resolve<IMainView>(),
                        builder.Resolve<ITransformationFormEventBinderWrapper>()));
        }
    }
}
