using System;
using System.Threading.Tasks;

using ImageProcessing.Common.Utility.BlockingQueue.Implementation;
using ImageProcessing.Core.Pipeline.AwaitablePipeline.Interface;

namespace ImageProcessing.Core.Pipeline.AwaitablePipeline.Implementation
{
    public class AwaitablePipeline<TOutput> : IAwaitablePipeline<TOutput>
    {
        private readonly BlockingQueue<Task<TOutput>> _queue
           = new BlockingQueue<Task<TOutput>>(64);

        public bool Register(IPipelineBlock<TOutput> output)
        {
            var task = new Task<TOutput>(() => output.Process());

            if (_queue.TryEnqueue(task))
            {
                task.Start();
                return true;
            }

            return false;

        }

        public async Task<TOutput> AwaitResult()
        {
            if (_queue.TryDequeue(out var task))
            {
                return await task.ConfigureAwait(false);
            }

            throw new InvalidOperationException();
        }
    }
}
