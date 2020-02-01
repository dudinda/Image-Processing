using System;
using System.Collections.Concurrent;
using System.Threading;
using ImageProcessing.Core.Pipeline.BlockItem.Implementation;
using ImageProcessing.Core.Pipeline.BlockItem.Interface;

namespace ImageProcessing.Core.Pipeline.Block.Implementation
{
    public class PipelineBlock<TOutput> : IPipelineBlock<TOutput> 
        where TOutput : class
    {
        private readonly ConcurrentQueue<IItem> _block = new ConcurrentQueue<IItem>();

        private TOutput _item;


        public PipelineBlock(TOutput item)
        {
            _item = item;
        }

        public TOutput Process(CancellationToken _token)
        {
            var result = _item as object;

            var firstArg = _item.GetType();

            while(_block.TryDequeue(out var function))
            {
                _token.ThrowIfCancellationRequested();
                
                if (function.InputType.IsAssignableFrom(firstArg))
                {
                    firstArg = function.OutputType;
                    result = function.Execute(result);
                }
                else
                {
                    throw new ArgumentException("Function output - input types don't match in the pipeline block.");
                }
            }

            return result as TOutput;          
        }

        public void Add<TIn, TOut>(Func<TIn, TOut> step)
        {
            _block.Enqueue(new Item(result => step.Invoke((TIn)(object)result), typeof(TIn), typeof(TOut)));
        }
    }
}
