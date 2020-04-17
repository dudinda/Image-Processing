using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

namespace ImageProcessing.App.ServiceLayer.Services.StaTask.Implementation
{
    /// <inheritdoc cref="IStaTaskService"/>
    public sealed class StaTaskService : IStaTaskService
    {
        private readonly int _maxNumberOfModals;

        /// <summary>
        /// Contains threads' ids which hold modal windows.
        /// </summary>
        private static List<int> _pool = new List<int>();

        public StaTaskService() : this(4) { } 

        public StaTaskService(int maxNumberOfModals = 4)
        {
            if(maxNumberOfModals < 0)
            {
                throw new ArgumentException(nameof(maxNumberOfModals));
            }

            _maxNumberOfModals = maxNumberOfModals;
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
           
            if(_pool.Count > _maxNumberOfModals)
            {
                tcs.SetResult(default(TArg));
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
                    tcs.SetResult(null);
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

            if (_pool.Count > _maxNumberOfModals)
            {
                tcs.SetResult(null);
                return tcs.Task;
            }

            thread.Start();
            
            return tcs.Task;
        }

        /// <summary>
        /// Close all modal windows belonging
        /// to the pool on disposing.
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
