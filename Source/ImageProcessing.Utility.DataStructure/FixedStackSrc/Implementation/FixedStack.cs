using System;
using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation
{
    public sealed class FixedStack<T> : IFixedStack<T>
    {
        private readonly LinkedList<T> _stack = new LinkedList<T>();
        private readonly int _size;

        public FixedStack(int size)
            => _size = size;

        public bool Any()
            => _stack.Count > 0;

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

        public IEnumerator<T> GetEnumerator()
        {
            using (var iterator = _stack.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
