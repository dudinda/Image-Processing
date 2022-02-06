using System.Drawing;

using ImageProcessing.App.Integration.Code.Resources;
using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Container;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.PresentationLayer.DomainEvents.MainArgs.Show;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;
using ImageProcessing.App.PresentationLayer.UnitTests.TestsComponents.Wrappers.Presenters;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Services.Pipeline;
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
            _form = AppLifecycle.Controller.IoC.Resolve<IMainViewWrapper>() as IMainFormExposer;
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
            Assert.IsTrue(image.SameAs(new Bitmap(Res._1920x1080frame)));
        }

        [Test]
        public void RendererRecieveBlockTest()
        {
            _form.OpenFileMenu.PerformClick();
            var view = _form as IMainViewWrapper;
            Received.InOrder(() =>
            {
                view.Received().SetCursor(CursorType.Wait);
                _presenter.Pipeline.Received().Register(Arg.Any<PipelineBlock>());
                _presenter.Pipeline.Received().AwaitResult();

                var container = ImageContainer.Source;

                view.Received().GetImageCopy();
                view.Received().AddToUndoRedo(
                    Arg.Is<Bitmap>(Res._1920x1080frame), UndoRedoAction.Undo);
                view.Received().SetImageCopy(Arg.Any<Bitmap>());
                view.Received().SetImage(Arg.Any<Bitmap>());
                view.SetImageCenter(Res._1920x1080frame.Size);
                view.Received().Refresh();
                view.Received().ResetTrackBarValue();

                _presenter.Cache.Received().Reset();
                _presenter.Pipeline.Received().Any();

                view.Received().SetCursor(CursorType.Default);
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
                Arg.Is<Bitmap>(bmp => bmp == _form.SrcImageCopy),
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

    }
}
