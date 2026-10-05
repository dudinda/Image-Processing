using System;
using System.Drawing;

using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Interface;
using ImageProcessing.App.Domain.Services.Cache.Implementation;

using Microsoft.Extensions.Caching.Memory;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Implementation
{
    internal class CacheServiceWrapper : ICacheServiceWrapper
    {
        private readonly CacheService<Bitmap> _cache;

        public CacheServiceWrapper(MemoryCacheOptions options)
        {
            _cache = new CacheService<Bitmap>(options);
        }

        public virtual Bitmap GetOrCreate(object key, Func<Bitmap> createItem)
            => _cache.GetOrCreate(key, createItem);

        public virtual void Reset()
            => _cache.Reset();
    }
}
