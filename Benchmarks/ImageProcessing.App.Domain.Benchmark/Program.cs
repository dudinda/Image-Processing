using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace ImageProcessing.Services.Benchmark
{
    internal sealed class Program
    {
        static void Main(string[] args)
            => BenchmarkSwitcher
                .FromAssembly(typeof(Program).Assembly)
                .Run(args, new DebugInProcessConfig());
    }
}
