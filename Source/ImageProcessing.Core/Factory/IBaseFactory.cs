using System;

namespace ImageProcessing.Core.Factory
{
    /// <summary>
    /// Base factory method provider for all the types
    /// implementing the <typeparamref name="TFilter"/>.
    /// </summary>
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
