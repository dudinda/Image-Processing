using ImageProcessing.Microkernel.DI.IoC.Interface;

namespace ImageProcessing.Microkernel.Startup
{
    public interface IStartup
    {
        void Build(IDependencyResolution builder);
    }
}
