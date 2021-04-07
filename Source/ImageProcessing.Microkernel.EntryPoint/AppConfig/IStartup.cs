using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.Microkernel.AppConfig
{
    /// <summary>
    /// It is used to create the
    /// initial configuration of an application.
    /// </summary>
    public interface IStartup
    {
        /// <summary>
        /// Set up an application and register its components with a
        /// selected DI - container.
        /// </summary>
        void Build(IComponentProvider builder);
    }
}
