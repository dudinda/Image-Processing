using System;
using System.Linq.Expressions;

using ImageProcessing.App.CommonLayer.Helpers;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation
{
    internal sealed class ActionItem : ILambdaItem
    {
        private readonly Expression<Action<object>> _step;

        public ActionItem(Expression<Action<object>> step)
        {
            _step = Requires.IsNotNull(
                step, nameof(step));

            InputType = _step.Parameters[0].GetType();
            OutputType = typeof(void);
        }

        public Type InputType { get; }

        public Type OutputType { get; }

        public void Execute(object arg)
            => _step.Compile().Invoke(arg);

        object ILambdaItem.Execute(object arg)
        {
            throw new NotImplementedException();
        }
    }
}
