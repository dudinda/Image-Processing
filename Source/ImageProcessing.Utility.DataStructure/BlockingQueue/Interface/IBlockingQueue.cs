using System;

namespace ImageProcessing.Utility.DataStructure.BlockingQueue.Interface
{
    public interface IBlockingQueue<T> : IDisposable
    {
        bool TryEnqueue(T item);
        bool TryDequeue(out T value);
        bool Any();
    }
}
