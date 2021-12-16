using System;
using System.Threading.Tasks;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Interface;
using ImageProcessing.App.ServiceLayer.Services.StaTask;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.StaTask.Implementation
{
    internal class StaTaskServiceWrapper : IStaTaskServiceWrapper
    {
        private readonly StaTaskService _service =
            new StaTaskService();
        public virtual void Dispose()
            => _service.Dispose();
        
        public virtual Task<TResult> StartSTATask<TResult>(Func<TResult> func) where TResult : class
        {
            return Task.FromResult(func());
        }

        public virtual Task StartSTATask(Action func)
        {
            func();
            return Task.CompletedTask;
        }
    }
}
