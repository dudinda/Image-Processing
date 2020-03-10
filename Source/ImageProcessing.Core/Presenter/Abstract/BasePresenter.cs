
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Controller.Interface;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.Presenter.Abstract
{
    public abstract class BasePresenter<TView> : IPresenter
		where TView : class, IView
	{
		protected TView View { get; }
		protected IAppController Controller { get; }
        protected IAwaitablePipeline Pipeline { get; }

		protected BasePresenter(IAppController controller, TView view, IAwaitablePipeline pipeline)
		{
			Controller = Requires.IsNotNull(controller, nameof(controller));
			View       = Requires.IsNotNull(view, nameof(view));
            Pipeline   = Requires.IsNotNull(pipeline, nameof(pipeline));
		}

		public virtual void Run() => View.Show();
	}

	public abstract class BasePresenter<TView, TViewModel> : IPresenter<TViewModel>
		where TView : class, IView
		where TViewModel : class
	{
		protected TView View { get; }
		protected IAppController Controller { get; }
        protected IAwaitablePipeline Pipeline { get; }
        protected TViewModel ViewModel { get; private set; }
       
        protected BasePresenter(IAppController controller, TView view, IAwaitablePipeline pipeline)
		{
            Controller = Requires.IsNotNull(controller, nameof(controller));
            View       = Requires.IsNotNull(view, nameof(view));
            Pipeline   = Requires.IsNotNull(pipeline, nameof(pipeline));
        }

		public virtual void Run(TViewModel vm)
		{
			ViewModel = Requires.IsNotNull(vm, nameof(vm));
			View.Show();
		}
	}
}
