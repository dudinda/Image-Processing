using System;

namespace ImageProcessing.App.ServiceLayer.Services.Cache.Interface
{
    /// <summary>
    /// Provides caching service. 
    /// </summary>
    /// <typeparam name="TItem"></typeparam>
    public interface ICacheService<TItem>
    {
        /// <summary>
        /// Get the <typeparamref name="TItem"/> by key or
        /// retrieve the item that have been already defined.
        /// </summary>
        TItem GetOrCreate(object key, Func<TItem> createItem);

        /// <summary>
        /// Reset cache.
        /// </summary>
        void Reset();
    }
}
