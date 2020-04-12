using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Utility.DataStructure.BlockingQueue.Interface
{
    public interface IBlockingQueue<T>
    {
        bool TryEnqueue(T item);
        bool TryDequeue(out T value);
        void Close();
        bool Any();
    }
}
