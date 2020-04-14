using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.DI.Controller.Interface;
using ImageProcessing.Utility.Interop.Code.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    internal sealed partial class MainForm : BaseMainForm, IMainView
    {
        public MainForm(ApplicationContext context,
                        IAppController controller)
            : base(context, controller)
        {
            InitializeComponent();
            Bind();
        }

        public Image SrcImageCopy { get; set; }
        public Image DstImageCopy { get; set; }

        public Image SrcImage
        {
            get => Src.Image;
            set => Src.Image = value;
        }

        public Image DstImage
        {
            get => Dst.Image;
            set => Dst.Image = value;
        }

        public string PathToFile
        {
            get => PathToImage.Text;
            set => PathToImage.Text = value;
        }

        public bool IsGreenChannelChecked
        {
            get => ColorFilterGreen.Checked;
            set => ColorFilterGreen.Checked = value;
        }

        public bool IsRedChannelChecked
        {
            get => ColorFilterRed.Checked;
            set => ColorFilterRed.Checked = value;
        }

        public bool IsBlueChannelChecked
        {
            get => ColorFilterBlue.Checked;
            set => ColorFilterBlue.Checked = value;
        }

        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);

        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        public bool ImageIsNull(ImageContainer container)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    return Src.Image is null;
                case ImageContainer.Destination:
                    return Dst.Image is null;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void SetImageCopy(ImageContainer container, Image copy)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    SrcImageCopy = copy;
                    break;
                case ImageContainer.Destination:
                    DstImageCopy = copy;
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void AddToUndoContainer((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);
        
        public (Bitmap changed, ImageContainer from)? UndoAction()
            => Container.Undo();
       
        public (Bitmap changed, ImageContainer from)? RedoAction()
            => Container.Redo();
        
        public void Refresh(ImageContainer container)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    Src.Refresh();
                    break;
                case ImageContainer.Destination:
                    Dst.Refresh();
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public Image GetImageCopy(ImageContainer container)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    return SrcImageCopy;
                case ImageContainer.Destination:
                    return DstImageCopy;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void SetImage(ImageContainer container, Image image)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    SrcImage = image;
                    Undo.Enabled = true;
                    break;
                case ImageContainer.Destination:
                    DstImage = image;
                    Undo.Enabled = true;
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    SrcZoom.TrackBarValue = value;
                    SrcZoom.Enabled = isEnabled;
                    SrcZoom.Focus();
                    break;
                case ImageContainer.Destination:
                    DstZoom.TrackBarValue = value;
                    DstZoom.Enabled = isEnabled;
                    DstZoom.Focus();
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public Image ZoomImage(ImageContainer container)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    return SrcZoom.Zoom();
                case ImageContainer.Destination:
                    return DstZoom.Zoom();

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void SetImageToZoom(ImageContainer container, Image image)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    SrcZoom.ImageToZoom = image;
                    break;
                case ImageContainer.Destination:
                    DstZoom.ImageToZoom = image;
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public RgbColors GetSelectedColors(RgbColors color)
        {
            var result = default(RgbColors);

            switch (color)
            {
                case RgbColors.Red:
                    IsRedChannelChecked   = !IsRedChannelChecked;
                    break;

                case RgbColors.Blue:
                    IsBlueChannelChecked  = !IsBlueChannelChecked;
                    break;

                case RgbColors.Green:
                    IsGreenChannelChecked = !IsGreenChannelChecked;
                    break;

                default: throw new NotSupportedException(nameof(color));
            }

            if (IsRedChannelChecked)   result |= RgbColors.Red;
            if (IsBlueChannelChecked)  result |= RgbColors.Blue;
            if (IsGreenChannelChecked) result |= RgbColors.Green;

            return result;
        }

        public void SetCursor(CursorType cursor)
        {
            switch (cursor)
            {
                case CursorType.Default:
                    Application.UseWaitCursor = false;
                    break;
                case CursorType.Wait:
                    Application.UseWaitCursor = true;
                    break;

                default: throw new NotImplementedException(nameof(cursor));

            }
        }

        public void ShowInfo(string info)
            => RandomVariableInformation.Show(info, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        public void ShowError(string error)
            => ErrorToolTip.Show(error, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        public void AddToQualityMeasureContainer(Bitmap transformed)
            => QualityMeasure.Add(transformed);     
    }
}
