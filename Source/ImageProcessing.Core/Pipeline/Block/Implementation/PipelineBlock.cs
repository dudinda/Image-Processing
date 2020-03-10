using System;
using System.Collections.Concurrent;
using System.Threading;

using ImageProcessing.Core.Pipeline.BlockItem.Implementation;
using ImageProcessing.Core.Pipeline.BlockItem.Interface;

namespace ImageProcessing.Core.Pipeline.Block.Implementation
{
    public class PipelineBlock : IPipelineBlock
    {
        private readonly ConcurrentQueue<IItem> _block = new ConcurrentQueue<IItem>();

        private object _item;
        private Type _itemType;

        public PipelineBlock(object item)
        {
            _item = item;
            _itemType = item.GetType();
        }

        public object Process(CancellationToken _token)
        {
            var result = _item;

            var firstArg = _itemType;

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

            return result;          
        }

        public IPipelineBlock Add<TIn, TOut>(Func<TIn, TOut> step)
        {
            _block.Enqueue(new Item(result => step.Invoke((TIn)(object)result), typeof(TIn), typeof(TOut)));
            return this;
        }
    }
}
