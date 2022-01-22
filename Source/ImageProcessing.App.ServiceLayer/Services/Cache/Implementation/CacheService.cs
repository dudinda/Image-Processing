using System;
using System.Threading;

using ImageProcessing.App.ServiceLayer.Services.Cache.Interface;

using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace ImageProcessing.App.ServiceLayer.Services.Cache.Implementation
{
    /// <inheritdoc cref="ICacheService{TItem}"/>
    public class CacheService<TItem> : ICacheService<TItem>
    {
        private static CancellationTokenSource _resetToken
            = new CancellationTokenSource();

        private IMemoryCache _cache = new MemoryCache(
            new MemoryCacheOptions() { SizeLimit = 32 });

        /// <inheritdoc/>
        public virtual TItem GetOrCreate(object key, Func<TItem> createItem)
        {
            // Look for a cache key.
            if (!_cache.TryGetValue(key, out var cacheEntry))
            {
                cacheEntry = createItem();

                var options = new MemoryCacheEntryOptions().SetSize(1)
                    .SetPriority(CacheItemPriority.High)
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(20));

                options.AddExpirationToken(
                    new CancellationChangeToken(_resetToken.Token));
                
                _cache.Set(key, cacheEntry, options);
            }

            return (TItem)cacheEntry!;
        }

        /// <inheritdoc/>
        public virtual void Reset()
        {
            if (_resetToken != null &&
               !_resetToken.IsCancellationRequested &&
                _resetToken.Token.CanBeCanceled)
            {
                _resetToken.Cancel();
                _resetToken.Dispose();
            }

            _resetToken = new CancellationTokenSource();
        }
    }
}
