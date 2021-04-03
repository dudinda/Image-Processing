using System;

using ImageProcessing.EntryPoint.UnitTests.Fakes;
using ImageProcessing.Microkernel.EntryPoint;
using ImageProcessing.Microkernel.EntryPoint.Code.Constants;
using ImageProcessing.Microkernel.EntryPoint.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint.Factory;

using NUnit.Framework;

namespace ImageProcessing.EntryPoint.UnitTests.Tests
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
