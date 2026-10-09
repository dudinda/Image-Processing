using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.Domain.Services.UndoRedo;
using ImageProcessing.App.Domain.Win.Models.Wrapper;
using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.UI.Models.Controls;
using ImageProcessing.App.UI.Properties;
using ImageProcessing.App.UI.Services.Factories.MenuState;
using ImageProcessing.App.UI.Services.FormEventBinders.Main;
using ImageProcessing.App.UI.Services.FormExposers;

using MetroFramework.Controls;

namespace ImageProcessing.App.UI.Forms.Main
{
    /// <inheritdoc cref="IMainView"/>
    internal partial class MainForm : BaseForm,
        IMainFormExposer, IMainView
    {
        private readonly IMainFormEventBinder _binder;
        private readonly IMenuStateFactory _state;
        private readonly IUndoRedoService<Bitmap> _undoredo;

        public MainForm(
            IMainFormEventBinder binder,
            IUndoRedoService<Bitmap> undoredo,
            IMenuStateFactory state) : base()
        {
            InitializeComponent();

            _state = state;
            _binder = binder;
            _undoredo = undoredo;

            SetMenuState(MenuBtnState.ImageEmpty);
        }

        public Image? LoadedImage
        {
            get => Read<Image>(() => field);
            set => Write(() => field = value);
        }

        /// <inheritdoc/>
        public PictureBox SourceBox
            => Src.Container;

        /// <inheritdoc/>
        public Image? SourceImage
        {
            get => SourceBox.Image;
            set => SourceBox.Image = value;
        }

        /// <inheritdoc/>
        public virtual Image? DefaultImage
        {
            get => field ??= Resources.DefaultImage;
        }

        /// <inheritdoc/>
        public Image? SourceImageCopy
        {
            get => field ?? DefaultImage;
            set => field = value;
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
        public ScaleTrackBar ZoomSrcTrackBar
            => SrcZoom;

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

        /// <inheritdoc/>
        public ToolStripButton UndoButton
            => UndoBtn;

        /// <inheritdoc/>
        public ToolStripButton RedoButton
            => RedoBtn;

        /// <inheritdoc/>
        public ToolStripMenuItem SettingsMenuButton
            => SettingsMenu;

        /// <inheritdoc/>
        public RotationTrackBar RotationSrcTrackBar
            => SrcRotation;

        public System.Windows.Forms.Control.ControlCollection Control
            => Controls;

        public MetroTabControl TabsCtrl
            => Tabs;

        public ToolStripMenuItem RotationMenuButton
            => RotationMenu;

        public ToolStripMenuItem ScalingMenuButton
            => ScalingMenu;

        public ToolStripButton SetSourceButton
            => SetSourceBtn;

        /// <inheritdoc/>
        public new void Show()
        {
            _binder.OnElementExpose(this);
            Context.MainForm = this;
            Application.Run(Context);
        }

        /// <inheritdoc/>
        public void SetDefaultImage()
            => SourceImage = DefaultImage;

        /// <inheritdoc/>
        public double GetZoomFactor()
            => ZoomSrcTrackBar.Factor;

        /// <inheritdoc/>
        public double GetRotationFactor()
            => RotationSrcTrackBar.Factor;

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
        public void ResetTrackBarValue(int value = 0)
            => Write(() =>
            {
                RotationSrcTrackBar.TrackBarValue = value;
                RotationSrcTrackBar.Enabled = SourceImage != null;
                RotationSrcTrackBar.Focus();

                ZoomSrcTrackBar.TrackBarValue = value;
                ZoomSrcTrackBar.Enabled = SourceImage != null;
                ZoomSrcTrackBar.Focus();
            });

        /// <inheritdoc/>
        public Image GetImageCopy()
            => Read<Image>(() => SourceImageCopy);

        /// <inheritdoc/>
        public void SetImageCopy(Image copy)
            => Write(() => SourceImageCopy = copy);

        /// <inheritdoc/>
        public void SetImage(Image image)
            => Write(() => SourceImage = image);

        /// <inheritdoc/>
        public bool ImageIsDefault
            => Read<bool>(() => SourceImageCopy == DefaultImage);

        /// <inheritdoc/>
        public void Refresh()
            => Write(() => SourceBox.Refresh());

        /// <inheritdoc/>
        public void SetCursor(CursorType cursor)
            => Write(() => Application.UseWaitCursor = cursor == CursorType.Wait);

        /// <inheritdoc/>
        public void AddToUndoRedo(Bitmap cpy, UndoRedoAction action)
        {
            if (ImageIsDefault)
            {
                cpy.Tag = MenuBtnState.ImageEmpty;
            }

            Write(() =>
            {
                switch (action)
                {
                    case UndoRedoAction.Redo:
                        _undoredo.AddToRedo(cpy);
                        RedoButton.Enabled = !_undoredo.RedoIsEmpty;
                        break;

                    case UndoRedoAction.Undo:
                        _undoredo.AddToUndo(cpy);
                        UndoButton.Enabled = !_undoredo.UndoIsEmpty;
                        break;

                    default: throw new NotSupportedException(nameof(action));
                }
            });
        }

        /// <inheritdoc/>
        public Bitmap TryUndoRedo(UndoRedoAction action)
            => Read<Bitmap>(() =>
            {
                switch (action)
                {
                    
                    case UndoRedoAction.Redo:
                        var redo = _undoredo.Redo();
                        Src.DrawRuler = !Enum.TryParse<MenuBtnState>(redo.Tag?.ToString(), out var _);
                        RedoButton.Enabled = !_undoredo.RedoIsEmpty;
                        return redo;

                    case UndoRedoAction.Undo:
                        var undo = _undoredo.Undo();
                        Src.DrawRuler = !Enum.TryParse<MenuBtnState>(undo.Tag?.ToString(), out var _);
                        UndoButton.Enabled = !_undoredo.UndoIsEmpty;
                        return undo;

                    default: throw new NotSupportedException(nameof(action));
                }
            });

        public void SetImageCenter(Size size)
             => Write(() =>
             {
                 if (SourceBox.Parent is Panel panel)
                 {
                     var newX = (panel.ClientSize.Width - size.Width) / 2;
                     var newY = (panel.ClientSize.Height - size.Height) / 2;

                     if (newX > 0 && newY > 0)
                     {
                         SourceBox.Location = new Point(newX, newY);
                     }

                     if (newX > 0 && newY < 0)
                     {
                         SourceBox.Location = new Point(newX, 0);
                     }

                     if (newX < 0 && newY > 0)
                     {
                         SourceBox.Location = new Point(0, newY);
                     }
                 }
             });

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

        public void SetMenuState(MenuBtnState state)
        {
            var menu = _state.Get(state);

            Write(() =>
            {
                ConvolutionMenu.Enabled = menu.ConvolutionMenuState;
                RgbMenu.Enabled = menu.RgbMenuState;
                SetSourceBtn.Enabled = menu.SetSourceImageState;
                DistributionMenu.Enabled = menu.DistributionMenuState;
                ScalingMenu.Enabled = menu.SettingsMenuState;
                RotationMenu.Enabled = menu.RotationMenuState;
                ScalingMenu.Enabled = menu.ScalingMenuState;
                AffineTransformationMenu.Enabled = menu.TransformationMenuState;
                SettingsMenu.Enabled = menu.SettingsMenuState;
                MorphologyMenu.Enabled = menu.MorphologyMenuState;
                RotationSrcTrackBar.Enabled = menu.RotationTrackBarState;
                ZoomSrcTrackBar.Enabled = menu.ScalingTrackBarState;
            });
        }
    }
}
