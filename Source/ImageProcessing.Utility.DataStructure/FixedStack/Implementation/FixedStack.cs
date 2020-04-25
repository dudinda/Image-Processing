using System;
using System.Collections.Generic;
using System.Linq;

using ImageProcessing.Utility.DataStructure.FixedStack.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStack.Implementation
{
    public sealed class FixedStack<T> : IFixedStack<T>
    {
        private readonly LinkedList<T> _stack = new LinkedList<T>();
        private readonly int _size;

        public FixedStack(int size)
            => _size = size;

        public bool Any()
            => _stack.Any();


        public T Pop()
        {
            var result = _stack.First;

            _stack.RemoveFirst();

            return result.Value;
        }

        public void Push(T bmp)
        {
            if (_stack.Count == _size)
            {
                _stack.RemoveLast();
            }

            _stack.AddFirst(bmp);
        }

        public T Peek()
        {
            if (Any())
            {
                return _stack.First.Value;
            }

            throw new InvalidOperationException("The stack is empty.");
        }
    }
}
