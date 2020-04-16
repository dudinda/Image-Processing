using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.Microkernel.Startup
{
    public interface IStartup
    {
        void Build(IDependencyResolution builder);
    }
}
