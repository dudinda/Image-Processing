namespace ImageProcessing.Microkernel.EntryPoint.Code.Enums
{
    /// <summary>
    /// Represents a state of an application.
    /// </summary>
    internal enum AppState
    {
        /// <summary>
        /// An unknown application state.
        /// </summary>
        Unknown    = 0,

        /// <summary>
        /// An application is not built.
        /// </summary>
        IsNotBuilt = 1,

        /// <summary>
        ///An application is built.
        /// </summary>
        IsBuilt    = 2,

        /// <summary>
        ///An application starts to work.
        /// </summary>
        StartWork  = 3,

        /// <summary>
        ///An application ends work.
        /// </summary>
        EndWork    = 4
    }
}
