using System;
using System.Collections;
using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.FixedStackSrc.Interface
{
    public interface IFixedStack<T> : IEnumerable, IEnumerable<T>, ICloneable
    {
        /// <summary>
        /// Checks whether the stack is empty.
        /// </summary>
        bool Any();

        /// <summary>
        /// Removes and returns the object of type T at the top of the stack. 
        /// </summary>
        /// <returns></returns>
        T Pop();

        /// <summary>
        /// Returns the object of type T at the top of the stack without removing it.
        /// </summary>
        /// <returns></returns>
        T Peek();

        /// <summary>
        /// Inserts an object of type T at the top of the Stack.
        /// </summary>
        /// <param name="bmp"></param>
        void Push(T bmp);
    }
}
