using System;

using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Models.State;
using ImageProcessing.Microkernel.MVP.Models.State.Implementation;

namespace ImageProcessing.Microkernel.MVP.Services.Factories
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
