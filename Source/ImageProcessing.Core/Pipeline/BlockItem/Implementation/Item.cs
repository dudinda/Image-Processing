using System;
using System.Runtime.CompilerServices;

using ImageProcessing.Core.Pipeline.BlockItem.Interface;

[assembly: InternalsVisibleTo("ImageProcessing.Tests")]
namespace ImageProcessing.Core.Pipeline.BlockItem.Implementation
{
    internal sealed class Item : IItem
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
