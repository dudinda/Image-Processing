using System;

using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint;

using NUnit.Framework;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Tests
{
    [SetUpFixture]
    internal abstract class BaseTest<TStartup> : IDisposable
        where TStartup : class, IStartup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            AppLifecycle.Build<TStartup>(DiContainer.Ninject);
            BeforeStart();
        }

        public void Dispose()
        {
            AppLifecycle.Exit();
        }

        protected abstract void BeforeStart();
    }
}
