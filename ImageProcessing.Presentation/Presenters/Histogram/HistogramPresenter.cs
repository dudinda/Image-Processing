using ImageProcessing.Presentation.Presenters.Base.Abstract;
using ImageProcessing.Presentation.Views.Histogram;
using ImageProcessing.Presentation.AppController;

namespace ImageProcessing.Presentation.Presenters
{
    public class HistogramPresenter : BasePresenter<IHistogramView>
    {
        public HistogramPresenter(IAppController controller, IHistogramView view) : base(controller, view)
        {

        }
    }
}
