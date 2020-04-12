using System;
using System.Collections.Generic;
using System.Linq;

using ImageProcessing.Utility.DataStructure.FixedStack.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStack.Implementation
{
    public sealed class FixedStack<T> : IFixedStack<T>
    {
        private readonly List<T> _stack = new List<T>();
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

                    var result = _stack.First();

                    _stack.RemoveAt(0);

                    return result;
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
                if (_stack.Count.Equals(10))
                {
                    _stack.Remove(_stack.Last());
                }

                _stack.Insert(0, bmp);
            }
        }

        public T Peek()
        {
            lock (_stack)
            {
                try
                {
                    return _stack.First();
                }
                catch (InvalidOperationException)
                {
                    throw new IndexOutOfRangeException("The stack is empty.");
                }
            }
        }
    }
}
