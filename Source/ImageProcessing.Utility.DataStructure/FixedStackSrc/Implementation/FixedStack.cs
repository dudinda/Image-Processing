using System;
using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation
{
    public sealed class FixedStack<T> : IFixedStack<T>
    {
        private readonly LinkedList<T> _stack
            = new LinkedList<T>();

        public FixedStack(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            Capacity = capacity;
        }
           
        public FixedStack(IFixedStack<T> stack)
            : this(stack.Capacity)
        {
            foreach(var item in stack)
            {
                _stack.AddLast(item);
            }
        }

        /// <inheritdoc/>
        public int Capacity { get; }

        /// <inheritdoc/>
        public bool IsEmpty
            => _stack.Count == 0;

        /// <inheritdoc/>
        public T Pop()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException("The stack is empty.");
            }

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
            if (!IsEmpty)
            {
                return _stack.First.Value;
            }

            throw new InvalidOperationException("The stack is empty.");
        }

        /// <summary>
        /// Iterate the stack from top to bottom.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty)
            {
                yield break;
            }

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
