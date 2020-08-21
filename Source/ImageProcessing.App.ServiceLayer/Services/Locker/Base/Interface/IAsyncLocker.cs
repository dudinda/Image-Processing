using System;
using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Services.Locker.Base.Interface
{
    /// <summary>
    /// Lock async the specified operation.
    /// Mainly used to perform a non - blocking deep copy 
    /// of the selected bitmap or to retrieve the actual copy
    /// during the application flow.
    /// </summary>
    internal interface IAsyncLocker
    {
        /// <summary>
        /// Lock async during the specified work.
        /// Returns the <typeparamref name="TResult"/>.
        /// </summary>
        Task<TResult> LockAsync<TResult>(Func<TResult> worker);

        /// <summary>
        /// Lock async during the specified action.
        /// </summary>
        Task LockAsync(Action worker);
    }
}
