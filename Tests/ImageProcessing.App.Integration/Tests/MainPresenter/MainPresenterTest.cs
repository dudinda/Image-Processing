using System.Configuration;
using System.Drawing;

using ImageProcessing.App.Integration.Code.Resources;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Presenters;
using ImageProcessing.App.Integration.Monolith.UILayer;
using ImageProcessing.App.PresentationLayer.Code.Constants;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.UILayer.FormExposers.Main;
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
    internal sealed class MainPresenterTest : BaseTest<UIStartup>
    {
        private MainPresenterWrapper _presenter;
        private IMainFormExposer _form;

        protected override void BeforeStart()
        {
            _presenter = AppLifecycle.Controller.IoC.Resolve<MainPresenterWrapper>();
            _presenter.Run();

            _form = _presenter.View as IMainFormExposer;
        }

        [Test]
        public void FileOpenMenuClick()
        {
            _form.OpenFileMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<OpenFileDialogEventArgs>());

            _presenter.Dialog.Received().NonBlockOpen(
                Arg.Any<string>());
            
            var image = _form.SourceImage as Bitmap;

            Assert.IsTrue(image != null);
            Assert.IsTrue(image.SameAs(Res._1920x1080frame));
        }

        [Test]
        public void RendererRecieveBlockTest()
        {
            _form.OpenFileMenu.PerformClick();
            var view = _form as IMainView;

            Received.InOrder(() =>
            {
                view.Received().SetCursor(
                    Arg.Is<CursorType>(arg => arg == CursorType.Wait));

                _presenter.Pipeline.Received().Register(Arg.Any<PipelineBlock>());
                _presenter.Pipeline.Received().AwaitResult();
                _presenter.Reference.Received().SetCopy(
                    Arg.Is<Bitmap>(arg => arg == Res._1920x1080frame));

                view.Received().GetImageCopy();
                view.Received().AddToUndoRedo(
                    Arg.Is<Bitmap>(arg => arg == Res._1920x1080frame),
                    Arg.Is<UndoRedoAction>(arg => arg == UndoRedoAction.Undo));
                view.Received().SetImageCopy(Arg.Any<Bitmap>());
                view.Received().SetImage(Arg.Any<Bitmap>());
                view.SetImageCenter(
                    Arg.Is<Size>(arg => arg == Res._1920x1080frame.Size));
                view.Received().Refresh();
                view.Received().ResetTrackBarValue();

                _presenter.Pipeline.Received().Any();

                view.Received().SetCursor(
                    Arg.Is<CursorType>(arg => arg == CursorType.Default));
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
            _presenter.Reference.Received().GetCopy();
            _presenter.Dialog.Received().NonBlockSaveAs(
                Arg.Any<Bitmap>(),
                Arg.Any<string>());           
        }


        [Test]
        public void OpenRgbMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.RgbMenuButton.PerformClick();

            _presenter.MenuPresenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<ShowRgbMenuEventArgs>());
        }

        [Test]
        public void OpenConvolutionMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.ConvolutionMenuButton.PerformClick();

            _presenter.MenuPresenter.Received().OnEventHandler(
                Arg.Is<object>(arg => arg == _form),
                Arg.Any<ShowConvolutionMenuEventArgs>());
        }

        [Test]
        public void OpenDistributionMenuClick()
        {
            _form.OpenFileMenu.PerformClick();
            _form.DistributionMenuButton.PerformClick();

            _presenter.MenuPresenter.Received().OnEventHandler(
               Arg.Is<object>(arg => arg == _form),
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

    }
}
