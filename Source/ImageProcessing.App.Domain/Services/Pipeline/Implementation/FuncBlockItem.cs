using System;
using System.Linq.Expressions;

namespace ImageProcessing.App.Domain.Services.Pipeline.Implementation
{
    internal sealed class FuncBlockItem : IBlockItem
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        private readonly Expression<Func<object, object>> _step;

        public FuncBlockItem(Expression<Func<object, object>> step)
        {
            _step = step;
            InputType  = _step.Parameters[0].Type;
            OutputType = _step.ReturnType;
        }

        public object Execute(object arg)
            => _step.Compile().Invoke(arg);
    }
}
