using System;

namespace ImageProcessing.Microkernel.MVP.Model
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
        TModel Get(TEnum filter);
    }
}
