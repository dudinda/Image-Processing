using ImageProcessing.Common.Adapters.LightInject;
using ImageProcessing.Core.AppController.Implementation;
using ImageProcessing.DomainModel.Services.ConvolutionFilter;
using ImageProcessing.DomainModel.Services.Distribution;
using ImageProcessing.DomainModel.Services.RGBFilter;
using ImageProcessing.Factory.Base;
using ImageProcessing.Form.Histogram;
using ImageProcessing.Form.Main;
using ImageProcessing.Form.QualityMeasure;
using ImageProcessing.Presentation.Presenters.Main;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.Presentation.Views.QualityMeasure;

using System;
using System.Windows.Forms;

namespace ImageProcessing
{
    internal static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new AppController(new LightInjectAdapter())
                .RegisterView<IMainView, MainForm>()
                .RegisterView<IHistogramView, HistogramForm>()
                .RegisterView<IQualityMeasureView, QualityMeasureForm>()
                .RegisterService<IBaseFactory, BaseFactory>()
                .RegisterService<IConvolutionFilterService, ConvolutionFilterService>()
                .RegisterService<IDistributionService, DistributionService>()
                .RegisterService<IRGBFilterService, RGBFilterService>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<MainPresenter>();
        }
    }
}
