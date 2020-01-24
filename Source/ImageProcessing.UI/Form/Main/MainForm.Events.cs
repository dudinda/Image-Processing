using System;
using System.Windows.Forms;

namespace ImageProcessing.Form.Main
{
    partial class MainForm
    {
        public event Action? SaveImageAs;
        public event Action? SaveImage;
        public event Action? OpenImage;
        public event Action<string>? ApplyConvolutionFilter;
        public event Action<string, (string, string)>? ApplyHistogramTransformation;
        public event Action<string>? ApplyRGBFilter;
        public event Action<string>? ApplyRGBColorFilter;
        public event Action<string>? ReplaceImage;
        public event Action<string, string>? BuildPMF;
        public event Action<string, string>? BuildCDF;
        public event Action<string, string>? GetRandomVariableInfo;
        public event Action<string>? Zoom;
        public event Action? Shuffle;    
        public event Action? UndoLast;
        public event Action? BuildLuminanceIntervals;


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
                => Invoke(SaveImageAs);

            SrcZoom.MouseMove += (secnder, args)
                => Invoke(Zoom, Src.Tag);

            SrcZoom.KeyPress += (secnder, args)
                 => Invoke(Zoom, Src.Tag);

            DstZoom.MouseMove += (secnder, args)
                => Invoke(Zoom, Dst.Tag);

            DstZoom.KeyPress += (secnder, args)
              => Invoke(Zoom, Dst.Tag);
        }

        /// <summary>
        /// Bind event handlers for a toolbar menu
        /// </summary>
        private void BindToolbar()
        {
            ShuffleSrc.Click += (sender, args)
                => Invoke(Shuffle);

            PMF.Click += (sender, args)
                => Invoke(BuildPMF, Src.Tag, PMF.Tag);

            CDF.Click += (sender, args)
                => Invoke(BuildCDF, Src.Tag, CDF.Tag);

            Expectation.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Src.Tag, Expectation.Tag);

            Variance.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Src.Tag, Variance.Tag);

            StandardDeviation.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Src.Tag, StandardDeviation.Tag);

            Entropy.Click += (sender, args)
                => Invoke(GetRandomVariableInfo, Src.Tag, Entropy.Tag);

            Undo.Click += (sender, args)
                => Invoke(UndoLast);

            ReplaceSrcByDst.Click += (sernder, args)
                => Invoke(ReplaceImage, Dst.Tag);

            ReplaceDstBySrc.Click += (sernder, args)
                => Invoke(ReplaceImage, Src.Tag);
        }

        /// <summary>
        /// Bind event handlers for a convolution menu
        /// </summary>
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

        /// <summary>
        /// Bind event handlers for a rgb filters menu
        /// </summary>
        private void BindRGBFilters()
        {
            InversionFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, InversionFilter.Tag);

            BinaryFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, BinaryFilter.Tag);

            GrayscaleFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, GrayscaleFilter.Tag);

            ColorFilterBlue.Click += (sender, args)
                => Invoke(ApplyRGBColorFilter, ColorFilterBlue.Tag);

            ColorFilterRed.Click += (sender, args)
                => Invoke(ApplyRGBColorFilter, ColorFilterRed.Tag);

            ColorFilterGreen.Click += (sender, args)
                => Invoke(ApplyRGBColorFilter, ColorFilterGreen.Tag);
        }

        /// <summary>
        /// Bind event handlers for a histogram transformation menu
        /// </summary>
        private void BindDistributions()
        {
            ExponentialDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, ExponentialDistribution.Tag, Parameters);

            ParabolaDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, ParabolaDistribution.Tag, Parameters);

            RayleighDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, RayleighDistribution.Tag, Parameters);

            CauchyDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, CauchyDistribution.Tag, Parameters);

            LaplaceDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, LaplaceDistribution.Tag, Parameters);

            NormalDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, NormalDistribution.Tag, Parameters);

            UniformDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, UniformDistribution.Tag, Parameters);

            WeibullDistribution.Click += (sender, args)
                => Invoke(ApplyHistogramTransformation, WeibullDistribution.Tag, Parameters);
        }

        /// <summary>
        /// Provides the binder for tool strip buttons and zoom trackbars
        /// </summary>
        /// <param name="msg">A Windows message</param>
        /// <param name="keyData">The pressed key</param>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case (Keys.Right):
                    Invoke(ReplaceImage, Src.Tag);
                    return true;
                case (Keys.Left):   
                    Invoke(ReplaceImage, Dst.Tag);
                    return true;
                case (Keys.Q):
                    Invoke(BuildPMF, Src.Tag, PMF.Tag);
                    return true;
                case (Keys.Q | Keys.Control):
                    Invoke(BuildPMF, Dst.Tag, PMF.Tag);
                    return true;
                case (Keys.W):
                    Invoke(BuildCDF, Src.Tag, CDF.Tag);
                    return true;
                case (Keys.W | Keys.Control):
                    Invoke(BuildCDF, Dst.Tag, CDF.Tag);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
