using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer;
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

namespace ImageProcessing.App.UILayer
{
    public sealed class UIStartup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new Startup().Build(builder);

            builder
                .RegisterSingleton<IMainView, MainForm>()
                .RegisterSingleton<ISettingsView, SettingsForm>()
                .RegisterSingleton<IQualityMeasureView, QualityMeasureForm>()
                .RegisterTransient<IHistogramView, HistogramForm>()
                .RegisterTransient<IConvolutionView, ConvolutionForm>()
                .RegisterTransient<IRgbView, RgbForm>()
                .RegisterTransient<IRotationView, RotationForm>()
                .RegisterTransient<IScalingView, ScalingForm>()
                .RegisterTransient<IDistributionView, DistributionForm>()
                .RegisterTransient<IColorMatrixView, ColorMatrixForm>()
                .RegisterTransient<ITransformationView, TransformationForm>()
                .RegisterTransient<IRgbFormEventBinder, RgbFormEventBinder>()
                .RegisterTransient<IColorMatrixEventBinder, ColorMatrixEventBinder>()
                .RegisterTransient<IConvolutionFormEventBinder, ConvolutionFormEventBinder>()
                .RegisterTransient<IDistributionFormEventBinder, DistributionFormEventBinder>()
                .RegisterTransient<ISettingsFormEventBinder, SettingsFormEventBinder>()
                .RegisterTransient<ITransformationFormEventBinder, TransformationFormEventBinder>()
                .RegisterTransient<IRotationFormEventBinder, RotationFormEventBinder>()
                .RegisterTransient<IScalingFormEventBinder, ScalingFormEventBinder>()
                .RegisterTransient<IMainFormEventBinder, MainFormEventBinder>()
                .RegisterTransient<IMainFormContainerFactory, MainFormContainerFactory>()
                .RegisterTransient<IMainFormUndoRedoFactory, MainFormUndoRedoFactory>()
                .RegisterTransient<IMainFormZoomFactory, MainFormZoomFactory>()
                .RegisterTransient<IMainFormRotationFactory, MainFormRotationFactory>();
        }      
    }
}
