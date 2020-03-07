using System;

namespace ImageProcessing.Core.Factory.Filter
{
    public interface IFilterFactory<out TFilter, in TEnum>
        where TEnum : Enum
    {
        TFilter GetFilter(TEnum filter);
    }
}
