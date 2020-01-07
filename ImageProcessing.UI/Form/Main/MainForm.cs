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

            Src.SizeMode = PictureBoxSizeMode.AutoSize;
            Dst.SizeMode = PictureBoxSizeMode.AutoSize;

            ImageContainer.BringToFront();
        }

        public event Action SaveImage;
        public event Action OpenImage;
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

        public Bitmap SrcImage { get { return new Bitmap(Src.Image); } set { Src.Image = value; } }
        public Bitmap DstImage { get { return new Bitmap(Dst.Image); } set { Dst.Image = value; } }
        public bool SrcIsNull => Src.Image is null;
        public bool DstIsNull => Dst.Image is null;
        public string Path { get { return PathToImage.Text; } set { PathToImage.Text = value; } }
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

        private void Bind()
        {
            BindFileMenu();
            BindToolbar();
            BindConvolutionFilters();
            BindRGBFilters();
            BindDistributions();
        }

        private void BindFileMenu()
        {
            OpenFile.Click += (sender, args)
               =>
            Invoke(OpenImage);

            SaveFile.Click += (sender, args)
                =>
            Invoke(SaveImage);

            SaveFileAs.Click += (sender, args)
                =>
            Invoke(SaveImage);
        }

        private void BindToolbar()
        {          
            ShuffleSrc.Click += (sender, args)
                =>
            Invoke(Shuffle);

            PMF.Click += (sender, args)
                =>
            Invoke(BuildPmf);

            CDF.Click += (sender, args)
                =>
            Invoke(BuildCdf);

            Expectation.Click += (sender, args)
                =>
            InvokeWithParameter(GetRandomVariableInfo, Control.ModifierKeys);

            Variance.Click += (sender, args)
                =>
              InvokeWithParameter(GetRandomVariableInfo, Control.ModifierKeys);

            StandardDeviation.Click += (sender, args)
                =>
            InvokeWithParameter(GetRandomVariableInfo, Control.ModifierKeys);

            Entropy.Click += (sender, args)
                =>
             InvokeWithParameter(GetRandomVariableInfo, Control.ModifierKeys);

            Undo.Click += (sender, args)
                =>
            Invoke(UndoLast);
        }

        private void BindConvolutionFilters()
        {
            GaussianBlur3x3.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, GaussianBlur3x3.Tag);

            GaussianBlur5x5.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, GaussianBlur5x5.Tag);

            BoxBlur3x3.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, BoxBlur3x3.Tag);

            BoxBlur5x5.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, BoxBlur5x5.Tag);

            MotionBlur9x9.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, MotionBlur9x9.Tag);

            LaplacianOfGaussianOperator.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, LaplacianOfGaussianOperator.Tag);

            LaplacianOperator5x5.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, LaplacianOperator5x5.Tag);

            LaplacianOperator3x3.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, LaplacianOperator3x3.Tag);

            Emboss3x3.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, Emboss3x3.Tag);

            Sharpen3x3.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, Sharpen3x3.Tag);

            SobelOperator.Click += (sender, args)
                =>
            Invoke(ApplyConvolutionFilter, SobelOperator.Tag);
        }

        private void BindRGBFilters()
        {
            InversionFilter.Click += (sender, args)
                =>
            InvokeWithParameter(ApplyRGBFilter, (string)InversionFilter.Tag);

            BinaryFilter.Click += (sender, args)
             =>
            InvokeWithParameter(ApplyRGBFilter, (string)BinaryFilter.Tag);

            GrayscaleFilter.Click += (sender, args)
             =>
            InvokeWithParameter(ApplyRGBFilter, (string)GrayscaleFilter.Tag);
        }

        private void BindDistributions()
        {
            ExponentialDistribution.Click += (sender, args)
                => 
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)ExponentialDistribution.Tag, Parameters);

            ParabolaDistribution.Click += (sender, args)
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)ParabolaDistribution.Tag, Parameters);

            RayleighDistribution.Click += (sender, args) 
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)RayleighDistribution.Tag, Parameters);

            CauchyDistribution.Click += (sender, args)
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)CauchyDistribution.Tag, Parameters);

            LaplaceDistribution.Click += (sender, args)
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)LaplaceDistribution.Tag, Parameters);

            NormalDistribution.Click += (sender, args) 
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)NormalDistribution.Tag, Parameters);

            UniformDistribution.Click += (sender, args)
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)UniformDistribution.Tag, Parameters);

            WeibullDistribution.Click += (sender, args) 
                =>
            InvokeWithTwoParameters(ApplyHistogramTransformation, (string)WeibullDistribution.Tag, Parameters);
        }

        private void InvokeWithTwoParameters<T1, T2>(Action<T1, T2> action, T1 first, T2 second)
        => action?.Invoke(first, second);
        private void InvokeWithParameter<T>(Action<T> action, T parameter)
        => action?.Invoke(parameter);
        private void Invoke(Action action)
        => action?.Invoke();
    }
}
