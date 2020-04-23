using System;
using System.Linq.Expressions;

using ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline.Item.Implementation.Action
{
    internal sealed class ActionBlockItem : IBlockItem
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        private readonly Expression<Action<object>> _step;

        public ActionBlockItem(Expression<Action<object>> step)
        {
            _step = step;
            InputType = _step.Parameters[0].Type;
            OutputType = _step.ReturnType;
        }

        public object Execute(object arg)
        {
            _step.Compile().Invoke(arg);

            return arg;
        }       
    }
}
