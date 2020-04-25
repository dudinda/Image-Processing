using System;
using System.Collections.Generic;
using System.Linq;

using ImageProcessing.Utility.DataStructure.FixedStack.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStack.Implementation.Safe
{
    public sealed class FixedStackSafe<T> : IFixedStack<T>
    {
        private readonly LinkedList<T> _stack = new LinkedList<T>();
        private readonly int _size;

        public FixedStackSafe(int size)
            => _size = size;
        
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
                var result = _stack.First;

                _stack.RemoveFirst();

                return result.Value;
            }
        }

        public void Push(T bmp)
        {
            lock (_stack)
            {
                if (_stack.Count == _size)
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
                if (Any())
                {
                    return _stack.First.Value;
                }
            }

            throw new InvalidOperationException("The stack is empty.");
        }
    }
}
