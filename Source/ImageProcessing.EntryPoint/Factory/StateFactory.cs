using System;

using ImageProcessing.Core.EntryPoint.State.Interface;
using ImageProcessing.Core.EntryPoint.State.IsNotBuilt;
using ImageProcessing.EntryPoint.Code.Enums;
using ImageProcessing.EntryPoint.State.EndWork;
using ImageProcessing.EntryPoint.State.Implementation.IsBuilt;
using ImageProcessing.EntryPoint.State.StartWork;

namespace ImageProcessing.EntryPoint.Factory
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
