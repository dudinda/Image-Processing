using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Control;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.App.UILayer.Properties;
using ImageProcessing.Microkernel.MVP.Controller.Interface;
using ImageProcessing.Utility.Interop.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    /// <inheritdoc cref="IMainView"/>
    internal partial class MainForm : BaseForm,
        IMainFormExposer, IMainView
    {
        private readonly IMainFormEventBinder _binder;
        private readonly IMainFormContainerFactory _container;
        private readonly IMainFormUndoRedoFactory _undoRedo;
        private readonly IMainFormZoomFactory _zoom;

        public MainForm(
            IAppController controller,
            IMainFormEventBinder binder,
            IMainFormContainerFactory container,
            IMainFormUndoRedoFactory  undoRedo,
            IMainFormZoomFactory zoom) : base(controller)
        {
            InitializeComponent();

            _zoom = zoom;
            _binder = binder;
            _undoRedo = undoRedo;
            _container = container;
                   
            _binder.OnElementExpose(this);

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
        public ScaleTrackBar ZoomSrcTrackBar
            => SrcZoom;

        /// <inheritdoc/>
        public ScaleTrackBar ZoomDstTrackBar
            => DstZoom;

        /// <inheritdoc/>
        public ToolStripMenuItem ConvolutionMenuButton
            => ConvolutionMenu;

        /// <inheritdoc/>
        public ToolStripMenuItem RgbMenuButton
            => RgbMenu;

        /// <inheritdoc/>
        public ToolStripMenuItem AffineTransformationMenuButton
            => AffineTransformationMenu;

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

        public ToolStripMenuItem SettingsMenuButton
            => SettingsMenu;

        /// <inheritdoc/>
        public virtual new void Show()
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
            => Write(() => _zoom.Get(container).OnElementExpose(this).ResetTrackBarValue(value));

        /// <inheritdoc/>
        public virtual Image GetImageCopy(ImageContainer container)
            => Read<Image>(() =>_container.Get(container).OnElementExpose(this).GetCopy()!);

        /// <inheritdoc/>
        public virtual void SetImageCopy(ImageContainer container, Image copy)
            => Write(() => _container.Get(container).OnElementExpose(this).SetCopy(copy));

        /// <inheritdoc/>
        public virtual void SetImage(ImageContainer container, Image image)
            => Write(() =>_container.Get(container).OnElementExpose(this).SetImage(image));

        /// <inheritdoc/>
        public virtual bool ImageIsDefault(ImageContainer container)
            => Read<bool>(() => _container.Get(container).OnElementExpose(this).ImageIsDefault());

        /// <inheritdoc/>
        public virtual void Refresh(ImageContainer container)
            => Write(() => _container.Get(container).OnElementExpose(this).Refresh());

        /// <inheritdoc/>
        public virtual void SetCursor(CursorType cursor)
            => Write(() => Application.UseWaitCursor = cursor == CursorType.Wait);

        /// <inheritdoc/>
        public virtual void AddToUndoRedo(ImageContainer to, Bitmap cpy, UndoRedoAction action)
        {
            if (ImageIsDefault(to))
            {
                cpy.Tag = nameof(ImageIsDefault);
            }

            Write(() => _undoRedo.Get(action).OnElementExpose(this).Add(to, cpy));
        }

        /// <inheritdoc/>
        public virtual (Bitmap, ImageContainer) TryUndoRedo(UndoRedoAction action)
            => Read<(Bitmap, ImageContainer)>(() => _undoRedo.Get(action).OnElementExpose(this).Pop());

        public double GetTrackBarValue(ImageContainer container)
            => Read<double>(() => _zoom.Get(container).OnElementExpose(this).GetFactor());

        public void SetImageCenter(ImageContainer to, Size size)
             => Write(() => _container.Get(to).OnElementExpose(this).SetImageCenter(size));

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
