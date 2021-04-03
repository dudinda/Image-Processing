using System;

using ImageProcessing.Microkernel.DI.EntryPoint.State.Interface;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint.State.Implementation;

namespace ImageProcessing.Microkernel.EntryPoint.Factory
{
    /// <summary>
    /// A factory method for all the types
    /// implementing the <see cref="IAppState"/>.
    /// </summary>
    internal static class StateFactory
    {
        /// <summary>
        /// Get the specified <see cref="AppState"/>.
        /// </summary>
        internal static IAppState GetState(AppState state)
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
