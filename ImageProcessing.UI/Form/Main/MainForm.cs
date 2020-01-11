using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Presentation.Views.Main;

using MetroFramework.Forms;

namespace ImageProcessing.Form.Main
{
    public partial class MainForm : MetroForm, IMainView
    {
        private readonly ApplicationContext _context;

        public MainForm(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();
            Bind();
            ImageContainer.BringToFront();
        }
    
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

        public bool SrcIsNull => Src.Image is null;
        public bool DstIsNull => Dst.Image is null;
        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public void InitSrcImageZoom()
        {
           // throw new NotImplementedException();
        }

        public void InitDstImageZoom()
        {
           // throw new NotImplementedException();
        }

        public void ShowError(string error)
            => ErrorTooltip.Show(error, this, Cursor.Position.X, Cursor.Position.Y);

    }
}
