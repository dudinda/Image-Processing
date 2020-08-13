using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Control;
using ImageProcessing.App.UILayer.FormCommands.Main.Interface;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.Properties;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    /// <inheritdoc cref="IMainView"/>
    internal partial class MainForm : BaseForm, IMainFormExposer
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

            FormClosed += (sender, args) => controller.Dispose();
        }

        private Image? _default;
        public Image? Default
        {
            get
            {
                if (_default is null)
                {
                    _default = Resources.DefaultImage;
                }

                return _default;
            }
        }


        private Image? _srcCopy;
        /// <inheritdoc/>
        public Image? SrcImageCopy
        {
            get
            {
                if(_srcCopy is null)
                {
                    _srcCopy = Default;
                }

                return _srcCopy;
            }

            set => _srcCopy = value;
        }

        private Image? _dstCopy;
        /// <inheritdoc/>
        public Image? DstImageCopy
        {
            get
            {
                if(_dstCopy is null)
                {
                    _dstCopy = Default;
                }

                return _dstCopy;
            }

            set => _dstCopy = value;
        }
  
        /// <inheritdoc/>
        public Image? SrcImage
        {
            get => Src.Image;
            set
            {
                var tag = value.Tag;

                if (tag != null)
                {
                    if (tag.Equals(nameof(ImageIsDefault)))
                    {
                        _srcCopy = null;
                        Src.Image = null!;
                        return;
                    }
                }
                
                Src.Image = value;
            }
        }

        /// <inheritdoc/>
        public Image? DstImage
        {
            get => Dst.Image;
            set
            {
                var tag = value.Tag;

                if (tag != null)
                {
                    if (tag.Equals(nameof(ImageIsDefault)))
                    {
                        _dstCopy = null;
                        Dst.Image = null!;
                        return;
                    }
                }

                Dst.Image = value;
            }
        }

        /// <inheritdoc/>
        public ToolStripMenuItem SaveAsMenu
            => SaveFileAs;

        /// <inheritdoc/>
        public ToolStripMenuItem OpenFileMenu
            => Read<ToolStripMenuItem>(() => OpenFile);

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

        public UndoRedoSplitContainer SplitContainerCtr
            => SplitContainer;

        public Image? SourceImage
        {
            get => SrcImage;
            set => SrcImage = value;
        }
           

        public Image? DestinationImage
        {
            get => DstImage;
            set => DstImage = value;
        }

        public ToolStripButton UndoButton
            => UndoBtn;

        public ToolStripButton RedoButton
            => RedoBtn;

        public Image? DefaultImage
            => Default;

        public PictureBox SourceBox
            => Src;

        public PictureBox DestinationBox
            => Dst;

        /// <inheritdoc/>
        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        /// <inheritdoc/>
        public virtual string GetPathToFile()
            => Read<string>(() => PathToImage.Text );

       /// <inheritdoc/>
        public virtual void SetPathToFile(string path)
            => Write(() => PathToImage.Text = path);
                    
        /// <inheritdoc/>
        public virtual void Tooltip(string message)
            => Write(() => ErrorToolTip.Show(message, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000));

        /// <inheritdoc/>
        public virtual void ResetTrackBarValue(ImageContainer container, int value = 0)
            => Write(() => _command.Procedure(container.ToString() + nameof(MainViewAction.ResetTrackBar), value));

        /// <inheritdoc/>
        public virtual Image ZoomImage(ImageContainer container)
            => Read<Image>(() => _command.Function(container.ToString() + nameof(MainViewAction.Zoom), null!));

        /// <inheritdoc/>
        public virtual void SetImageToZoom(ImageContainer container, Image image)
            => Write(() => _command.Procedure(container.ToString() + nameof(MainViewAction.SetToZoom), image) );

        /// <inheritdoc/>
        public virtual Image GetImageCopy(ImageContainer container)
            => Read<Image>(() =>_command.Function(container.ToString() + nameof(MainViewAction.GetCopy)));

        /// <inheritdoc/>
        public virtual void SetImageCopy(ImageContainer container, Image copy)
            => Write(() => _command.Procedure(container.ToString() + nameof(MainViewAction.SetCopy), copy));

        /// <inheritdoc/>
        public virtual void SetImage(ImageContainer container, Image image)
            => Write(() =>_command.Procedure(container.ToString() + nameof(MainViewAction.SetImage), image));

        /// <inheritdoc/>
        public virtual bool ImageIsDefault(ImageContainer container)
            => Read<bool>(() => _command.Function(container.ToString() + nameof(MainViewAction.ImageIsNull)));

        /// <inheritdoc/>
        public virtual void Refresh(ImageContainer container)
            => Write(() => _command.Procedure(container.ToString() + nameof(MainViewAction.Refresh)));

        /// <inheritdoc/>
        public virtual void SetCursor(CursorType cursor)
            => Write(() =>_command.Procedure(cursor.ToString()));

        /// <inheritdoc/>
        public virtual void AddToUndoRedo(ImageContainer to, Bitmap cpy, UndoRedoAction action)
            => Write(() => _command.Procedure(action.ToString() + nameof(MainViewAction.AddToUndoRedo), to, cpy));

        /// <inheritdoc/>
        public virtual (Bitmap, ImageContainer) TryUndoRedo(UndoRedoAction action)
            => Read<(Bitmap, ImageContainer)>(() => _command.Function(action.ToString()));
                    
        /// <summary>
        /// Used by the generated <see cref="Dispose(bool)"/> call.
        /// Can be used by a DI container in a singleton scope on Release();
        public virtual new void Dispose()
        {
            if (components != null)
            {
                components.Dispose();
            }    

            base.Dispose(true);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_binder.ProcessCmdKey(this, keyData))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
