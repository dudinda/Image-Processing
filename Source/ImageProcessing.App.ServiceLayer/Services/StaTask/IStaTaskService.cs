using System;
using System.Threading.Tasks;

namespace ImageProcessing.App.ServiceLayer.Services.StaTask
{
    /// <summary>
    /// Provides functionality to run the
    /// specified work in the single-threaded
    /// apartment state. Mainly used to run
    /// non-blocking modal windows.
    /// </summary>
    public interface IStaTaskService : IDisposable
    {
        /// <summary>
        /// Start the specified work
        /// as a STA task. Returns <typeparamref name="TResult"/>
        /// upon the completion.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        Task<TResult> StartSTATask<TResult>(Func<TResult> func) 
            where TResult : class;

        /// <summary>
        /// Start the specified work
        /// as a STA task.
        /// </summary>
        Task StartSTATask(Action func);
    }
}
