using System;
using System.Drawing;

using ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Interface;
using ImageProcessing.App.ServiceLayer.Services.Cache.Implementation;

namespace ImageProcessing.App.Integration.Monolith.ServiceLayer.Services.Cache.Implementation
{
    internal class CacheServiceWrapper : ICacheServiceWrapper
    {
        private readonly CacheService<Bitmap> _cache
            = new CacheService<Bitmap>();

        public virtual Bitmap GetOrCreate(object key, Func<Bitmap> createItem)
            => _cache.GetOrCreate(key, createItem);

        public virtual void Reset()
            => _cache.Reset();
    }
}
