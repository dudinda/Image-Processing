using System;
using System.Runtime.CompilerServices;

using ImageProcessing.Common.Helpers;
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
