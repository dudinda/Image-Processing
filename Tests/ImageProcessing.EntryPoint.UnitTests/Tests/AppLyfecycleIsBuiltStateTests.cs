using System;

using ImageProcessing.Microkernel.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint;
using ImageProcessing.Microkernel.Factory.State;

using NUnit.Framework;

namespace ImageProcessing.EntryPoint.UnitTests.Tests
{
    [TestFixture]
    internal sealed class AppLyfecycleIsBuiltStateTests : IDisposable
    {
        [SetUp]
        public void SetUp()
        {
            AppLifecycle.State = StateFactory.Get(AppState.IsBuilt);
        }


        [TearDown]
        public void Dispose()
        {
            AppLifecycle.State = StateFactory.Get(AppState.IsNotBuilt);
        }
    }
}
