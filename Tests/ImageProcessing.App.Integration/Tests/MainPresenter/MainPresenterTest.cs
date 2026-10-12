using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

using ImageProcessing.App.Domain.Services.Pipeline.Implementation;
using ImageProcessing.App.Integration.Code.Resources;
using ImageProcessing.App.Integration.Monolith.Presentation.Presenters;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.FileDialog;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Menu;
using ImageProcessing.App.Presentation.DomainEvents.MainArgs.Show;
using ImageProcessing.App.Presentation.UnitTests.Extensions;
using ImageProcessing.App.UI.Services.FormExposers;

using NSubstitute;
using NSubstitute.ReceivedExtensions;

using NUnit.Framework;

namespace ImageProcessing.App.Presentation.IntegrationTests.Tests
{
    [TestFixture]
    public class MainPresenterTest : BaseTest<Integration.Monolith.UI.Startup>
    {
        private MainPresenterWrapper _presenter;
        private IMainFormExposer _form;

        [SetUp]
        public void SetUp()
        {
            _presenter = _ioc.Resolve<MainPresenterWrapper>();
            _presenter.Run();
            _form = _presenter.View as IMainFormExposer;
        }

        [Test]
        [Timeout(5000)]
        public async Task RendererRecieveBlockTest()
        {
            _presenter.Pipeline.BeginRender();
            _form.OpenFileMenu.PerformClick();
            var view = _presenter.View;
            while (view.SourceImage == null)
            {
                await Task.Delay(300);
            }
            view.Received().SetCursor(
                Arg.Is<CursorType>(arg => arg == CursorType.Wait));

            _presenter.Pipeline.Received().Register(Arg.Any<PipelineBlock>());
            await _presenter.Reference.Received().SetCopy(
                Arg.Is<Bitmap>(arg => arg.SameAs(Res._1920x1080frame)));

            view.Received().GetImageCopy();
            view.Received().AddToUndoRedo(
                Arg.Is<Bitmap>(arg => arg.SameAs(UI.Properties.Resources.DefaultImage)),
                Arg.Is<UndoRedoAction>(arg => arg == UndoRedoAction.Undo));
            view.Received().SetImageCopy(
                Arg.Is<Bitmap>(arg => arg.SameAs(Res._1920x1080frame)));
            view.Received().SetImage(
                Arg.Is<Bitmap>(arg => arg.SameAs(Res._1920x1080frame)));
            view.Received().SetImageCenter(
                Arg.Is<Size>(arg => arg == Res._1920x1080frame.Size));
            view.Received().Refresh();
            view.Received().ResetTrackBarValue();

            _presenter.Pipeline.Received().Any();

            view.Received().SetCursor(
                Arg.Is<CursorType>(arg => arg == CursorType.Default));
        }
    }
}
