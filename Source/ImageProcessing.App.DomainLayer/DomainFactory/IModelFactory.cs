using System;

namespace ImageProcessing.App.DomainLayer.DomainFactory
{
    /// <summary>
    /// A base factory method provider for all the types
    /// implementing the <typeparamref name="TModel"/>.
    /// </summary>
    public interface IModelFactory<out TModel, in TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// Provides a factory method
        /// where a <typeparamref name="TEnum"/> value represents an
        /// enumeration for the <typeparamref name="TModel"/>.
        /// </summary>
        TModel Get(TEnum model);
    }

    /// <summary>
    /// A base factory method provider for all the types
    /// implementing the <typeparamref name="TModel"/>.
    /// </summary>
    public interface IModelFactory<out TModel, in TFirst, in TSecond>
        where TFirst : Enum
        where TSecond : Enum
    {
        /// <summary>
        /// Provides a factory method
        /// where a <typeparamref name="TEnum"/> value represents an
        /// enumeration for the <typeparamref name="TModel"/>.
        /// </summary>
        TModel Get(TFirst first, TSecond second);
    }
}
