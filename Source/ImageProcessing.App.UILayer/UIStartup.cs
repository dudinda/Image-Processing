using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer;
using ImageProcessing.App.PresentationLayer.Views.ColorMatrix;
using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.PresentationLayer.Views.Settings;
using ImageProcessing.App.PresentationLayer.Views.Transformation;
using ImageProcessing.App.UILayer.Form.ColorMatrix;
using ImageProcessing.App.UILayer.Form.Convolution;
using ImageProcessing.App.UILayer.Form.Distribution;
using ImageProcessing.App.UILayer.Form.Histogram;
using ImageProcessing.App.UILayer.Form.Main;
using ImageProcessing.App.UILayer.Form.QualityMeasure;
using ImageProcessing.App.UILayer.Form.Rgb;
using ImageProcessing.App.UILayer.Form.Settings;
using ImageProcessing.App.UILayer.Form.Transformation;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Implementation;
using ImageProcessing.App.UILayer.FormEventBinder.ColorMatrix.Interface;
using ImageProcessing.App.UILayer.FormEventBinder.Settings.Implementation;
using ImageProcessing.App.UILayer.FormEventBinder.Settings.Interface;
using ImageProcessing.App.UILayer.FormEventBinder.Transformation.Implementation;
using ImageProcessing.App.UILayer.FormEventBinder.Transformation.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainContainer.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormUndoRedo.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Implementation;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.UILayer
{
    public sealed class UIStartup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new PresentationStartup().Build(builder);

            builder
                .RegisterSingletonView<IMainView, MainForm>()
                .RegisterTransientView<IHistogramView, HistogramForm>()
                .RegisterTransientView<IConvolutionView, ConvolutionForm>()
                .RegisterTransientView<IRgbView, RgbForm>()
                .RegisterSingletonView<ISettingsView, SettingsForm>()
                .RegisterSingletonView<IQualityMeasureView, QualityMeasureForm>()
                .RegisterTransient<IDistributionView, DistributionForm>()
                .RegisterTransient<IColorMatrixView, ColorMatrixForm>()
                .RegisterTransient<ITransformationView, TransformationForm>()
                .RegisterTransient<IRgbFormEventBinder, RgbFormEventBinder>()
                .RegisterTransient<IColorMatrixEventBinder, ColorMatrixEventBinder>()
                .RegisterTransient<IConvolutionFormEventBinder, ConvolutionFormEventBinder>()
                .RegisterTransient<IDistributionFormEventBinder, DistributionFormEventBinder>()
                .RegisterTransient<ISettingsFormEventBinder, SettingsFormEventBinder>()
                .RegisterTransient<ITransformationFormEventBinder, TransformationFormEventBinder>()
                .RegisterTransient<IMainFormEventBinder, MainFormEventBinder>()
                .RegisterTransient<IMainFormContainerFactory, MainFormContainerFactory>()
                .RegisterTransient<IMainFormUndoRedoFactory, MainFormUndoRedoFactory>()
                .RegisterTransient<IMainFormZoomFactory, MainFormZoomFactory>();
        }      
    }
}
