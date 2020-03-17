using System;

namespace ImageProcessing.ServiceLayer.Services.Cache.Interface
{
    public interface ICacheService<TItem>
    {
        TItem GetOrCreate(object key, Func<TItem> createItem);
        void Clear();
    }
}
