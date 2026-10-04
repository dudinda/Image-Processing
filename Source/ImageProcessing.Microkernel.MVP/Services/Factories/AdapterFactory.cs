using System;

using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Services.Adapter;
using ImageProcessing.Microkernel.MVP.Services.Adapter.Implementation;

namespace ImageProcessing.Microkernel.MVP.Services.Factories
{
    /// <summary>
    /// A factory method for all the types
    /// implementing the <see cref="IContainer"/>.
    /// </summary>
    public static class AdapterFactory
    {
        /// <summary>
        /// Get the adapter for the specified <see cref="DiContainer"/>.
        /// </summary>
        public static IContainer GetAdapter(DiContainer container)
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
