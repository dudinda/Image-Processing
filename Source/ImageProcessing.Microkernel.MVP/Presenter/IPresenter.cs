using System.Threading.Tasks;

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
        Task Run();
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
        Task Run(TViewModel argument);
    }

}
