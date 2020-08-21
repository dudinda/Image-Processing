using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.Views.Convolution;
using ImageProcessing.App.PresentationLayer.Views.Distribution;
using ImageProcessing.App.PresentationLayer.Views.Histogram;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.PresentationLayer.Views.QualityMeasure;
using ImageProcessing.App.PresentationLayer.Views.Rgb;
using ImageProcessing.App.ServiceLayer;
using ImageProcessing.App.UILayer.Form.Convolution;
using ImageProcessing.App.UILayer.Form.Distribution;
using ImageProcessing.App.UILayer.Form.Histogram;
using ImageProcessing.App.UILayer.Form.Main;
using ImageProcessing.App.UILayer.Form.QualityMeasure;
using ImageProcessing.App.UILayer.Form.Rgb;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Destination.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.Container.Source.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Redo.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Redo.Interface;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Undo.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Main.UndoRedo.Undo.Interface;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormCommands.Rgb.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Convolution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Distribution.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Rgb.Interface;
using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.App.UILayer
{
    internal class Startup : IStartup
    {
        public void Build(IDependencyResolution builder)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ServiceGateway.Build(builder);

            builder
                .RegisterSingletonView<IMainView, MainForm>()
                .RegisterTransientView<IHistogramView, HistogramForm>()
                .RegisterTransientView<IConvolutionView, ConvolutionForm>()
                .RegisterTransientView<IRgbView, RgbForm>()
                .RegisterSingletonView<IQualityMeasureView, QualityMeasureForm>()
                .RegisterTransient<IDistributionView, DistributionForm>()          
                .RegisterTransient<IRgbFormEventBinder, RgbFormEventBinder>()
                .RegisterTransient<IConvolutionFormEventBinder, ConvolutionFormEventBinder>()
                .RegisterTransient<IDistributionFormEventBinder, DistributionFormEventBinder>()
                .RegisterTransient<IMainFormEventBinder, MainFormEventBinder>()
                .RegisterTransient<IMainFormCommand, MainFormCommand>()
                .RegisterTransient<IMainFormRedoCommand, MainFormRedoCommand>()
                .RegisterTransient<IMainFormUndoCommand, MainFormUndoCommand>()
                .RegisterTransient<IMainFormSourceContainerCommand, MainFormSourceContainerCommand>()
                .RegisterTransient<IMainFormDestinationContainerCommand, MainFormDestinationContainerCommand>()
                .RegisterTransient<IRgbFormCommand, RgbFormCommand>();
        }      
    }
}
