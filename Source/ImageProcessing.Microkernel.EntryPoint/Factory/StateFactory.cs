using System;

using ImageProcessing.Microkernel.Code.Enums;
using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.DI.State.IsNotBuilt;
using ImageProcessing.Microkernel.State.EndWork;
using ImageProcessing.Microkernel.State.Implementation.IsBuilt;
using ImageProcessing.Microkernel.State.StartWork;

namespace ImageProcessing.Microkernel.Factory
{
    /// <summary>
    /// A factory method provider for all the types
    /// implementing the <see cref="IAppState"/>.
    /// </summary>
    internal static class StateFactory
    {
        /// <summary>
        /// Get the specified <see cref="AppState"/>.
        /// </summary>
        internal static IAppState Get(AppState state)
            => state
        switch
        {
            AppState.IsBuilt
                => new AppIsBuilt(),
            AppState.IsNotBuilt
                => new AppIsNotBuilt(),
            AppState.StartWork
                => new AppStartWork(),
            AppState.EndWork
                => new AppEndWork(),

            _ => throw new NotImplementedException(nameof(state))
        };
    }
}
