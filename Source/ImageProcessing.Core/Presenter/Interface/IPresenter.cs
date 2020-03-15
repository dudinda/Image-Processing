using ImageProcessing.Core.Presenter.Abstract;

namespace ImageProcessing.Core.Presenter
{
    /// <summary>
    /// Represents the base behavior of
    /// the <see cref="BasePresenter{TView}"/>.
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
    /// the <see cref="BasePresenter{TView, TViewModel}"/>.
    /// </summary>
    /// <typeparam name="TViewModel"></typeparam>
    public interface IPresenter<in TViewModel>
        where TViewModel : class
    {
        /// <summary>
        /// Run a presenter with a specified
        /// <see cref="TViewModel"/>.
        /// </summary>
        void Run(TViewModel argument);
    }

}
