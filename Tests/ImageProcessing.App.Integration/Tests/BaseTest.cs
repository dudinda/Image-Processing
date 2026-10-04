
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
        private AppLifecycle _app;

        [SetUp]
        public void SetUp()
        {
            _app = new AppLifecycle();
            _app.Build<TStartup>(DiContainer.Ninject);
            BeforeStart();
        }

        [TearDown]
        public void TearDown()
        {
            _app.Dispose();
        }

        protected abstract void BeforeStart();
    }
}
