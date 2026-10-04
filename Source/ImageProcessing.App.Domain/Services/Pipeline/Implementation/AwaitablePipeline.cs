using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ImageProcessing.App.Domain.Services.Pipeline.Implementation
{
    public class AwaitablePipeline : IAwaitablePipeline
    {
        private readonly BlockingCollection<Task<object>> _queue = new BlockingCollection<Task<object>>(32);
        private readonly CancellationTokenSource _source = new CancellationTokenSource();

        public bool Register(IPipelineBlock output)
        {
            var task = new Task<object>(() => output.Process(_source.Token), _source.Token);
            
            if (_queue.TryAdd(task))
            {
                task.Start();
                return true;
            }

            return false;
        }

        public async Task<object> AwaitResult()
        {
            if (_queue.TryTake(out var task))
            {
                return await task.ConfigureAwait(false);
            }

            throw new InvalidOperationException();
        }

        public bool Any()
            => _queue.Count > 0;

        public void Dispose()
        {
            _source.Cancel();
            _source.Dispose();
            _queue.Dispose();
        }
    }
}
