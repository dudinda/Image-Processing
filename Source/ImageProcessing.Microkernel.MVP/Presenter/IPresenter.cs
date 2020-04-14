namespace ImageProcessing.Microkernel.MVP.Presenter
{
    /// <summary>
    /// Represents the base behavior of
    /// a presenter.
    /// </summary>
    public interface IPresenter
    {
        /// <summary>
        /// Run a presenter.
        /// </summary>
        void Run();
    }

    /// <summary>
    /// Represents the base behavior of
    /// a presenter with a view model.
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public interface IPresenter<in TViewModel>
        where TViewModel : class
    {
        /// <summary>
        /// Run a presenter with the specified
        /// <see cref="TViewModel"/>.
        /// </summary>
        void Run(TViewModel argument);
    }

}
