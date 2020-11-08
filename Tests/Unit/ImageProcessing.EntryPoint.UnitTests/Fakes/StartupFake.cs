using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.MVP.IoC.Interface;

namespace ImageProcessing.EntryPoint.UnitTests.Fakes
{
    internal class StartupFake : IStartup
    {
        public virtual void Build(IDependencyResolution builder)
        {
            
        }
    }
}
