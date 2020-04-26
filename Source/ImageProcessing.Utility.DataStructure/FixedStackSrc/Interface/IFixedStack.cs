using System.Collections;
using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface
{
    public interface IFixedStack<T> : IEnumerable, IEnumerable<T>
    {
        bool Any();
        T Pop();
        T Peek();
        void Push(T bmp);
    }
}
