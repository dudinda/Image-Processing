using System;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Win.Models.Options;
using ImageProcessing.App.Domain.Win.Services.StaTask;
using ImageProcessing.App.Integration.Monolith.Domain.Services.StaTask.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.StaTask.Implementation
{
    internal class StaTaskServiceWrapper : IStaTaskServiceWrapper
    {
        private readonly StaTaskService _service;
        public StaTaskServiceWrapper(StaTaskOptions options)
        {
            _service = new StaTaskService(options);
        }

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
