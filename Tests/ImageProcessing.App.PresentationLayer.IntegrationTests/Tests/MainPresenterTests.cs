using System;
using System.Drawing;
using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs;
using ImageProcessing.App.DomainLayer.DomainEvent.FileDialogArgs;
using ImageProcessing.App.PresentationLayer.IntegrationTests.Fakes;

using NSubstitute;
using NSubstitute.ReceivedExtensions;

using NUnit.Framework;

namespace ImageProcessing.App.PresentationLayer.IntegrationTests.Tests
{
    [TestFixture]
    public class MainPresenterTests : IDisposable
    {
        private MainSystemFake _system;

        [SetUp]
        public void SetUp()
        {
            _system = Substitute.ForPartsOf<MainSystemFake>();
        }


        [Test]
        public void FileOpenMenuClick()
        {
            _system.Publisher.OpenFileMenu.PerformClick();

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Any<OpenFileDialogEventArgs>());

            _system.Dialog.Received().NonBlockOpen(Arg.Any<string>());


        }

        [Test]
        public void FileSaveAsMenuClick()
        {
            _system.Publisher.SaveAsMenu.PerformClick();

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Any<SaveAsFileDialogEventArgs>());

        }

        [Test]
        public void FileSaveMenuClick()
        {
            _system.Publisher.SaveFileMenu.PerformClick();

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }

        [Test]
        public void ReplaceSourceImageClick()
        {
            _system.Publisher.ReplaceSrcByDstButton.Enabled = true;
            _system.Publisher.ReplaceSrcByDstButton.PerformClick();

            var container = ImageContainer.Destination;

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Is<ReplaceImageEventArgs>(arg => arg.Container == container));
        }

        [Test]
        public void ReplaceDestinationImageClick()
        {
            _system.Publisher.ReplaceDstBySrcButton.Enabled = true;
            _system.Publisher.ReplaceDstBySrcButton.PerformClick();

            var container = ImageContainer.Source;

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Is<ReplaceImageEventArgs>(arg => arg.Container == container));
        }

        [TearDown]
        public void Dispose()
        {
           _system.Publisher.Dispose();
        }
    }
}
