using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.Views;
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
using ImageProcessing.App.UILayer.Services.Factories.MenuState;
using ImageProcessing.App.UILayer.Services.Factories.MenuState.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.ColorMatrix;
using ImageProcessing.App.UILayer.Services.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Convolution;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Distribution;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Main;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Rgb;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Rotation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Rotation.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Scaling;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Settings;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Transformation;
using ImageProcessing.App.UILayer.Services.FormEventBinders.Transformation.Implementation;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.UILayer
{
    public sealed class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new PresentationLayer.Startup().Build(builder);

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
                .RegisterTransient<IColorMatrixFormEventBinder, ColorMatrixFormEventBinder>()
                .RegisterTransient<IConvolutionFormEventBinder, ConvolutionFormEventBinder>()
                .RegisterTransient<IDistributionFormEventBinder, DistributionFormEventBinder>()
                .RegisterTransient<ISettingsFormEventBinder, SettingsFormEventBinder>()
                .RegisterTransient<ITransformationFormEventBinder, TransformationFormEventBinder>()
                .RegisterTransient<IRotationFormEventBinder, RotationFormEventBinder>()
                .RegisterTransient<IScalingFormEventBinder, ScalingFormEventBinder>()
                .RegisterTransient<IMainFormEventBinder, MainFormEventBinder>()
                .RegisterTransient<IMenuStateFactory, MenuStateFactory>();
        }
    }
}
