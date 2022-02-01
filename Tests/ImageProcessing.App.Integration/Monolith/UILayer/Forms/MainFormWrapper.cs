using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.Integration.Monolith.PresentationLayer.Views;
using ImageProcessing.App.Integration.Monolith.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.ServiceLayer.Services.UndoRedo.Interface;
using ImageProcessing.App.UILayer.Control;
using ImageProcessing.App.UILayer.FormControl.TrackBar;
using ImageProcessing.App.UILayer.FormEventBinders.Main.Interface;
using ImageProcessing.App.UILayer.FormExposers.Main;
using ImageProcessing.App.UILayer.Forms.Main;
using ImageProcessing.App.UILayer.UIModel.Factories.MenuState.Interface;

using MetroFramework.Controls;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Fakes.Form
{
    internal partial class MainFormWrapper : IMainViewWrapper, IMainFormExposer
    {
        private class NonUIMainForm : MainForm
        {
            public NonUIMainForm(
                IMainFormEventBinder binder,
                IUndoRedoService<Bitmap> undoredo,
                IMenuStateFactory state) : base(binder, undoredo, state)
            {
             
            }

            protected override void Write(Action action)
                => action();
            protected override TElement Read<TElement>(Func<object> func)
                => (TElement)func();
        }

        private readonly IMainFormEventBinderWrapper _binder;
        private readonly NonUIMainForm _form;

        public MainFormWrapper(
            IMainFormEventBinderWrapper binder,
            IUndoRedoService<Bitmap> undoredo,
            IMenuStateFactory state)
        {
            _form = new NonUIMainForm(binder, undoredo, state);
            _binder = binder;
        }


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


        public virtual Image SrcImage
        {
            set => _form.SrcImage = value;
            get => _form.SrcImage;
        }

        public virtual Image SrcImageCopy
        {
            set => _form.SrcImageCopy = value;
            get => _form.SrcImageCopy;
        }

        public virtual Image DefaultImage
            => _form.DefaultImage;

        public virtual Image SourceImage
        {
            set => _form.SourceImage = value;
            get => _form.SourceImage;
        }
        public virtual PictureBox SourceBox
            => _form.SourceBox;

        public virtual ToolStripMenuItem SaveAsMenu
            => _form.SaveAsMenu;

        public virtual ToolStripMenuItem OpenFileMenu
            => _form.OpenFileMenu;

        public virtual ToolStripMenuItem SaveFileMenu
            => _form.SaveFileMenu;

        public virtual ScaleTrackBar ZoomSrcTrackBar
            => _form.ZoomSrcTrackBar;

        public virtual RotationTrackBar RotationSrcTrackBar
            => _form.RotationSrcTrackBar;

        public virtual ToolStripMenuItem ConvolutionMenuButton
            => _form.ConvolutionMenuButton;

        public virtual ToolStripMenuItem RgbMenuButton
            => _form.RgbMenuButton;

        public virtual ToolStripMenuItem DistributionMenuButton
            => _form.DistributionMenuButton;

        public virtual ToolStripMenuItem AffineTransformationMenuButton
            => _form.AffineTransformationMenuButton;

        public virtual ToolStripMenuItem SettingsMenuButton
            => _form.SettingsMenuButton;

        public virtual ToolStripButton UndoButton
            => _form.UndoButton;

        public virtual ToolStripButton RedoButton
            => _form.RedoButton;

        public ToolStripMenuItem RotationMenuButton
            => _form.RotationMenuButton;

        public ToolStripMenuItem ScalingMenuButton
            => _form.ScalingMenuButton;

        public MetroTabControl TabsCtrl
            => _form.TabsCtrl;

        public Image LoadedImage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ToolStripButton SetSourceButton => throw new NotImplementedException();

        public virtual void SetDefaultImage()
            => _form.SetDefaultImage();

        public virtual void SetPathToFile(string path)
            => _form.SetPathToFile(path);

        public virtual string GetPathToFile()
            => _form.GetPathToFile();

        public virtual void AddToUndoRedo(Bitmap bmp, UndoRedoAction action)
            => _form.AddToUndoRedo(bmp, action);
      
        public virtual Bitmap TryUndoRedo(UndoRedoAction action)
            => _form.TryUndoRedo(action);
     
        public virtual void SetImageCenter(Size size)
            => _form.SetImageCenter(size);
       
        public virtual void Close()
            => _form.Close();
     
        public virtual bool Focus()
            => _form.Focus();
    
        public virtual void ResetTrackBarValue(int value = 0)
            => _form.ResetTrackBarValue(value);
       
        public virtual double GetZoomFactor()
            => _form.GetZoomFactor();
      
        public virtual double GetRotationFactor()
            => _form.GetRotationFactor();
       
        public virtual void Tooltip(string message)
            => _form.Tooltip(message);
    
        public virtual Image GetImageCopy()
            => _form.GetImageCopy();
      
        public virtual void SetImageCopy(Image copy)
            => _form.SetImageCopy(copy);

        public virtual void SetImage(Image image)
            => _form.SetImage(image);
       
        public virtual bool ImageIsDefault()
            => _form.ImageIsDefault();
     
        public virtual void Refresh()
            => _form.Refresh();
        
        public virtual void SetCursor(CursorType cursor)
            => _form.SetCursor(cursor);
       
        public virtual void Dispose()
            => _form.Dispose();
       
        public virtual void Show()
        {
            _binder.OnElementExpose(this);
        }

        public void SetMenuState(MenuBtnState state)
        {
            throw new NotImplementedException();
        }
    }
}
