using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.Microkernel.AppConfig
{
    /// <summary>
    /// Used to create the
    /// initial configuration of an application.
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// Setup an application and register its dependencies to a
        /// selected DI - container.
        /// </summary>
        void Build(IDependencyResolution builder);
    }
}
