using System.Drawing;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.IntegrationTests.TestResources;
using ImageProcessing.App.PresentationLayer.UnitTests;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Presenters;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
using ImageProcessing.Microkernel.EntryPoint;

using NSubstitute;
using NSubstitute.ReceivedExtensions;

using NUnit.Framework;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Tests
{
    [TestFixture]
#if !DEBUG
    [Timeout(5000)]
#endif
    internal sealed class MainPresenterTest : BaseTest<MainPresenterTestStartup>
    {
        private MainPresenterWrapper _presenter;
        private MainFormWrapper _form;

        protected override void BeforeStart()
        {
            _form = AppLifecycle.Controller.IoC.Resolve<MainFormWrapper>();
            _presenter = AppLifecycle.Controller.IoC.Resolve<MainPresenterWrapper>();

            _presenter.Run();
        }

        [Test]
        public void FileOpenMenuClick()
        {
            _form.OpenFileMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<OpenFileDialogEventArgs>());

            _presenter.Dialog.Received().NonBlockOpen(Arg.Any<string>());
            
            var image = _form.SourceImage as Bitmap;

            Assert.IsTrue(image != null);
            Assert.IsTrue(image.SameAs(Res._1920x1080frame));
        }


        [Test]
        public void RendererRecieveBlockTest()
        {
            _form.OpenFileMenu.PerformClick();

            Received.InOrder(() =>
            {
                _form.Received().SetCursor(Arg.Is<CursorType>(arg => arg == CursorType.Wait));
                _presenter.Pipeline.Received().Register(Arg.Any<IPipelineBlock>());
                _presenter.Pipeline.Received().AwaitResult();

                var container = ImageContainer.Source;

                _form.Received().GetImageCopy(Arg.Is<ImageContainer>(arg => arg == container));
                _form.Received().AddToUndoRedo(
                    Arg.Is<ImageContainer>(arg => arg == container),
                    Arg.Any<Bitmap>(),
                    Arg.Is<UndoRedoAction>(arg => arg == UndoRedoAction.Undo));
                _form.Received().ImageIsDefault(Arg.Is<ImageContainer>(arg => arg == container));
                _form.Received().SetImageCopy(
                    Arg.Is<ImageContainer>(arg => arg == container),
                    Arg.Any<Bitmap>());
                _form.Received().SetImage(
                    Arg.Is<ImageContainer>(arg => arg == container),
                    Arg.Any<Bitmap>());
                _form.SetImageCenter(
                    Arg.Is<ImageContainer>(arg => arg == container),
                    Arg.Is<Size>(arg => arg == Res._1920x1080frame.Size));
                _form.Received().Refresh(Arg.Is<ImageContainer>(arg => arg == container));
                _form.Received().ResetTrackBarValue(Arg.Is<ImageContainer>(arg => arg == container));

                _presenter.Cache.Received().Reset();
                _presenter.Pipeline.Received().Any();

                _form.Received().SetCursor(Arg.Is<CursorType>(arg => arg == CursorType.Default));
            });
        }

        [Test]
        public void FileSaveAsMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.SaveAsMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveAsFileDialogEventArgs>());

            _presenter.Dialog.Received().NonBlockSaveAs(
                Arg.Is<Bitmap>(arg => arg.SameAs((Bitmap)_form.SrcImageCopy)),
                Arg.Any<string>());           
        }


        [Test]
        public void OpenRgbMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.RgbMenuButton.PerformClick();

            _presenter.OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<ShowRgbMenuEventArgs>());
        }

        [Test]
        public void OpenConvolutionMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.ConvolutionMenuButton.PerformClick();

            _presenter.OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<ShowConvolutionMenuEventArgs>());
        }

        [Test]
        public void OpenDistributionMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.DistributionMenuButton.PerformClick();

            _presenter.OnEventHandler(Arg.Is<object>(arg => arg == _form),
               Arg.Any<ShowDistributionMenuEventArgs>());
        }

        [Test]

        public void FileSaveMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.SaveFileMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }

        [Test]
        public void ReplaceDestinationImageClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.ReplaceDstBySrcButton.PerformClick();

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
            _form.OpenFileMenu.PerformClick();
            _form.ReplaceDstBySrcButton.PerformClick();

            var container = ImageContainer.Source;

            _form.SetImage(container, Res._2560x1440frame);
            _form.SetImageCopy(container, Res._2560x1440frame);

            _form.ReplaceSrcByDstButton.PerformClick();

            var destination = _form.DstImageCopy as Bitmap;
            var source = _form.SrcImageCopy as Bitmap;

            Assert.IsTrue(source != null);
            Assert.IsTrue(destination != null);
            Assert.IsTrue(_form.SourceImage != null);
            Assert.IsTrue(source.SameAs(destination));

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Is<ReplaceImageEventArgs>(arg => arg.Container == container));
        }
    }
}
