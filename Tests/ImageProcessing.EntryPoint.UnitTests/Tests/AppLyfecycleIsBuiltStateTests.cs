using System;

using ImageProcessing.Microkernel.EntryPoint;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint.Factory;

using NUnit.Framework;

namespace ImageProcessing.EntryPoint.UnitTests.Tests
{
    [TestFixture]
    internal sealed class AppLyfecycleIsBuiltStateTests : IDisposable
    {
        [SetUp]
        public void SetUp()
        {
            AppLifecycle.State = StateFactory.GetState(AppState.IsBuilt);
        }


        [TearDown]
        public void Dispose()
        {
            AppLifecycle.State = StateFactory.GetState(AppState.IsNotBuilt);
        }
    }
}
