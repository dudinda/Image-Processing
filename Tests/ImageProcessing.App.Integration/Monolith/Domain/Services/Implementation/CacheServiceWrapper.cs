using System;
using System.Drawing;

using ImageProcessing.App.Domain.Services.Cache.Implementation;
using ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Interface;

namespace ImageProcessing.App.Integration.Monolith.Domain.Services.Cache.Implementation
{
    internal class CacheServiceWrapper : ICacheServiceWrapper
    {
        private readonly CacheService<Bitmap> _cache;

        public CacheServiceWrapper(CacheService<Bitmap> cache)
        {
            _cache = _cache;
        }

        public virtual Bitmap GetOrCreate(object key, Func<Bitmap> createItem)
            => _cache.GetOrCreate(key, createItem);

        public virtual void Reset()
            => _cache.Reset();
    }
}
