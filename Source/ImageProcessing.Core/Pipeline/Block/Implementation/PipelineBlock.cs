using System;
using System.Collections.Concurrent;

namespace ImageProcessing.Core.Pipeline
{
    public class PipelineBlock<TOutput> : IPipelineBlock<TOutput> 
        where TOutput : class
    {
        private readonly ConcurrentQueue<Func<object, object>> _block = new ConcurrentQueue<Func<object, object>>();

        private TOutput _item;


        public PipelineBlock(TOutput item)
        {
            _item = item;
        }

        public TOutput Process()
        {
            object result = _item as object;

            while(_block.TryDequeue(out var function))
            {
                result = function(result);
            }

            return result as TOutput;
            
        }

        public void Add<TStepIn, TStepOut>(Func<TStepIn, TStepOut> step)
        {
            _block.Enqueue(result => step.Invoke((TStepIn)(object)result));
        }
    }
}
