using System.Windows.Forms;

using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Forms.ColorMatrix;
using ImageProcessing.App.UI.Forms.Convolution;
using ImageProcessing.App.UI.Forms.Distribution;
using ImageProcessing.App.UI.Forms.Histogram;
using ImageProcessing.App.UI.Forms.Main;
using ImageProcessing.App.UI.Forms.QualityMeasure;
using ImageProcessing.App.UI.Forms.Rgb;
using ImageProcessing.App.UI.Forms.Rotation;
using ImageProcessing.App.UI.Forms.Scaling;
using ImageProcessing.App.UI.Forms.Settings;
using ImageProcessing.App.UI.Forms.Transformation;
using ImageProcessing.App.UI.Services.Factories.MenuState;
using ImageProcessing.App.UI.Services.Factories.MenuState.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.ColorMatrix;
using ImageProcessing.App.UI.Services.FormEventBinders.ColorMatrix.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Convolution;
using ImageProcessing.App.UI.Services.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Distribution;
using ImageProcessing.App.UI.Services.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Main;
using ImageProcessing.App.UI.Services.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Rgb;
using ImageProcessing.App.UI.Services.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Rotation;
using ImageProcessing.App.UI.Services.FormEventBinders.Rotation.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Scaling;
using ImageProcessing.App.UI.Services.FormEventBinders.Scaling.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Settings;
using ImageProcessing.App.UI.Services.FormEventBinders.Settings.Implementation;
using ImageProcessing.App.UI.Services.FormEventBinders.Transformation;
using ImageProcessing.App.UI.Services.FormEventBinders.Transformation.Implementation;
using ImageProcessing.Microkernel.Models.AppConfig;
using ImageProcessing.Microkernel.MVP.Services.Providers;

namespace ImageProcessing.App.UI
{
    public sealed class Startup : IStartup
    {
        public void Build(IComponentProvider builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new Presentation.Startup().Build(builder);

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
