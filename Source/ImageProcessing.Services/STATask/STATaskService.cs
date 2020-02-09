using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.Common.Interop;
using ImageProcessing.Core.Service.STATask;

namespace ImageProcessing.Services.STATask
{
    public class STATaskService : ISTATaskService
    { 
        /// <summary>
        /// Contains threads' ids which hold 
        /// </summary>
        private static List<int> _pool = new List<int>();

        public Task<TArg> StartSTATask<TArg>(Func<TArg> func)
            where TArg : class
        {
            var tcs = new TaskCompletionSource<TArg>();
           
            var thread = new Thread(() =>
            {
                var id = CurentThread.GetId();

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
           
            if(_pool.Count > 4)
            {
                tcs.SetResult(default(TArg));
                return tcs.Task;
            }

            _pool.Add(thread.ManagedThreadId);
            thread.Start();

            return tcs.Task;
        }

        public Task StartSTATask(Action func)
        {
            var tcs = new TaskCompletionSource<object>();

            var thread = new Thread(() =>
            {
                var id = CurentThread.GetId();
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

            if (_pool.Count > 4)
            {
                tcs.SetResult(null);
                return tcs.Task;
            }

            _pool.Add(thread.ManagedThreadId);

            thread.Start();
            
            return tcs.Task;
        }

        public void Dispose()
        {
            foreach(var threadId in _pool)
            {
                Dialog.Close(threadId);
            }

        }
    }
}
