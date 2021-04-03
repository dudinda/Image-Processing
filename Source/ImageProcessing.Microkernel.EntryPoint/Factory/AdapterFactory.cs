using System;

using ImageProcessing.Microkernel.DIAdapter.Adapters.LightInject;
using ImageProcessing.Microkernel.DIAdapter.Adapters.Ninject;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.DIAdapter.Container;

namespace ImageProcessing.Microkernel.EntryPoint.Factory
{
    /// <summary>
    /// A factory method for all the types
    /// implementing the <see cref="IContainer"/>.
    /// </summary>
    internal static class AdapterFactory
    {
        /// <summary>
        /// Get the adapter for the specified <see cref="DiContainer"/>.
        /// </summary>
        internal static IContainer GetAdapter(DiContainer container)
            => container
            switch
            {
                DiContainer.LightInject
                    => new LightInjectAdapter(),
                DiContainer.Ninject
                    => new NinjectAdapter(),

                _ => throw new NotImplementedException(nameof(container))
            };
    }
}
