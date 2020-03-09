using System;

namespace ImageProcessing.Core.Factory.Filter
{
    public interface IFilterFactory<out TFilter, in TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// Provides a factory method
        /// where <typeparamref name="TEnum"/> represents
        /// enumeration for <typeparamref name="TFilter"/>
        /// </summary>
        TFilter GetFilter(TEnum filter);
    }
}
