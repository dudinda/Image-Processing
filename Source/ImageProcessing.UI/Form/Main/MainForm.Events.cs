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
        public event Action<string>? Zoom;
        public event Action? Shuffle;
        public event Action<Keys>? GetRandomVariableInfo;
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

            SrcZoom.ValueChanged += (secnder, args)
                => Invoke(Zoom, (string)Src.Tag);

            DstZoom.ValueChanged += (secnder, args)
                => Invoke(Zoom, (string)Dst.Tag);
        }

        /// <summary>
        /// Bind event handlers for a toolbar menu
        /// </summary>
        private void BindToolbar()
        {
            ShuffleSrc.Click += (sender, args)
                => Invoke(Shuffle);

            PMF.Click += (sender, args)
                => Invoke(BuildPMF, (string)Src.Tag, (string)PMF.Tag);

            CDF.Click += (sender, args)
                => Invoke(BuildCDF, (string)Dst.Tag, (string)CDF.Tag);

            Expectation.Click += (sender, args)
                => Invoke(GetRandomVariableInfo);

            Variance.Click += (sender, args)
                => Invoke(GetRandomVariableInfo);

            StandardDeviation.Click += (sender, args)
                => Invoke(GetRandomVariableInfo);

            Entropy.Click += (sender, args)
                => Invoke(GetRandomVariableInfo);

            Undo.Click += (sender, args)
                => Invoke(UndoLast);

            ReplaceSrcByDst.Click += (sernder, args)
                => Invoke(ReplaceImage, (string)Dst.Tag);

            ReplaceDstBySrc.Click += (sernder, args)
                => Invoke(ReplaceImage, (string)Src.Tag);
        }

        /// <summary>
        /// Bind event handlers for a convolution menu
        /// </summary>
        private void BindConvolutionFilters()
        {
            GaussianBlur3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)GaussianBlur3x3.Tag);

            GaussianBlur5x5.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)GaussianBlur5x5.Tag);

            BoxBlur3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)BoxBlur3x3.Tag);

            BoxBlur5x5.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)BoxBlur5x5.Tag);

            MotionBlur9x9.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)MotionBlur9x9.Tag);

            LaplacianOfGaussianOperator.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)LaplacianOfGaussianOperator.Tag);

            LaplacianOperator5x5.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)LaplacianOperator5x5.Tag);

            LaplacianOperator3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)LaplacianOperator3x3.Tag);

            Emboss3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)Emboss3x3.Tag);

            Sharpen3x3.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)Sharpen3x3.Tag);

            SobelOperator.Click += (sender, args)
                => Invoke(ApplyConvolutionFilter, (string)SobelOperator.Tag);
        }

        /// <summary>
        /// Bind event handlers for a rgb filters menu
        /// </summary>
        private void BindRGBFilters()
        {
            InversionFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, (string)InversionFilter.Tag);

            BinaryFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, (string)BinaryFilter.Tag);

            GrayscaleFilter.Click += (sender, args)
                => Invoke(ApplyRGBFilter, (string)GrayscaleFilter.Tag);

            ColorFilterBlue.Click += (sender, args)
                => Invoke(ApplyRGBColorFilter, (string)ColorFilterBlue.Tag);

            ColorFilterRed.Click += (sender, args)
                => Invoke(ApplyRGBColorFilter, (string)ColorFilterRed.Tag);

            ColorFilterGreen.Click += (sender, args)
                => Invoke(ApplyRGBColorFilter, (string)ColorFilterGreen.Tag);
        }

        /// <summary>
        /// Bind event handlers for a histogram transformation menu
        /// </summary>
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

        /// <summary>
        /// Provides the binder for tool strip buttons
        /// </summary>
        /// <param name="msg">A Windows message</param>
        /// <param name="keyData">The pressed key</param>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch(keyData)
            {
                case (Keys.Right):
                    Invoke(ReplaceImage, (string)Src.Tag);
                    return true;
                case (Keys.Left):   
                    Invoke(ReplaceImage, (string)Dst.Tag);
                    return true;
                case (Keys.Add):
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Invoke<T1, T2>(Action<T1, T2>? action, T1 first, T2 second)
            => action?.Invoke(first, second);
        private void Invoke<T>(Action<T>? action, T parameter)
            => action?.Invoke(parameter);
        private void Invoke(Action? action)
            => action?.Invoke();
    }
}
