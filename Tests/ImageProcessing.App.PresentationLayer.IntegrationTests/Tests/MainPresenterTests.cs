using System;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.PresentationLayer.Presenters.Main;
using ImageProcessing.App.PresentationLayer.UnitTests;
using ImageProcessing.App.PresentationLayer.UnitTests.Extensions;
using ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Components;
using ImageProcessing.App.PresentationLayer.UnitTests.Frames;
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
        private INonBlockDialogService _dialog;
        private IEventAggregatorFake _aggregator;
        private MainPresenter _presenter;
        private IMainFormExposer _form;

        [SetUp]
        public void SetUp()
        {
            AppLifecycle.Build<MainPresenterTestStartup>(DiContainer.Ninject);

            _aggregator = AppLifecycle.Controller.IoC.Resolve<IEventAggregatorFake>();
            _dialog = AppLifecycle.Controller.IoC.Resolve<INonBlockDialogService>();
            _form = AppLifecycle.Controller.IoC.Resolve<IMainFormExposer>();
            _presenter = AppLifecycle.Controller.IoC.Resolve<MainPresenter>();

            _aggregator.Subscribe(_presenter, _form);
        }


        [Test]
        public void FileOpenMenuClick()
        {
            _form.OpenFileMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(s => s == _form),
                Arg.Any<OpenFileDialogEventArgs>());

                _form.When(
                    (form) =>  form.SetImage(
                        Arg.Is<ImageContainer>(s => s == ImageContainer.Source),
                        Arg.Any<Image>())
                 ).Do((call) =>
                 {
                     _dialog.Received().NonBlockOpen(Arg.Any<string>());
                     var image = _form.SourceImage as Bitmap;

                     Assert.IsTrue(image != null);
                     Assert.IsTrue(image.SameAs(Res._1920x1080frame));
                 });
        }

        [Test]
        public void FileSaveAsMenuClick()
        {
            _form.SaveAsMenu.PerformClick();

            _presenter.Received().OnEventHandler(
                Arg.Is<object>(s => s == _form),
                Arg.Any<SaveAsFileDialogEventArgs>());

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
