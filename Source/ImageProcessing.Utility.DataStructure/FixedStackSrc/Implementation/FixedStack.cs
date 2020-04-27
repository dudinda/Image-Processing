using System;
using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation
{
    public sealed class FixedStack<T> : IFixedStack<T>
    {
        private readonly LinkedList<T> _stack = new LinkedList<T>();

        /// <inheritdoc/>
        public int Capacity { get; }

        public FixedStack(int capacity)
            => Capacity = capacity;

        public FixedStack(IFixedStack<T> stack)
            : this(stack.Capacity)
        {
            foreach(var item in stack)
            {
                _stack.AddLast(item);
            }
        }

        /// <inheritdoc/>
        public bool Any()
            => _stack.Count > 0;

        /// <inheritdoc/>
        public T Pop()
        {
            var result = _stack.First;

            _stack.RemoveFirst();

            return result.Value;
        }

        /// <inheritdoc/>
        public void Push(T bmp)
        {
            if (_stack.Count == Capacity)
            {
                _stack.RemoveLast();
            }

            _stack.AddFirst(bmp);
        }

        /// <inheritdoc/>
        public T Peek()
        {
            if (Any())
            {
                return _stack.First.Value;
            }

            throw new InvalidOperationException("The stack is empty.");
        }

        /// <summary>
        /// Iterate a stack from head to tail.
        /// </summary>
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

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <inheritdoc/>
        public object Clone()
            => new FixedStack<T>(this);
    }
}
