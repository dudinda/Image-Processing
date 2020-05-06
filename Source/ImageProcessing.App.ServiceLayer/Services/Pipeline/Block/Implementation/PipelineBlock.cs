using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Threading;

using ImageProcessing.App.CommonLayer.Extensions.ExpressionExt;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation.Action;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation
{
    public sealed class PipelineBlock : IPipelineBlock
    {
        private readonly ConcurrentQueue<IBlockItem> _block
            = new ConcurrentQueue<IBlockItem>();

        private readonly object _blockItem;

        public PipelineBlock(object blockItem)
            => _blockItem = blockItem;

        public object Process(CancellationToken _token)
        {
            var result = _blockItem;
            var firstArg = _blockItem.GetType();

            while(_block.TryDequeue(out var function))
            {
                _token.ThrowIfCancellationRequested();
                
                if(function.OutputType == typeof(void) &&
                   function.InputType.IsAssignableFrom(firstArg))
                {
                    firstArg = function.InputType;
                    result = function.Execute(result);
                }
                else if (function.InputType.IsAssignableFrom(firstArg))
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

        public IPipelineBlock Add<TIn, TOut>(Expression<Func<TIn, TOut>> step)
        {
            _block.Enqueue(
                new FuncBlockItem(
                    step.ConvertFunction()
                )
            );

            return this;
        }

        public IPipelineBlock Add<TIn>(Expression<Action<TIn>> step)
        {
            _block.Enqueue(
                new ActionBlockItem(
                    step.ConvertFunction()
                )
            );

            return this;
        }

    }
}
