using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.UILayer.Control;
using ImageProcessing.App.UILayer.FormCommands.Main;
using ImageProcessing.App.UILayer.FormControl.TrackBar;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormRotation.Interface;
using ImageProcessing.App.UILayer.FormModel.Factory.MainFormZoom.Interface;
using ImageProcessing.App.UILayer.FormModel.MainFormUndoRedo.Interface;
using ImageProcessing.App.UILayer.Properties;
using ImageProcessing.Utility.Interop.Wrapper;

namespace ImageProcessing.App.UILayer.Forms.Main
{
    /// <inheritdoc cref="IMainView"/>
    internal sealed partial class MainForm : BaseForm,
        IMainFormExposer, IMainView
    {
        private readonly IMainFormEventBinder _binder;
        private readonly IMainFormContainerFactory _container;
        private readonly IMainFormUndoRedoFactory _undoRedo;
        private readonly IMainFormZoomFactory _zoom;
        private readonly IMainFormRotationFactory _rotation;

        private Image? _default;
        private Image? _srcCopy;
        private Image? _dstCopy;

        public MainForm(
            IMainFormEventBinder binder,
            IMainFormContainerFactory container,
            IMainFormUndoRedoFactory  undoRedo,
            IMainFormZoomFactory zoom,
            IMainFormRotationFactory rotation) : base()
        {
            InitializeComponent();
            
            _zoom = zoom;
            _binder = binder;
            _undoRedo = undoRedo;
            _rotation = rotation;
            _container = container;
                   
            _binder.OnElementExpose(this);
        }

        /// <inheritdoc/>
        public Image? SrcImage
        {
            get => Src.Image;
            set
            {
                if (value?.Tag is string tag &&
                    tag == nameof(ImageIsDefault))
                {
                    _srcCopy = null; Src.Image = null!;
                    return;
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
                if (value?.Tag is string tag &&
                    tag == nameof(ImageIsDefault))
                {
                    _dstCopy = null; Dst.Image = null!;
                    return;
                }

                Dst.Image = value;
            }
        }

        /// <inheritdoc/>
        public Image? Default
        {
            get => _default ??= Resources.DefaultImage;
        }

        /// <inheritdoc/>
        public Image? SrcImageCopy
        {
            get => _srcCopy ??= Default;
            set => _srcCopy = value;
        }

        /// <inheritdoc/>
        public Image? DstImageCopy
        {
            get => _dstCopy ??= Default;
            set => _dstCopy = value;
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

        /// <inheritdoc/>
        public Image? SourceImage
        {
            get => SrcImage;
            set => SrcImage = value;
        }

        /// <inheritdoc/>
        public Image? DestinationImage
        {
            get => DstImage;
            set => DstImage = value;
        }

        /// <inheritdoc/>
        public ToolStripButton UndoButton
            => UndoBtn;

        /// <inheritdoc/>
        public ToolStripButton RedoButton
            => RedoBtn;

        /// <inheritdoc/>
        public Image? DefaultImage
            => Default;

        /// <inheritdoc/>
        public PictureBox SourceBox
            => Src;

        /// <inheritdoc/>
        public PictureBox DestinationBox
            => Dst;

        /// <inheritdoc/>
        public ToolStripMenuItem SettingsMenuButton
            => SettingsMenu;

        /// <inheritdoc/>
        public RotationTrackBar RotationSrcTrackBar
            => SrcRotation;

        /// <inheritdoc/>
        public RotationTrackBar RotationDstTrackBar
            => DstRotation;

        public System.Windows.Forms.Control.ControlCollection Control
            => Controls;

        public TabControl TabsCtrl => Tabs;

        public ToolStripMenuItem RotationMenuButton
            => RotationMenu;

        public ToolStripMenuItem ScalingMenuButton
            => ScalingMenu;

        /// <inheritdoc/>
        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        /// <inheritdoc/>
        public void SetDefaultImage(ImageContainer container)
            => _container.Get(container).OnElementExpose(this).SetImage(Default);

        /// <inheritdoc/>
        public double GetZoomFactor(ImageContainer container)
            => _zoom.Get(container).OnElementExpose(this).GetFactor();

        /// <inheritdoc/>
        public double GetRotationFactor(ImageContainer container)
            => _rotation.Get(container).OnElementExpose(this).GetFactor();

        /// <inheritdoc/>
        public string GetPathToFile()
            => Read<string>(() => PathToImage.Text );

       /// <inheritdoc/>
        public void SetPathToFile(string path)
            => Write(() => PathToImage.Text = path);
                    
        /// <inheritdoc/>
        public void Tooltip(string message)
            => Write(() => ErrorToolTip.Show(message, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000));

        /// <inheritdoc/>
        public void ResetTrackBarValue(ImageContainer container, int value = 0)
            => Write(() =>
            {
                _zoom.Get(container).OnElementExpose(this).ResetTrackBarValue(value);
                _rotation.Get(container).OnElementExpose(this).ResetTrackBarValue(value);
            });

        /// <inheritdoc/>
        public Image GetImageCopy(ImageContainer container)
            => Read<Image>(() =>_container.Get(container).OnElementExpose(this).GetCopy()!);

        /// <inheritdoc/>
        public void SetImageCopy(ImageContainer container, Image copy)
            => Write(() => _container.Get(container).OnElementExpose(this).SetCopy(copy));

        /// <inheritdoc/>
        public void SetImage(ImageContainer container, Image image)
            => Write(() =>_container.Get(container).OnElementExpose(this).SetImage(image));

        /// <inheritdoc/>
        public bool ImageIsDefault(ImageContainer container)
            => Read<bool>(() => _container.Get(container).OnElementExpose(this).ImageIsDefault());

        /// <inheritdoc/>
        public void Refresh(ImageContainer container)
            => Write(() => _container.Get(container).OnElementExpose(this).Refresh());

        /// <inheritdoc/>
        public void SetCursor(CursorType cursor)
            => Write(() => Application.UseWaitCursor = cursor == CursorType.Wait);

        /// <inheritdoc/>
        public void AddToUndoRedo(ImageContainer to, Bitmap cpy, UndoRedoAction action)
        {
            if (ImageIsDefault(to)) { cpy.Tag = nameof(ImageIsDefault); }

            Write(() => _undoRedo.Get(action).OnElementExpose(this).Add(to, cpy));
        }

        /// <inheritdoc/>
        public (Bitmap, ImageContainer) TryUndoRedo(UndoRedoAction action)
            => Read<(Bitmap, ImageContainer)>(() => _undoRedo.Get(action).OnElementExpose(this).Pop());

        public void SetImageCenter(ImageContainer to, Size size)
             => Write(() => _container.Get(to).OnElementExpose(this).SetImageCenter(size));

        /// <summary>
        /// Used by the generated <see cref="Dispose(bool)"/> call.
        /// Can be used by a DI container in a singleton scope on Release();
        public new void Dispose()
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

        private void MainForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
