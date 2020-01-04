using ImageProcessing.Presentation.Views.Base;
using ImageProcessing.Presentation.AppController;

namespace ImageProcessing.Presentation.Presenters.Base.Abstract
{
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IAppController Controller { get; private set; }

        protected BasePresenter(IAppController controller, TView view)
        {
            Controller = controller;
            View       = view;
        }

        public void Run()
        {
            View.Show();
        }
    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }
        protected IAppController Controller { get; private set; }

        protected BasePresenter(IAppController controller, TView view)
        {
            Controller = controller;
            View       = view;
        }

        public abstract void Run(TArg argument);
    }
}
