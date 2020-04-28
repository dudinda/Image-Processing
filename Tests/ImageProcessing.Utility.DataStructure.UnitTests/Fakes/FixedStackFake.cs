using System.Collections;
using System.Collections.Generic;

using ImageProcessing.Utility.DataStructure.FixedStackSrc.Implementation;
using ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface;

namespace ImageProcessing.Utility.DataStructure.UnitTests.Fakes
{
    internal sealed class FixedStackFake<T> : IFixedStack<T>
    {
        public FixedStack<T> Stack { get; }

        public FixedStackFake(int capacity)
        {
            Stack = new FixedStack<T>(capacity);
        }

        public FixedStackFake(FixedStackFake<T> fake)
            => Stack = new FixedStack<T>(fake.Stack);

        public int Capacity
            => Stack.Capacity;

        public bool IsEmpty
            => Stack.IsEmpty;

        public T Pop()
            => Stack.Pop();

        public T Peek()
            => Stack.Peek();

        public void Push(T bmp)
            => Stack.Push(bmp);

        public IEnumerator<T> GetEnumerator()
            => Stack.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public IEnumerable Traverse()
        {
            using (var iterator = Stack.GetEnumerator())
            {
                while (iterator.MoveNext())
                {
                    yield return iterator.Current;
                }
            }
        }

        public object Clone()
            => new FixedStackFake<T>(this);
    }
}
