using System;
using System.Collections.Concurrent;
using System.Threading;

using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation
{
    public sealed class PipelineBlock : IPipelineBlock
    {
        private readonly ConcurrentQueue<IBlockItem> _block
            = new ConcurrentQueue<IBlockItem>();

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
                    throw new ArgumentException(
                        "Function output - input types don't match in the pipeline block."
                    );
                }
            }

            return result;          
        }

        public IPipelineBlock Add<TIn, TOut>(Func<TIn, TOut> step)
        {
            _block.Enqueue(
                    new BlockItem(
                            result => step.Invoke(
                                (TIn)(object)result), typeof(TIn), typeof(TOut)
                             )
                    );

            return this;
        }
    }
}
