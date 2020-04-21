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
        {
            _size = size;
        }

        public bool Any()
        {
            lock (_stack)
            {
               return _stack.Any();
            }
        }

        public T Pop()
        {
            lock (_stack)
            {
                try
                {
                    var result = _stack.First;

                    _stack.RemoveFirst();

                    return result.Value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new InvalidOperationException("The stack is empty.");
                }
            }
        }

        public void Push(T bmp)
        {
            lock (_stack)
            {
                if (_stack.Count == 10)
                {
                    _stack.RemoveLast();
                }

                _stack.AddFirst(bmp);
            }
        }

        public T Peek()
        {
            lock (_stack)
            {
                try
                {
                    return _stack.First.Value;
                }
                catch (InvalidOperationException)
                {
                    throw new IndexOutOfRangeException("The stack is empty.");
                }
            }
        }
    }
}
