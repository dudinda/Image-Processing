using System;
using System.Collections.Generic;
using System.Linq;

using ImageProcessing.Utility.BitmapStack.Abstract;

namespace ImageProcessing.Utility.BitmapStack
{
    public class FixedStack<T> : IFixedStack<T>
    {
        private List<T> bmpStack = new List<T>();
        private int _size;

        public FixedStack(int size)
        {
            _size = size;
        }

        public bool Any() => bmpStack.Any();

        public T Pop()
        {
            try
            {
                var result = bmpStack.First();

                bmpStack.RemoveAt(0);

                return result;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
        }

        public void Push(T bmp)
        {
            if (bmpStack.Count.Equals(10))
            {
                bmpStack.Remove(bmpStack.Last());
            }

            bmpStack.Insert(0, bmp);
        }

        public T Peek()
        {
            try
            {
                return bmpStack.FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                throw new IndexOutOfRangeException("The stack is empty.");
            }

        }
    }
}
