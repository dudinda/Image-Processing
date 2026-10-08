using System;

using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Services.Factories;

using NUnit.Framework;

namespace ImageProcessing.MVP.UnitTests.Tests
{
    [TestFixture]
    internal sealed class AppLyfecycleIsBuiltStateTests : IDisposable
    {
        private AppLifecycle _app;

        [SetUp]
        public void SetUp()
        {
            _app = new AppLifecycle();
            _app.State = _app.Factory.GetState(AppState.IsBuilt);
        }


        [TearDown]
        public void Dispose()
        {
            _app.Dispose();
        }
    }
}
