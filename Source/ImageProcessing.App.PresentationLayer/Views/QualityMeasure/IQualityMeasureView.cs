using ImageProcessing.Framework.Core.MVP.View;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.DataChart;

namespace ImageProcessing.App.PresentationLayer.Views.QualityMeasure
{
    /// <summary>
    /// Represents the base behavior of
    /// a quality measure window.
    /// </summary>
    public interface IQualityMeasureView : IView,
        IDataChart
    {

    }
}
