using System;

using ImageProcessing.Common.Helpers;
using ImageProcessing.ServiceLayer.Services.Pipeline.Item.Interface;

namespace ImageProcessing.ServiceLayer.Services.Pipeline.Item.Implementation
{
    internal sealed class BlockItem : IBlockItem
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        private readonly Func<object, object> _step;

        public BlockItem(Func<object, object> step, Type typeIn, Type typeOut)
        {
            _step = Requires.IsNotNull(
                step, nameof(step));
            InputType = Requires.IsNotNull(
                typeIn, nameof(typeIn));
            OutputType = Requires.IsNotNull(
                typeOut, nameof(typeOut) );
        }

        public object Execute(object arg)
            => _step(arg);
    }
}
