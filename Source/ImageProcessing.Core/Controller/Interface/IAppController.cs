using ImageProcessing.Core.Presenter;
using ImageProcessing.Core.View;

namespace ImageProcessing.Core.Controller.Interface
{
    public interface IAppController
    {
        IAppController RegisterView<TView, TImplementation>()
                where TImplementation : class, TView
                where TView : IView;

        IAppController RegisterInstance<TArgument>(TArgument instance);

        IAppController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        IAppController RegisterSingletonService<TService, TImplementation>()
          where TImplementation : class, TService;

        IAppController RegisterNamedSingletonService<TService, TImplementation>(string name)
          where TImplementation : class, TService;

        IAppController EnableAnnotatedConstructorInjection();

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;
    }
}
