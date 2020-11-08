using System;

using ImageProcessing.Microkernel.AppConfig;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint;

using NUnit.Framework;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Tests
{
    [SetUpFixture]
    internal abstract class BaseTest<TStartup>
        where TStartup : class, IStartup
    {
        [SetUp]
        public void SetUp()
        {
            AppLifecycle.Build<TStartup>(DiContainer.Ninject);
            BeforeStart();
        }

        [TearDown]
        public void TearDown()
        {
            AppLifecycle.Exit();
        }

        protected abstract void BeforeStart();
    }
}
