using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components
{
    internal sealed  class MainFormEventBinderFake : MainFormEventBinder, IMainFormEventBinder
    {
        public MainFormEventBinderFake(IEventAggregatorFake aggregator)
            : base(aggregator) { }
    }
}
