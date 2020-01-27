using System;
using System.Threading.Tasks;

namespace ImageProcessing.Core.Locker.Interface
{
    public interface IAsyncLocker
    {
        Task<T> LockAsync<T>(Func<T> worker);
        Task LockAsync(Action worker);
    }
}
