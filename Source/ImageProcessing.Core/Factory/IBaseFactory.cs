using System;

namespace ImageProcessing.Core.Factory
{
    public interface IBaseFactory<out TFilter, in TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// Provides a factory method
        /// where <typeparamref name="TEnum"/> represents
        /// enumeration for the <typeparamref name="TFilter"/>.
        /// </summary>
        TFilter GetFilter(TEnum filter);
    }
}
