using ImageProcessing.Framework.Core.DI.IoC.Interface;

namespace ImageProcessing.Framework.EntryPoint.Startup
{
    public interface IStartup
    {
        void Build(IDependencyResolution builder);
    }
}
