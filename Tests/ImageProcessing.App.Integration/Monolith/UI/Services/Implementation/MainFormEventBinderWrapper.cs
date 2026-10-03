using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Main.Interface;
using ImageProcessing.App.Presentation.UnitTests.Fakes.Components;
using ImageProcessing.App.UI.Services.FormEventBinders.Main.Implementation;
using ImageProcessing.App.UI.Services.FormExposers;

namespace ImageProcessing.App.Integration.Monolith.UI.FormEventBinders.Main.Implementation
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
