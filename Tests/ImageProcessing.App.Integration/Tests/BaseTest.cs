using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.MVP.Code.Enums;
using ImageProcessing.Microkernel.MVP.Models;
using ImageProcessing.Microkernel.MVP.Services.Controller.Implementation;
using ImageProcessing.Microkernel.MVP.Services.Providers;

using NUnit.Framework;

namespace ImageProcessing.App.Presentation.IntegrationTests.Tests
{
    [SetUpFixture]
    public class BaseTest<TStartup>
        where TStartup : class, IStartup
    {
        protected AppLifecycle _app;
        protected IComponentProvider _ioc;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _app = new AppLifecycle();
            _app.Build<TStartup>(DiContainer.LightInject);
            _ioc = AppController.Controller.IoC;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _app.Dispose();
        }
    }
}
