using System;

using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.Presenter.Abstract
{
    public abstract class BasePresenter<TView> : IPresenter
		where TView : class, IView
	{
		protected TView View { get; }
		protected IAppController Controller { get; }

		protected BasePresenter(IAppController controller, TView view)
		{
			Controller = Requires.IsNotNull(controller, nameof(controller));
			View       = Requires.IsNotNull(view, nameof(view));
		}

		public virtual void Run() => View.Show();
	}

	public abstract class BasePresenter<TView, TViewModel> : IPresenter<TViewModel>
		where TView : class, IView
		where TViewModel : class
	{
		protected TView View { get; }
		protected IAppController Controller { get; }
		protected TViewModel ViewModel { get; private set; }

		protected BasePresenter(IAppController controller, TView view)
		{
            Controller = Requires.IsNotNull(controller, nameof(controller));
            View       = Requires.IsNotNull(view, nameof(view));
        }

		public virtual void Run(TViewModel vm)
		{
			ViewModel = Requires.IsNotNull(vm, nameof(vm));
			View.Show();
		}
	}
}
