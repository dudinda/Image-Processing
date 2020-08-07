using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Control;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    /// <inheritdoc cref="IMainView"/>
    internal sealed partial class MainForm : BaseForm, IMainView, IMainFormExposer
    {
        private readonly IMainFormEventBinder _binder;
        private readonly IMainFormCommand _command;

        public MainForm(
            IAppController controller,
            IMainFormEventBinder binder,
            IMainFormCommand command) : base(controller)
        {
            InitializeComponent();

            _command = command;
            _binder = binder;

            _binder.OnElementExpose(this);
            _command.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public Image? SrcImageCopy { get; set; }

        /// <inheritdoc/>
        public Image? DstImageCopy { get; set; }

        /// <inheritdoc/>
        public Image SrcImage
        {
            get => Src.Image;
            set => Src.Image = value;
        }

        /// <inheritdoc/>
        public Image DstImage
        {
            get => Dst.Image;
            set => Dst.Image = value;
        }

        /// <inheritdoc/>
        public string PathToFile
        {
            get => PathToImage.Text;
            set => PathToImage.Text = value;
        }

        /// <inheritdoc/>
        public ToolStripMenuItem SaveAsMenu
            => SaveFileAs;

        /// <inheritdoc/>
        public ToolStripMenuItem OpenFileMenu
            => OpenFile;

        /// <inheritdoc/>
        public ToolStripMenuItem SaveFileMenu
            => SaveFile;

        /// <inheritdoc/>
        public ToolStripButton ReplaceSrcByDstButton
            => ReplaceSrcByDst;

        /// <inheritdoc/>
        public ToolStripButton ReplaceDstBySrcButton
            => ReplaceDstBySrc;

        /// <inheritdoc/>
        public ZoomTrackBar ZoomSrcTrackBar
            => SrcZoom;

        /// <inheritdoc/>
        public ZoomTrackBar ZoomDstTrackBar
            => DstZoom;

        /// <inheritdoc/>
        public ToolStripMenuItem ConvolutionMenuButton
            => ConvolutionMenu;

        /// <inheritdoc/>
        public ToolStripMenuItem RgbMenuButton
            => RgbMenu;

        /// <inheritdoc/>
        public ToolStripMenuItem DistributionMenuButton
            => DistributionMenu;

        public Image SourceImageCopy
        {
            get => SrcImageCopy;
            set => SrcImageCopy = value;
        }
        public Image DestinationImageCopy
        {
            get => DstImageCopy;
            set => DstImageCopy = value;
        }

        public PictureBox SourceBox
            => Src;

        public PictureBox DestinationBox
            => Dst;

        public ToolStripButton UndoButton
            => Undo;

        /// <inheritdoc/>
        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        /// <inheritdoc/>
        public void SetPathToFile(string path)
            => PathToFile = path;
        
        /// <inheritdoc/>
        public void AddToUndoMainMetaInfo((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);

        /// <inheritdoc/>
        public (Bitmap changed, ImageContainer from)? UndoAction()
            => Container.Undo();

        /// <inheritdoc/>
        public (Bitmap changed, ImageContainer from)? RedoAction()
            => Container.Redo();

        /// <inheritdoc/>
        public void ShowInfo(string info)
            => RandomVariableInformation.Show(info, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        /// <inheritdoc/>
        public void Tooltip(string message)
            => ErrorToolTip.Show(message, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        /// <inheritdoc/>
        public void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true)
            => _command.Procedure(
                container.ToString() + nameof(MainViewAction.ResetTrackBar),
                value, isEnabled);

        /// <inheritdoc/>
        public Image ZoomImage(ImageContainer container)
            => (Image)_command.Function(
                container.ToString() + nameof(MainViewAction.Zoom));

        /// <inheritdoc/>
        public void SetImageToZoom(ImageContainer container, Image image)
            => _command.Procedure(
                container.ToString() + nameof(MainViewAction.SetToZoom),
                args: image);

        /// <inheritdoc/>
        public Image GetImageCopy(ImageContainer container)
            => (Image)_command.Function(
                container.ToString() + nameof(MainViewAction.GetCopy));

        /// <inheritdoc/>
        public void SetImageCopy(ImageContainer container, Image copy)
            => _command.Procedure(
                container.ToString() + nameof(MainViewAction.SetCopy),
                args: copy);

        /// <inheritdoc/>
        public void SetImage(ImageContainer container, Image image)
            => _command.Procedure(
                container.ToString() + nameof(MainViewAction.SetImage),
                args: image);

        /// <inheritdoc/>
        public bool ImageIsNull(ImageContainer container)
            => (bool)_command.Function(
                container.ToString() + nameof(MainViewAction.ImageIsNull));

        /// <inheritdoc/>
        public void Refresh(ImageContainer container)
             => _command.Procedure(
                 container.ToString() + nameof(MainViewAction.Refresh));

        /// <inheritdoc/>
        public void SetCursor(CursorType cursor)
            => _command.Procedure(cursor.ToString());
        
        /// <inheritdoc/>
        public void AddToUndoContainer((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);


        /// <summary>
        /// Used by the generated <see cref="Dispose(bool)"/> call.
        /// Can be used by a DI container in a singleton scope on Release();
        public new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }

            Controller.Dispose();

            base.Dispose(true);
        }
    }
}
