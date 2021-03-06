using System;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Interface;
using ImageProcessing.Utility.DataStructure.BlockingQueueSrc.Implementation;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Awaitable.Implementation
{
    public class AwaitablePipeline : IAwaitablePipeline
    {
        private protected readonly BlockingQueue<Task<object>> _queue
           = new BlockingQueue<Task<object>>(1 << 6);

        private protected readonly CancellationTokenSource _source 
            = new CancellationTokenSource();

        public virtual bool Register(IPipelineBlock output)
        {
            var task = new Task<object>(
                () => output.Process(_source.Token), _source.Token
            );
            
            if (_queue.TryEnqueue(task))
            {
                task.Start();
                return true;
            }

            return false;
        }

        public virtual async Task<object> AwaitResult()
        {
            if (_queue.TryDequeue(out var task))
            {
                return await task.ConfigureAwait(false);
            }

            throw new InvalidOperationException();
        }

        public virtual bool Any()
            => _queue.Any();

        public virtual void Dispose()
        {
            _source.Cancel();
            _source.Dispose();
            _queue.Dispose();
        }
    }
}
