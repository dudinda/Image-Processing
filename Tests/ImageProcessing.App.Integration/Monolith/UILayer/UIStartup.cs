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
using ImageProcessing.App.PresentationLayer.IntegrationTests.Monolith.ServiceLayer;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Forms;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormEventBinders.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rotation.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Scaling.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Settings.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Transformation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

using NSubstitute;

namespace ImageProcessing.App.Integration.Monolith.UILayer
{
    internal sealed class UIStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            new ServiceStartup().Build(builder);

            builder
                .RegisterTransientInstance<IColorMatrixFormEventBinderWrapper>(
                Substitute.ForPartsOf<ColorMatrixFormEventBinderWrapper>(
                    builder.Resolve<IColorMatrixFormEventBinder>()))
                .RegisterTransientInstance<IConvolutionFormEventBinderWrapper>(
                Substitute.ForPartsOf<ConvolutionFormEventBinderWrapper>(
                    builder.Resolve<IConvolutionFormEventBinder>()))
                .RegisterTransientInstance<IDistributionFormEventBinderWrapper>(
                Substitute.ForPartsOf<DistributionFormEventBinderWrapper>(
                    builder.Resolve<IDistributionFormEventBinder>()))
                .RegisterTransientInstance<IRgbFormEventBinderWrapper>(
                Substitute.ForPartsOf<RgbFormEventBinderWrapper>(
                    builder.Resolve<IRgbFormEventBinder>()))
                .RegisterTransientInstance<IMainFormEventBinderWrapper>(
                Substitute.ForPartsOf<MainFormEventBinderWrapper>(
                    builder.Resolve<IMainFormEventBinder>()))
                .RegisterTransientInstance<IRotationFormEventBinderWrapper>(
                Substitute.ForPartsOf<RotationFormEventBinderWrapper>(
                    builder.Resolve<IRotationFormEventBinder>()))
                .RegisterTransientInstance<IScalingFormEventBinderWrapper>(
                Substitute.ForPartsOf<ScalingFormEventBinderWrapper>(
                    builder.Resolve<IScalingFormEventBinder>()))
                .RegisterTransientInstance<ITransformationFormEventBinderWrapper>(
                Substitute.ForPartsOf<TransformationFormEventBinderWrapper>(
                    builder.Resolve<ITransformationFormEventBinder>()))
                .RegisterTransientInstance<ISettingsFormEventBinderWrapper>(
                Substitute.ForPartsOf<SettingsFormEventBinderWrapper>(
                    builder.Resolve<ISettingsFormEventBinder>()))
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
                .RegisterTransientInstance<IMainView>(
                Substitute.ForPartsOf<MainFormWrapper>(
                    builder.Resolve<IMainFormEventBinderWrapper>(),
                    builder.Resolve<IMainFormContainerFactoryWrapper>(),
                    builder.Resolve<IMainFormUndoRedoFactoryWrapper>(),
                    builder.Resolve<IMainFormZoomFactoryWrapper>(),
                    builder.Resolve<IMainFormRotationFactoryWrapper>()));
        }
    }
}
