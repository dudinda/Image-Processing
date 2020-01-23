namespace ImageProcessing.Core.Presenter
{
    public interface IPresenter
    {
        void Run();
    }

    public interface IPresenter<in TViewModel>
    {
        void Run(TViewModel argument);
    }

}
