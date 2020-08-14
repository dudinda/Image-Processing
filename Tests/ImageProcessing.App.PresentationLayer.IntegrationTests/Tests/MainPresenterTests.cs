using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.UnitTests;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.Frames;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.ServiceLayer.Services.NonBlockDialog.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.DI.State.IsNotBuilt;
using ImageProcessing.Microkernel.DIAdapter.Code.Enums;
using ImageProcessing.Microkernel.EntryPoint;

using NSubstitute;
using NSubstitute.ReceivedExtensions;

using NUnit.Framework;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Tests
{
    [TestFixture]
    public class MainPresenterTests : IDisposable
    {
        private IManualResetEventService _synchronizer;
        private INonBlockDialogService _dialog;
        private MainPresenter _presenter;
        private IMainFormExposer _form;

        [SetUp]
        public void SetUp()
        {
            AppLifecycle.Build<MainPresenterTestStartup>(DiContainer.Ninject);

            _synchronizer = AppLifecycle.Controller.IoC.Resolve<IManualResetEventService>();
            _dialog = AppLifecycle.Controller.IoC.Resolve<INonBlockDialogService>();
            _form = AppLifecycle.Controller.IoC.Resolve<IMainFormExposer>();
            _presenter = AppLifecycle.Controller.IoC.Resolve<MainPresenter>();

            _presenter.Run();
        }


        [Test]
        public void FileOpenMenuClick()
        {
            _form.OpenFileMenu.PerformClick();

           _synchronizer.Event.WaitOne();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(s => s == _form),
                Arg.Any<OpenFileDialogEventArgs>());

            _dialog.Received().NonBlockOpen(Arg.Any<string>());

            var image = _form.SourceImage as Bitmap;

            Assert.IsTrue(image != null);
            Assert.IsTrue(image.SameAs(Res._1920x1080frame));
        }

        [Test]
        public void FileSaveAsMenuClick()
        {
            _form.OpenFileMenu.PerformClick();

            _form.When(
                    (form) => form.Refresh(
                        Arg.Is<ImageContainer>(s => s == ImageContainer.Source)
                     )
                 ).Do((call) =>
                 {
                     _form.SaveAsMenu.PerformClick();
                 });

            _synchronizer.Event.WaitOne();
        }

        [Test]
        public void FileSaveMenuClick()
        {
            _form.SaveFileMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(s => s == _form),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }

        [Test]
        public void ReplaceSourceImageClick()
        {
            _form.ReplaceSrcByDstButton.Enabled = true;
            _form.ReplaceSrcByDstButton.PerformClick();

            var container = ImageContainer.Destination;

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(s => s == _form),
                Arg.Is<ReplaceImageEventArgs>(arg => arg.Container == container));
        }

        [Test]
        public void ReplaceDestinationImageClick()
        {
            _form.ReplaceDstBySrcButton.Enabled = true;
            _form.ReplaceDstBySrcButton.PerformClick();

            var container = ImageContainer.Source;

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(s => s == _form),
                Arg.Is<ReplaceImageEventArgs>(arg => arg.Container == container));
        }

        [TearDown]
        public void Dispose()
        {
            AppLifecycle.Exit();
            AppLifecycle.State = new AppIsNotBuilt();
        }
    }
}
