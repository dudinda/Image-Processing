using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Implementation
{
    internal class MainFormEventBinderWrapper : IMainFormEventBinderWrapper
    {
        private readonly MainFormEventBinder _binder;

        public MainFormEventBinderWrapper(
            IEventAggregatorWrapper aggregator)
        {
            _binder = new MainFormEventBinder(aggregator);
        }

        public virtual void OnElementExpose(IMainFormExposer form)
        {
            _binder.OnElementExpose(form);
        }

        public virtual bool ProcessCmdKey(IMainFormExposer view, Keys keyData)
        {
            return _binder.ProcessCmdKey(view, keyData);
        }
    }
}
