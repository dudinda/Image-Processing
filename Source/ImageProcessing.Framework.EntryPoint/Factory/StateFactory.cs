using System;

using ImageProcessing.Framework.Core.EntryPoint.State.Interface;
using ImageProcessing.Framework.Core.EntryPoint.State.IsNotBuilt;
using ImageProcessing.Framework.EntryPoint.Code.Enums;
using ImageProcessing.Framework.EntryPoint.State.EndWork;
using ImageProcessing.Framework.EntryPoint.State.Implementation.IsBuilt;
using ImageProcessing.Framework.EntryPoint.State.StartWork;

namespace ImageProcessing.Framework.EntryPoint.Factory
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
