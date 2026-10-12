using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.App.Integration.Code.Resources;
using ImageProcessing.App.Integration.Monolith.Presentation.Presenters;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Show;
using ImageProcessing.App.Presentation.IntegrationTests.Tests;
using ImageProcessing.App.Presentation.UnitTests.Extensions;
using ImageProcessing.App.UI.Services.FormExposers;

using NSubstitute;

using NUnit.Framework;

namespace ImageProcessing.App.Integration.Tests.MainPresenter
{
    [TestFixture]
    internal class MainMenuPresenterTest : BaseTest<Integration.Monolith.UI.Startup>
    {
        private MainPresenterWrapper _presenter;
        private MainMenuPresenterWrapper _menu;
        private IMainFormExposer _form;

        [SetUp]
        public void SetUp()
        {
            _presenter = _ioc.Resolve<MainPresenterWrapper>();
            _presenter.Run();
            _menu = _presenter.MenuPresenter;
            _form = _presenter.View as IMainFormExposer;
        }


        [Test]
        [Timeout(5000)]
        public async Task FileOpenMenuClick()
        {
            _presenter.Pipeline.BeginRender();
            _form.OpenFileMenu.PerformClick();
            var view = _presenter.View;
            await _menu.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<OpenFileDialogEventArgs>());

            await _menu.Dialog.Received().OpenFileDialog();

            while (view.SourceImage == null)
            {
                await Task.Delay(300);
            }
            var image = view.SourceImage as Bitmap;

            Assert.IsTrue(image != null);
            Assert.IsTrue(image.SameAs(Res._1920x1080frame));
        }


        [Test]
        public async Task FileSaveAsMenuClick()
        {
            _presenter.Pipeline.BeginRender();
            _form.OpenFileMenu.PerformClick();
            _form.SaveAsMenu.PerformClick();
            while (_form.SourceImage == null)
            {
                await Task.Delay(300);
            }
            await _menu.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveAsFileDialogEventArgs>());
            await _menu.Reference.Received().GetCopy();
            await _menu.Dialog.Received().SaveFileAsDialog(
                Arg.Is<Bitmap>(arg => arg.SameAs(Res._1920x1080frame)));
        }


        [Test]
        public void OpenRgbMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.RgbMenuButton.PerformClick();

            _menu.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<ShowRgbMenuEventArgs>());
        }

        [Test]
        public void OpenConvolutionMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.ConvolutionMenuButton.PerformClick();

            _menu.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<ShowConvolutionMenuEventArgs>());
        }

        [Test]
        public void OpenDistributionMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.DistributionMenuButton.PerformClick();

            _menu.Received().OnEventHandler(
               Arg.Is<object>(arg => arg == _form),
               Arg.Any<ShowDistributionMenuEventArgs>());
        }

        [Test]

        public void FileSaveMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.SaveFileMenu.PerformClick();

            _menu.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }
    }
}
