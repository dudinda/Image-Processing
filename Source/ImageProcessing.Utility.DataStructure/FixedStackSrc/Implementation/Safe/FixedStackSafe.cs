using System;
using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation.Safe
{
    public sealed class FixedStackSafe<T> : IFixedStack<T>
    {
        private readonly LinkedList<T> _stack
            = new LinkedList<T>();

        public FixedStackSafe(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            Capacity = capacity;
        }
           
        public FixedStackSafe(IFixedStack<T> stack)
            : this(stack.Capacity)
        {
            foreach (var item in stack)
            {
                _stack.AddLast(item);
            }
        }

        /// <inheritdoc/>
        public int Capacity { get; }

        /// <inheritdoc/>
        public bool IsEmpty
        {
            get
            {
                lock (_stack)
                {
                    return _stack.Count == 0;
                }
            }
        }

        /// <inheritdoc/>
        public T Pop()
        {
            lock (_stack)
            {
                if(_stack.Count == 0)
                {
                    throw new InvalidOperationException("The stack is empty.");
                }

                var result = _stack.First;

                _stack.RemoveFirst();

                return result.Value;
            }

        }

        /// <inheritdoc/>
        public void Push(T bmp)
        {
            lock (_stack)
            {
                if (_stack.Count == Capacity)
                {
                    var last = _stack.Last as IDisposable;

                    _stack.RemoveLast();

                    if(last != null)
                    {
                        last.Dispose();
                    }
                }

                _stack.AddFirst(bmp);
            }
        }

        /// <inheritdoc/>
        public T Peek()
        {
            lock (_stack)
            {
                if (_stack.Count != 0)
                {
                    return _stack.First.Value;
                }
            }

            throw new InvalidOperationException("The stack is empty.");
        }

        /// <summary>
        /// Iterate the stack from top to bottom.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            lock (_stack)
            {
                if (_stack.Count == 0)
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
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <inheritdoc/>
        public object Clone()
        {
            lock (_stack)
            {
                return new FixedStackSafe<T>(this);
            }
        }
    }
}
