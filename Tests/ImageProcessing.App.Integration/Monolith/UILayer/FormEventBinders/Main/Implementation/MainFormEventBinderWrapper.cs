using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;

namespace ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Implementation
{
    internal class MainFormEventBinderWrapper : IMainFormEventBinderWrapper
    {
        private readonly IMainFormEventBinder _binder;

        public MainFormEventBinderWrapper(
            IMainFormEventBinder binder)
        {
            _binder = binder;
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
