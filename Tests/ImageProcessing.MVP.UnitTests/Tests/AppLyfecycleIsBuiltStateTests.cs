using System;

using ImageProcessing.Microkernel.EntryPoint;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Factory;

using NUnit.Framework;

namespace ImageProcessing.MVP.UnitTests.Tests
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
