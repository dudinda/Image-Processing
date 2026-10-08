using System;

using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.MVP.Code.Constants;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Services.Factories;
using ImageProcessing.MVP.UnitTests.Fakes;

using NUnit.Framework;

namespace ImageProcessing.MVP.UnitTests.Tests
{
    [TestFixture]
    internal sealed class AppLifecycleIsNotBuiltStateTests : IDisposable
    {
        private AppLifecycle _app;

        [SetUp]
        public void SetUp()
        {
            _app = new AppLifecycle();
            _app.State = _app.Factory.GetState(AppState.IsNotBuilt);
        }

        [Test]
        public void AppLifecycleIsNotBuiltThrowsOnRun()
            => Assert.Throws<InvalidOperationException>(
                   () => _app.Run<MainPresenterFake>(),
                   Exceptions.ApplicationIsNotBuilt);

        [Test]
        public void AppLifecycleIsNotBuiltThrowsOnExit()
            => Assert.Throws<InvalidOperationException>(
                   () => _app.Exit(),
                   Exceptions.ApplicationIsNotBuilt);

        public void Dispose()
        {
            _app.Dispose();
        }
    }
}
