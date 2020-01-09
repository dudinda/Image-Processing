using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Presentation.Views.Main;
using ImageProcessing.RGBFilters.ColorFilter.Colors;

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

        public event Action SaveImage;
        public event Action<string> OpenImage;
        public event Action<string> ApplyConvolutionFilter;
        public event Action<string, (string, string)> ApplyHistogramTransformation;
        public event Action<string> ApplyRGBFilter;
        public event Action<RGBColor> ApplyRGBColorFilter;
        public event Action Shuffle;
        public event Action<Keys> GetRandomVariableInfo;
        public event Action UndoLast;
        public event Action BuildPmf;
        public event Action BuildCdf;
        public event Action BuildLuminanceIntervals;

        public Bitmap SrcImage { 
            get => new Bitmap(Src.Image);
            set => Src.Image = value;
        }  
        public Bitmap DstImage { 
            get => new Bitmap(Dst.Image);  
            set => Dst.Image = value; 
        }
        public string Path { 
            get => PathToImage.Text; 
            set => PathToImage.Text = value;
        }
        public bool SrcIsNull => Src.Image is null;
        public bool DstIsNull => Dst.Image is null;
        public (string, string) Parameters => (FirstParam.Text, SecondParam.Text);

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
        {
            ErrorTooltip.Show(error, this, Cursor.Position.X, Cursor.Position.Y);
        }

        /// <summary>
        /// Bind the main window event handlers
        /// </summary>
        private void Bind()
        {
            BindFileMenu();
            BindToolbar();
            BindConvolutionFilters();
            BindRGBFilters();
            BindDistributions();
        }

        /// <summary>
        /// Bind event handlers for a file menu
        /// </summary>
        private void BindFileMenu()
        {
            OpenFile.Click += (sender, args)
               => Invoke(OpenImage);

            SaveFile.Click += (sender, args)
                => Invoke(SaveImage);

            SaveFileAs.Click += (sender, args)
                => Invoke(SaveImage);
        }

        /// <summary>
        /// Bind event handlers for a toolbar menu
        /// </summary>
        private void BindToolbar()
        {          
            ShuffleSrc.Click += (sender, args)
                => Invoke(Shuffle);

            PMF.Click += (sender, args)
                => Invoke(BuildPmf);

            CDF.Click += (sender, args)
                => Invoke(BuildCdf);

            Expectation.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Control.ModifierKeys);

            Variance.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Control.ModifierKeys);

            StandardDeviation.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Control.ModifierKeys);

            Entropy.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Control.ModifierKeys);

            Undo.Click += (sender, args)
                => Invoke(UndoLast);
        }

        private void BindConvolutionFilters()
        {
            GaussianBlur3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, GaussianBlur3x3.Tag);

            GaussianBlur5x5.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, GaussianBlur5x5.Tag);

            BoxBlur3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, BoxBlur3x3.Tag);

            BoxBlur5x5.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, BoxBlur5x5.Tag);

            MotionBlur9x9.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, MotionBlur9x9.Tag);

            LaplacianOfGaussianOperator.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, LaplacianOfGaussianOperator.Tag);

            LaplacianOperator5x5.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, LaplacianOperator5x5.Tag);

            LaplacianOperator3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, LaplacianOperator3x3.Tag);

            Emboss3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, Emboss3x3.Tag);

            Sharpen3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, Sharpen3x3.Tag);

            SobelOperator.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, SobelOperator.Tag);
        }

        private void BindRGBFilters()
        {
            InversionFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, (string)InversionFilter.Tag);

            BinaryFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, (string)BinaryFilter.Tag);

            GrayscaleFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, (string)GrayscaleFilter.Tag);
        }

        private void BindDistributions()
        {
            ExponentialDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, (string)ExponentialDistribution.Tag, Parameters);

            ParabolaDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, (string)ParabolaDistribution.Tag, Parameters);

            RayleighDistribution.Click += (sender, args) 
                => Invoke(ApplyHistogramTransformation, (string)RayleighDistribution.Tag, Parameters);

            CauchyDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, (string)CauchyDistribution.Tag, Parameters);

            LaplaceDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, (string)LaplaceDistribution.Tag, Parameters);

            NormalDistribution.Click += (sender, args) 
                => Invoke(ApplyHistogramTransformation, (string)NormalDistribution.Tag, Parameters);

            UniformDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, (string)UniformDistribution.Tag, Parameters);

            WeibullDistribution.Click += (sender, args) 
                => Invoke(ApplyHistogramTransformation, (string)WeibullDistribution.Tag, Parameters);
        }

        private void Invoke<T1, T2>(Action<T1, T2> action, T1 first, T2 second)
        => action?.Invoke(first, second);
        private void Invoke<T>(Action<T> action, T parameter)
        => action?.Invoke(parameter);
        private void Invoke(Action action)
        => action?.Invoke();
    }
}
