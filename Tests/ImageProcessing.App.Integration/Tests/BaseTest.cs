
using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Models;

using NUnit.Framework;

namespace ImageProcessing.App.Presentation.IntegrationTests.Tests
{
    [SetUpFixture]
    public class BaseTest<TStartup>
        where TStartup : class, IStartup
    {
        protected AppLifecycle _app;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _app = new AppLifecycle();
            _app.Build<TStartup>(DiContainer.LightInject);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _app.Dispose();
        }

    }
}
