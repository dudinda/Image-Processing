using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Win.Models.Options;
using ImageProcessing.App.Domain.Win.Models.Wrapper;

namespace ImageProcessing.App.Domain.Services.StaTask
{
    /// <inheritdoc cref="IStaTaskService"/>
    public sealed class StaTaskService : IStaTaskService
    {
        private readonly StaTaskOptions _options;

        /// <summary>
        /// Contains threads' ids which hold modal windows.
        /// </summary>
        private static HashSet<int> _pool = new HashSet<int>();

        public StaTaskService(StaTaskOptions options)
        {
            if (options.MaxNumberOfModals <= 0)
            {
                throw new ArgumentException(nameof(options.MaxNumberOfModals));
            }
            _options = options;
        }

        /// <inheritdoc/>
        public Task<TArg> StartSTATask<TArg>(Func<TArg> func)
            where TArg : class
        {
            var tcs = new TaskCompletionSource<TArg>();
           
            var thread = new Thread(() =>
            {
                var id = CurrentThread.GetId();

                try
                {
                    _pool.Add(id);
                    tcs.SetResult(func());
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
                finally
                {
                    _pool.Remove(id);
                }
            });

            thread.SetApartmentState(ApartmentState.STA);
           
            if(_pool.Count > _options.MaxNumberOfModals)
            {
                tcs.SetResult(default(TArg)!);
                return tcs.Task;
            }

            thread.Start();

            return tcs.Task;
        }

        /// <inheritdoc/>
        public Task StartSTATask(Action func)
        {
            var tcs = new TaskCompletionSource<object>();

            var thread = new Thread(() =>
            {
                var id = CurrentThread.GetId();
                try
                {
                    _pool.Add(id);
                    func();
                    tcs.SetResult(null!);
                }
                catch (Exception e)
                {
                    tcs.SetException(e);
                }
                finally
                {
                    _pool.Remove(id);
                }
            });

            thread.SetApartmentState(ApartmentState.STA);

            if (_pool.Count > _options.MaxNumberOfModals)
            {
                tcs.SetResult(null!);
                return tcs.Task;
            }

            thread.Start();
            
            return tcs.Task;
        }

        /// <summary>
        /// Close all modal windows belonging
        /// to the pool.
        /// </summary>
        public void Dispose()
        {
            foreach(var threadId in _pool)
            {
                Dialog.Close(threadId);
            }
        }
    }
}
