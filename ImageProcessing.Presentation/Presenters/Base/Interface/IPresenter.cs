namespace ImageProcessing.Presentation.Presenters.Base
{
    public interface IPresenter
    {
        void Run();
    }

    public interface IPresenter<in TArg>
    {
        void Run(TArg argument);
    }

}
