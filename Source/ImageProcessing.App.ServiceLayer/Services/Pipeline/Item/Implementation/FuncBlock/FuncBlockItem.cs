using System;
using System.Linq.Expressions;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation
{
    internal sealed class FuncBlockItem : IBlockItem
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        private readonly Expression<Func<object, object>> _step;

        public FuncBlockItem(Expression<Func<object, object>> step)
        {
            _step = Requires.IsNotNull(
                step, nameof(step));

            InputType  = _step.Parameters[0].Type;
            OutputType = _step.ReturnType;
        }

        public object Execute(object arg)
            => _step.Compile().Invoke(arg);
    }
}
