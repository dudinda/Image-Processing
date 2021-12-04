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

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form
{
    internal partial class MainFormWrapper : IMainView, IMainFormExposer
    {
        private readonly MainForm _form;

        public event FormClosedEventHandler FormClosed
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


        public Image SrcImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image DstImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image SrcImageCopy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image DstImageCopy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Image DefaultImage => throw new NotImplementedException();

        public UndoRedoSplitContainer SplitContainerCtr => throw new NotImplementedException();

        public Image SourceImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Image DestinationImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public PictureBox SourceBox => throw new NotImplementedException();

        public PictureBox DestinationBox => throw new NotImplementedException();

        public ToolStripMenuItem SaveAsMenu => throw new NotImplementedException();

        public ToolStripMenuItem OpenFileMenu => throw new NotImplementedException();

        public ToolStripMenuItem SaveFileMenu => throw new NotImplementedException();

        public ToolStripButton ReplaceSrcByDstButton => throw new NotImplementedException();

        public ToolStripButton ReplaceDstBySrcButton => throw new NotImplementedException();

        public ScaleTrackBar ZoomSrcTrackBar => throw new NotImplementedException();

        public ScaleTrackBar ZoomDstTrackBar => throw new NotImplementedException();

        public RotationTrackBar RotationSrcTrackBar => throw new NotImplementedException();

        public RotationTrackBar RotationDstTrackBar => throw new NotImplementedException();

        public ToolStripMenuItem ConvolutionMenuButton => throw new NotImplementedException();

        public ToolStripMenuItem RgbMenuButton => throw new NotImplementedException();

        public ToolStripMenuItem DistributionMenuButton => throw new NotImplementedException();

        public ToolStripMenuItem AffineTransformationMenuButton => throw new NotImplementedException();

        public ToolStripMenuItem SettingsMenuButton => throw new NotImplementedException();

        public ToolStripButton UndoButton => throw new NotImplementedException();

        public ToolStripButton RedoButton => throw new NotImplementedException();

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
