using System;
using System.Linq.Expressions;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation
{
    internal sealed class FuncItem : ILambdaItem
    {
        private readonly Expression<Func<object, object>> _step;

        public FuncItem(Expression<Func<object, object>> step)
        {
            _step = Requires.IsNotNull(
                step, nameof(step));

            InputType = _step.Parameters[0].GetType();
            OutputType = _step.ReturnType; 
        }

        public Type InputType { get; }

        public Type OutputType { get; }

        public object Execute(object arg)
            => _step.Compile().Invoke(arg);
    }
}
