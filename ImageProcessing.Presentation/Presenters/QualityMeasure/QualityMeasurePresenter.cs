using ImageProcessing.Presentation.Presenters.Base.Abstract;
using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.Presentation.AppController;

namespace ImageProcessing.Presentation.Presenters
{
    public class QualityMeasurePresenter : BasePresenter<IQualityMeasureView>
    {
        public QualityMeasurePresenter(IAppController controller, IQualityMeasureView view) : base(controller, view)
        {

        }
    }
}
