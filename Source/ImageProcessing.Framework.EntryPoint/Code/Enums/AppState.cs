namespace ImageProcessing.Framework.EntryPoint.Code.Enums
{
    /// <summary>
    /// Represents a state of an application.
    /// </summary>
    public enum AppState
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
        ///An application starts work.
        /// </summary>
        StartWork  = 3,

        /// <summary>
        ///An application ends works.
        /// </summary>
        EndWork    = 4
    }
}
