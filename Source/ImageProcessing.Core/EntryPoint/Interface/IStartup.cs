using ImageProcessing.Core.IoC.Interface;

namespace ImageProcessing.Core.EntryPoint.Interface
{
    public interface IStartup
    {
        void Build(IDependencyResolution builder);
    }
}
