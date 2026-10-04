
using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.Models.AppConfig;
using ImageProcessing.Microkernel.MVP.Code.Enums;

using NUnit.Framework;

namespace ImageProcessing.App.Presentation.IntegrationTests.Tests
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
