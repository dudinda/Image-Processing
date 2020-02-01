using System;

using ImageProcessing.Core.Pipeline.BlockItem.Interface;

namespace ImageProcessing.Core.Pipeline.BlockItem.Implementation
{
    internal class Item : IItem
    {
        public Type InputType { get; }
        public Type OutputType { get; }

        private readonly Func<object, object> _step;

        public Item(Func<object, object> step, Type typeIn, Type typeOut)
        {

            _step = step ?? throw new ArgumentNullException(nameof(_step));

            InputType = typeIn ?? throw new ArgumentNullException(nameof(typeIn));
            OutputType = typeOut ?? throw new ArgumentNullException(nameof(typeOut));
        }

        public object Execute(object arg)
            => _step(arg);
    }
}
