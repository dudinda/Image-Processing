using ImageProcessing.App.Integration.Monolith.PresentationLayer;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.Forms;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormContainer.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormContainer.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormRotation.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormRotation.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormUndoRedo.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormUndoRedo.Interface;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormZoom.Implementation;
using ImageProcessing.App.Integration.Monolith.UILayer.UIModel.Factories.MainFormZoom.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Transformation.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainContainer.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormUndoRedo.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.App.UILayer.Forms.ColorMatrix;
using ImageProcessing.App.UILayer.Forms.Convolution;
using ImageProcessing.App.UILayer.Forms.Distribution;
using ImageProcessing.App.UILayer.Forms.Histogram;
using ImageProcessing.App.UILayer.Forms.Main;
using ImageProcessing.App.UILayer.Forms.QualityMeasure;
using ImageProcessing.App.UILayer.Forms.Rgb;
using ImageProcessing.App.UILayer.Forms.Rotation;
using ImageProcessing.App.UILayer.Forms.Scaling;
using ImageProcessing.App.UILayer.Forms.Settings;
using ImageProcessing.App.UILayer.Forms.Transformation;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.UILayer
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
                .RegisterTransient<IMainFormContainerFactory, MainFormContainerFactory>()
                .RegisterTransient<IMainFormUndoRedoFactory, MainFormUndoRedoFactory>()
                .RegisterTransient<IMainFormZoomFactory, MainFormZoomFactory>()
                .RegisterTransient<IMainFormRotationFactory, MainFormRotationFactory>()
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
                .RegisterTransientInstance<IMainFormContainerFactoryWrapper>(
                Substitute.ForPartsOf<MainFormContainerFactoryWrapper>(
                    builder.Resolve<IMainFormContainerFactory>()))
                .RegisterTransientInstance<IMainFormRotationFactoryWrapper>(
                Substitute.ForPartsOf<MainFormRotationFactoryWrapper>(
                    builder.Resolve<IMainFormRotationFactory>()))
                .RegisterTransientInstance<IMainFormUndoRedoFactoryWrapper>(
                Substitute.ForPartsOf<MainFormUndoRedoFactoryWrapper>(
                    builder.Resolve<IMainFormUndoRedoFactory>()))
                .RegisterTransientInstance<IMainFormZoomFactoryWrapper>(
                Substitute.ForPartsOf<MainFormZoomFactoryWrapper>(
                    builder.Resolve<IMainFormZoomFactory>()))
                .RegisterSingletonInstance<IMainViewWrapper>(
                Substitute.ForPartsOf<MainFormWrapper>(
                    builder.Resolve<IMainFormEventBinderWrapper>(),
                    builder.Resolve<IMainFormContainerFactoryWrapper>(),
                    builder.Resolve<IMainFormUndoRedoFactoryWrapper>(),
                    builder.Resolve<IMainFormZoomFactoryWrapper>(),
                    builder.Resolve<IMainFormRotationFactoryWrapper>()))
                .RegisterTransientInstance<IColorMatrixViewWrapper>(
                Substitute.ForPartsOf<ColorMatrixFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<IColorMatrixFormEventBinderWrapper>()))
                .RegisterTransientInstance<IConvolutionView>(
                Substitute.ForPartsOf<ConvolutionFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<IConvolutionFormEventBinderWrapper>()))
                .RegisterTransientInstance<IDistributionViewWrapper>(
                Substitute.ForPartsOf<DistributionFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<IDistributionFormEventBinderWrapper>()))
                .RegisterTransientInstance<IRgbViewWrapper>(
                Substitute.ForPartsOf<RgbFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<IRgbFormEventBinderWrapper>()))
                .RegisterTransientInstance<IRotationViewWrapper>(
                Substitute.ForPartsOf<RotationFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<IRotationFormEventBinderWrapper>()))
                .RegisterTransientInstance<IScalingViewWrapper>(
                Substitute.ForPartsOf<ScalingFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<IScalingFormEventBinderWrapper>()))
                .RegisterSingletonInstance<ISettingsViewWrapper>(
                Substitute.ForPartsOf<SettingsFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<ISettingsFormEventBinderWrapper>()))
                .RegisterTransientInstance<ITransformationViewWrapper>(
                Substitute.ForPartsOf<TransformationFormWrapper>(
                    builder.Resolve<IMainViewWrapper>(),
                    builder.Resolve<ITransformationFormEventBinderWrapper>()));
        }
    }
}
