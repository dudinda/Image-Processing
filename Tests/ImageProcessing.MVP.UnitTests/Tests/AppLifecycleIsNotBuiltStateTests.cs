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
        [SetUp]
        public void SetUp()
        {
            AppLifecycle.State = StateFactory.GetState(AppState.IsNotBuilt);
        }

        [Test]
        public void AppLifecycleIsNotBuiltThrowsOnRun()
            => Assert.Throws<InvalidOperationException>(
                   () => AppLifecycle.Run<MainPresenterFake>(),
                   Exceptions.ApplicationIsNotBuilt);

        [Test]
        public void AppLifecycleIsNotBuiltThrowsOnExit()
            => Assert.Throws<InvalidOperationException>(
                   () => AppLifecycle.Exit(),
                   Exceptions.ApplicationIsNotBuilt);

        public void Dispose()
        {
            AppLifecycle.Exit();
        }
    }
}
