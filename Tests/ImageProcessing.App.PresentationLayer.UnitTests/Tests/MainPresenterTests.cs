using System;

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
            _system = Substitute.For<MainSystemFake>();
        }


        [Test]
        public void FileOpenMenuClick()
        {
            _system.Publisher.OpenFileMenu.PerformClick();

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Any<OpenFileDialogEventArgs>());
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
            _system.Publisher.SaveFileMenu.PerformClick();

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }

        [Test]
        public void ReplaceDestinationImageClick()
        {
            _system.Publisher.SaveFileMenu.PerformClick();

            _system.Received().OnEventHandler(
                Arg.Is<object>(s => s == _system.Publisher),
                Arg.Any<SaveWithoutFileDialogEventArgs>());
        }

        [TearDown]
        public void Dispose()
        {
           // _mainView.Dispose();
        }
    }
}
