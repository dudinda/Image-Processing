using System;
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
using ImageProcessing.App.UILayer.Forms.Main;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form
{
    internal partial class MainFormWrapper : IMainView, IMainFormExposer
    {
        private readonly MainForm _form;

        public virtual event FormClosedEventHandler FormClosed
        {
            add
            {
                _form.FormClosed += value;
            }
            remove
            {
                _form.FormClosed -= value;
            }
        }


        public virtual Image SrcImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Image DstImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Image SrcImageCopy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Image DstImageCopy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual Image DefaultImage => throw new NotImplementedException();

        public virtual UndoRedoSplitContainer SplitContainerCtr => throw new NotImplementedException();

        public virtual Image SourceImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public virtual Image DestinationImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public virtual PictureBox SourceBox => throw new NotImplementedException();

        public virtual PictureBox DestinationBox => throw new NotImplementedException();

        public virtual ToolStripMenuItem SaveAsMenu => throw new NotImplementedException();

        public virtual ToolStripMenuItem OpenFileMenu => throw new NotImplementedException();

        public virtual ToolStripMenuItem SaveFileMenu => throw new NotImplementedException();

        public virtual ToolStripButton ReplaceSrcByDstButton => throw new NotImplementedException();

        public virtual ToolStripButton ReplaceDstBySrcButton => throw new NotImplementedException();

        public virtual ScaleTrackBar ZoomSrcTrackBar => throw new NotImplementedException();

        public virtual ScaleTrackBar ZoomDstTrackBar => throw new NotImplementedException();

        public virtual RotationTrackBar RotationSrcTrackBar => throw new NotImplementedException();

        public virtual RotationTrackBar RotationDstTrackBar => throw new NotImplementedException();

        public virtual ToolStripMenuItem ConvolutionMenuButton => throw new NotImplementedException();

        public virtual ToolStripMenuItem RgbMenuButton => throw new NotImplementedException();

        public virtual ToolStripMenuItem DistributionMenuButton => throw new NotImplementedException();

        public virtual ToolStripMenuItem AffineTransformationMenuButton => throw new NotImplementedException();

        public virtual ToolStripMenuItem SettingsMenuButton => throw new NotImplementedException();

        public virtual ToolStripButton UndoButton => throw new NotImplementedException();

        public virtual ToolStripButton RedoButton => throw new NotImplementedException();

        public ToolStripMenuItem RotationMenuButton => throw new NotImplementedException();

        public ToolStripMenuItem ScalingMenuButton => throw new NotImplementedException();

        public MetroTabControl TabsCtrl => throw new NotImplementedException();

        public MainFormWrapper(
            IMainFormEventBinder binder,
            IMainFormContainerFactory container,
            IMainFormUndoRedoFactory undoRedo,
            IMainFormZoomFactory zoom,
            IMainFormRotationFactory rotation)
        {
            
        }


        public void SetDefaultImage(ImageContainer container)
        {
            throw new NotImplementedException();
        }

        public void SetPathToFile(string path)
        {
            throw new NotImplementedException();
        }

        public string GetPathToFile()
        {
            throw new NotImplementedException();
        }

        public void AddToUndoRedo(ImageContainer to, Bitmap bmp, UndoRedoAction action)
        {
            throw new NotImplementedException();
        }

        public (Bitmap, ImageContainer) TryUndoRedo(UndoRedoAction action)
        {
            throw new NotImplementedException();
        }

        public void SetImageCenter(ImageContainer to, Size size)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public bool Focus()
        {
            throw new NotImplementedException();
        }

        public void ResetTrackBarValue(ImageContainer container, int value = 0)
        {
            throw new NotImplementedException();
        }

        public double GetZoomFactor(ImageContainer container)
        {
            throw new NotImplementedException();
        }

        public double GetRotationFactor(ImageContainer container)
        {
            throw new NotImplementedException();
        }

        public void Tooltip(string message)
        {
            throw new NotImplementedException();
        }

        public Image GetImageCopy(ImageContainer container)
        {
            throw new NotImplementedException();
        }

        public void SetImageCopy(ImageContainer container, Image copy)
        {
            throw new NotImplementedException();
        }

        public void SetImage(ImageContainer container, Image image)
        {
            throw new NotImplementedException();
        }

        public bool ImageIsDefault(ImageContainer container)
        {
            throw new NotImplementedException();
        }

        public void Refresh(ImageContainer container)
        {
            throw new NotImplementedException();
        }

        public void SetCursor(CursorType cursor)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            
        }
    }
}
