using System;
using System.Threading.Tasks;

namespace ImageProcessing.ServiceLayer.Services.Locker.Base.Interface
{
    public interface IAsyncLocker
    {
        Task<T> LockAsync<T>(Func<T> worker);
        Task LockAsync(Action worker);
    }
}
