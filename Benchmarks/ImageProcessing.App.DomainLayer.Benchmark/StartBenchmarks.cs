using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace ImageProcessing.App.DomainLayer.Benchmark
{
    internal sealed class StartBenchmarks
    {
        static void Main(string[] args)
            => BenchmarkSwitcher
                .FromAssembly(typeof(StartBenchmarks).Assembly)
                .Run(args, new DebugInProcessConfig());
    }
}
