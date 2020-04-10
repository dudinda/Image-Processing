using System;

namespace ImageProcessing.DomainModel.Factory.Base
{
    /// <summary>
    /// A base factory method provider for all the types
    /// implementing the <typeparamref name="TFilter"/>.
    /// </summary>
    public interface IBaseFactory<out TFilter, in TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// Provides a factory method
        /// where a <typeparamref name="TEnum"/> value represents an
        /// enumeration for the <typeparamref name="TFilter"/>.
        /// </summary>
        TFilter Get(TEnum filter);
    }
}
