using System.ComponentModel;

namespace ImageProcessing.Common.Enums
{
    /// <summary>
    /// Specifies a DI container.
    /// </summary>
    public enum Container
    {
        /// <summary>
        /// An unknown DI container.
        /// </summary>
        [Description("DI container is not specified")]
        Unknown     = 0,

        /// <summary>
        /// Light inject.
        /// </summary>
        [Description("Light inject")]
        LightInject = 1,

        /// <summary>
        /// Ninject.
        /// </summary>
        [Description("Ninject")]
        Ninject     = 2
    }
}
