using System;
using System.Threading;
using System.Threading.Tasks;

public class SemaphoreLocker
{
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public async Task<T> LockAsync<T>(Func<T> worker)
    {
        await _semaphore.WaitAsync();
        try
        {
            return await Task.Run(() => worker());
        }
        catch
        {
            throw;
        }
        finally
        {
            _semaphore.Release();
        }
    }
}