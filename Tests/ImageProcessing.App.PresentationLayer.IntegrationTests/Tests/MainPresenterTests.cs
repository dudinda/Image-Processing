using System;
using System.Drawing;
using System.Threading;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.PresentationLayer.UnitTests;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;
using ImageProcessing.App.PresentationLayer.UnitTests.Services;
using ImageProcessing.App.PresentationLayer.UnitTests.TestResources;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Exposers;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.App.UILayer.FormExposers.Main;
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
        private MainPresenterExposer _presenter;
        private IMainFormExposer _form;

        [SetUp]
        public void SetUp()
        {
            AppLifecycle.Build<MainPresenterTestStartup>(DiContainer.Ninject);

            _synchronizer = AppLifecycle.Controller.IoC.Resolve<IManualResetEventService>();
            _form = AppLifecycle.Controller.IoC.Resolve<IMainFormExposer>();
            _presenter = AppLifecycle.Controller.IoC.Resolve<MainPresenterExposer>();

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

            _presenter.Dialog.Received().NonBlockOpen(Arg.Any<string>());

            var image = _form.SourceImage as Bitmap;

            Assert.IsTrue(image != null);
            Assert.IsTrue(image.SameAs(Res._1920x1080frame));
        }


        [Test]
        [Timeout(5000)]
        public void RendererRecieveBlockTest()
        {
            _form.OpenFileMenu.PerformClick();
            _synchronizer.Event.WaitOne();

            _presenter.Pipeline.Received().Register(Arg.Any<IPipelineBlock>());

            var container = ImageContainer.Source;

            _form.Received().GetImageCopy(Arg.Is<ImageContainer>(arg => arg == container));
            _form.Received().ImageIsDefault(Arg.Is<ImageContainer>(arg => arg == container));
            _form.Received().AddToUndoRedo(
                Arg.Is<ImageContainer>(arg => arg == container),
                Arg.Any<Bitmap>(),
                Arg.Is<UndoRedoAction>(arg => arg == UndoRedoAction.Undo));
            _form.Received().SetImageCopy(
                Arg.Is<ImageContainer>(arg => arg == container),
                Arg.Any<Bitmap>());
            _form.Received().SetImageToZoom(
                Arg.Is<ImageContainer>(arg => arg == container),
                Arg.Any<Bitmap>());
            _form.Received().SetImage(
                Arg.Is<ImageContainer>(arg => arg == container),
                Arg.Any<Bitmap>());
            _form.Received().Refresh(Arg.Is<ImageContainer>(arg => arg == container));
            _form.Received().ResetTrackBarValue(Arg.Is<ImageContainer>(arg => arg == container));
            _presenter.Pipeline.Received().AwaitResult();
            _presenter.Cache.Received().Reset();
            _presenter.Pipeline.Received().Any();
            _form.Received().SetCursor(Arg.Is<CursorType>(arg => arg == CursorType.Default));
        }

        [Test]
        [Timeout(5000)]
        public void FileSaveAsMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _synchronizer.Event.WaitOne();
            _synchronizer.Event.Reset();

            _form.SaveAsMenu.PerformClick();
            _synchronizer.Event.WaitOne();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveAsFileDialogEventArgs>());

            _presenter.Dialog.Received().NonBlockSaveAs(
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
            _synchronizer.Event.Reset();

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
        }
    }
}
