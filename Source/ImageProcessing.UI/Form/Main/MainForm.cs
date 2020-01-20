using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Common.Interop;
using ImageProcessing.Presentation.Views.Main;

using MetroFramework.Forms;

namespace ImageProcessing.Form.Main
{
    public partial class MainForm : MetroForm, IMainView
    {
        private readonly ApplicationContext _context;

        public MainForm(ApplicationContext context)
        {
            _context = Requires.IsNotNull(context, nameof(context));

            InitializeComponent();
            Bind();
            Container.BringToFront();
        }

        public Image SrcImageCopy { get; set; }
        public Image DstImageCopy { get; set; }

        public Image SrcImage { 
            get => Src.Image;
            set => Src.Image = value;
        }  
        public Image DstImage { 
            get => Dst.Image;  
            set => Dst.Image = value; 
        }
        public string PathToFile { 
            get => PathToImage.Text; 
            set => PathToImage.Text = value;
        }
        public bool IsGreenChannelChecked {
            get => ColorFilterGreen.Checked;
            set => ColorFilterGreen.Checked = value;
        }
        public bool IsRedChannelChecked {
            get => ColorFilterRed.Checked;
            set => ColorFilterRed.Checked = value;
        }
        public bool IsBlueChannelChecked {
            get => ColorFilterBlue.Checked;
            set => ColorFilterBlue.Checked = value;
        }

        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);
    
        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public Size GetZoomFactor(ImageContainer container)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    return SrcZoom.FactorSize;
                case ImageContainer.Destination:
                    return DstZoom.FactorSize;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public bool ImageIsNull(ImageContainer container)
        {
            switch(container)
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

        public Image GetImage(ImageContainer container)
        {
            switch(container)
            {
                case ImageContainer.Source:
                    return Src.Image;
                case ImageContainer.Destination:
                    return Dst.Image;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void SetImage(ImageContainer container, Image image)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    Src.Image = image;
                    break;
                case ImageContainer.Destination:
                    Dst.Image = image;
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void ResetTrackBarValue(ImageContainer container, int value = 0)
        {
            switch (container)
            {
                case ImageContainer.Source:
                    SrcZoom.TrackBarValue = value;
                    SrcZoom.Focus();
                    break;
                case ImageContainer.Destination:
                    DstZoom.TrackBarValue = value;
                    DstZoom.Focus();
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public void SetTrackBarSize(ImageContainer container, Size size)
        {
            switch(container)
            {
                case ImageContainer.Source:
                    SrcZoom.OriginalSize  = size;
                    break;
                case ImageContainer.Destination:
                    DstZoom.OriginalSize  = size;
                    break;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public Size GetImageCopySize(ImageContainer container)
        {
            switch(container)
            {
                case ImageContainer.Source:
                    return SrcImageCopy.Size;
                case ImageContainer.Destination:
                    return DstImageCopy.Size;

                default: throw new NotSupportedException(nameof(container));
            }
        }

        public RGBColors GetSelectedColors(RGBColors color)
        {
            var result = default(RGBColors);

            switch (color)
            {
                case RGBColors.Red:
                    IsRedChannelChecked = !IsRedChannelChecked;               
                    break;

                case RGBColors.Blue:
                    IsBlueChannelChecked = !IsBlueChannelChecked;
                    break;

                case RGBColors.Green:
                    IsGreenChannelChecked = !IsGreenChannelChecked;              
                    break;

                default:throw new NotSupportedException(nameof(color));
            }

            if (IsRedChannelChecked)   result |= RGBColors.Red;
            if (IsBlueChannelChecked)  result |= RGBColors.Blue;
            if (IsGreenChannelChecked) result |= RGBColors.Green;

            return result;
        } 

        public void ShowInfo(string info)
            => RandomVariableInfo.Show(info, this, CursorPosition.GetCursorPosition());

        public void ShowError(string error)
            => ErrorTooltip.Show(error, this, CursorPosition.GetCursorPosition());

    }
}
