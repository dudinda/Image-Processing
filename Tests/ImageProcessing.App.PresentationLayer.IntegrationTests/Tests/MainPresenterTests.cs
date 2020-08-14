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
        [Timeout(5000)]
        public void FileOpenMenuClick()
        {
            _form.OpenFileMenu.PerformClick();

           _synchronizer.Event.WaitOne();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<OpenFileDialogEventArgs>());

            _dialog.Received().NonBlockOpen(Arg.Any<string>());

            var image = _form.SourceImage as Bitmap;

            Assert.IsTrue(image != null);
            Assert.IsTrue(image.SameAs(Res._1920x1080frame));
        }

        [Test]
        [Timeout(5000)]
        public void FileSaveAsMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _synchronizer.Event.WaitOne();

            _form.SaveAsMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveAsFileDialogEventArgs>());

            _dialog.Received().NonBlockSaveAs(
                Arg.Is<Bitmap>(arg => arg.SameAs((Bitmap)_form.SrcImageCopy)),
                Arg.Any<string>());           
        }

        [Test]
        [Timeout(5000)]
        public void FileSaveMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _synchronizer.Event.WaitOne();

            _form.SaveFileMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }

        [Test]
        [Timeout(5000)]
        public void ReplaceDestinationImageClick()
        {
            _form.OpenFileMenu.PerformClick();
            _synchronizer.Event.WaitOne();

            _form.ReplaceDstBySrcButton.PerformClick();
            _synchronizer.Event.WaitOne();

            var container = ImageContainer.Source;

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Is<ReplaceImageEventArgs>(arg => arg.Container == container));

            var destination = _form.DstImageCopy as Bitmap;
            var source = _form.SrcImageCopy as Bitmap;

            Assert.IsTrue(source != null);
            Assert.IsTrue(destination != null);
            Assert.IsTrue(_form.DestinationImage != null);
            Assert.IsTrue(source.SameAs(destination));
        }

        [Test]
        public void ReplaceSourceImageClick()
        {
            _form.ReplaceSrcByDstButton.Enabled = true;
            _form.ReplaceSrcByDstButton.PerformClick();

            var container = ImageContainer.Destination;

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
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
