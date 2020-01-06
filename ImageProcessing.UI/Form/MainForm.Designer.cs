using System.Windows.Forms;

namespace ImageProcessing
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Filters = new System.Windows.Forms.ToolStripMenuItem();
            this.InverseFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayScaleFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.BinaryFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilterRed = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilterGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilterBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.Distributions = new System.Windows.Forms.ToolStripMenuItem();
            this.OneParameterDistributions = new System.Windows.Forms.ToolStripMenuItem();
            this.ExponentialDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.RayleighDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.TwoParameterDistributions = new System.Windows.Forms.ToolStripMenuItem();
            this.UniformDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.CauchyDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.WeibullDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplaceDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.NormalDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.ParabolaDistribution = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvolutionFilters = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgeDetectionFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplacianOperator = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplacianOperator3x3 = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplacianOperator5x5 = new System.Windows.Forms.ToolStripMenuItem();
            this.LaplacianOfGaussianOperator = new System.Windows.Forms.ToolStripMenuItem();
            this.SobelOperator = new System.Windows.Forms.ToolStripMenuItem();
            this.BlurFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.BoxBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.BoxBlur3x3 = new System.Windows.Forms.ToolStripMenuItem();
            this.BoxBlur5x5 = new System.Windows.Forms.ToolStripMenuItem();
            this.GaussianBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.GaussianBlur3x3 = new System.Windows.Forms.ToolStripMenuItem();
            this.GaussianBlur5x5 = new System.Windows.Forms.ToolStripMenuItem();
            this.MotionBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.MotionBlur9x9 = new System.Windows.Forms.ToolStripMenuItem();
            this.EmbossFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.Emboss3x3 = new System.Windows.Forms.ToolStripMenuItem();
            this.SharpenFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.Sharpen3x3 = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.MenuStrip = new System.Windows.Forms.ToolStrip();
            this.FirstParamLabel = new System.Windows.Forms.ToolStripLabel();
            this.FirstParam = new System.Windows.Forms.ToolStripTextBox();
            this.SecondParamLabel = new System.Windows.Forms.ToolStripLabel();
            this.SecondParam = new System.Windows.Forms.ToolStripTextBox();
            this.pmf = new System.Windows.Forms.ToolStripButton();
            this.cdf = new System.Windows.Forms.ToolStripButton();
            this.change = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.undo = new System.Windows.Forms.ToolStripButton();
            this.PathToImage = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.ZoomInSrcBtn = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutSrcBtn = new System.Windows.Forms.ToolStripButton();
            this.ZoomInDstBtn = new System.Windows.Forms.ToolStripButton();
            this.ZoomOutDstBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton11 = new System.Windows.Forms.ToolStripButton();
            this.compare = new System.Windows.Forms.ToolStripButton();
            this.Src = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Dst = new System.Windows.Forms.PictureBox();
            this.Expectation = new System.Windows.Forms.ToolStripButton();
            this.Variance = new System.Windows.Forms.ToolStripButton();
            this.sderivation = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.Filters,
            this.Distributions,
            this.ConvolutionFilters});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += (sender, args) => Invoke(OpenImage);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += (sender, args) => Invoke(SaveImage);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += (sender, args) => Invoke(SaveImage);
            // 
            // Filters
            // 
            this.Filters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InverseFilter,
            this.GrayScaleFilter,
            this.BinaryFilter,
            this.ColorFilter});
            this.Filters.Name = "Filters";
            this.Filters.Size = new System.Drawing.Size(50, 20);
            this.Filters.Text = "Filters";
            // 
            // InverseFilter
            // 
            this.InverseFilter.Name = "InverseFilter";
            this.InverseFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.InverseFilter.Size = new System.Drawing.Size(172, 22);
            this.InverseFilter.Text = "Inversion";
            this.InverseFilter.Click += (sender, args) => InvokeWithParameter<string>(ApplyRGBFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // GrayScaleFilter
            // 
            this.GrayScaleFilter.Name = "GrayScaleFilter";
            this.GrayScaleFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.GrayScaleFilter.Size = new System.Drawing.Size(172, 22);
            this.GrayScaleFilter.Text = "GrayScale";
            this.GrayScaleFilter.Click += (sender, args) => InvokeWithParameter<string>(ApplyRGBFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // BinaryFilter
            // 
            this.BinaryFilter.Name = "BinaryFilter";
            this.BinaryFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.BinaryFilter.Size = new System.Drawing.Size(172, 22);
            this.BinaryFilter.Text = "Binary";
            this.BinaryFilter.Click += (sender, args) => InvokeWithParameter<string>(ApplyRGBFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // ColorFilter
            // 
            this.ColorFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ColorFilterRed,
            this.ColorFilterGreen,
            this.ColorFilterBlue});
            this.ColorFilter.Name = "ColorFilter";
            this.ColorFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.ColorFilter.Size = new System.Drawing.Size(172, 22);
            this.ColorFilter.Text = "Color filters";
            // 
            // ColorFilterRed
            // 
            this.ColorFilterRed.Name = "ColorFilterRed";
            this.ColorFilterRed.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.ColorFilterRed.Size = new System.Drawing.Size(147, 22);
            this.ColorFilterRed.Text = "Red";
          //  this.ColorFilterRed.Click += new System.EventHandler(this.ColorFilterRedClick);
            // 
            // ColorFilterGreen
            // 
            this.ColorFilterGreen.Name = "ColorFilterGreen";
            this.ColorFilterGreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.ColorFilterGreen.Size = new System.Drawing.Size(147, 22);
            this.ColorFilterGreen.Text = "Green";
        //    this.ColorFilterGreen.Click += new System.EventHandler(this.ColorFilterGreenClick);
            // 
            // ColorFilterBlue
            // 
            this.ColorFilterBlue.Name = "ColorFilterBlue";
            this.ColorFilterBlue.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.ColorFilterBlue.Size = new System.Drawing.Size(147, 22);
            this.ColorFilterBlue.Text = "Blue";
    //        this.ColorFilterBlue.Click += new System.EventHandler(this.ColorFilterBlueClick);
            // 
            // Distributions
            // 
            this.Distributions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OneParameterDistributions,
            this.TwoParameterDistributions});
            this.Distributions.Name = "Distributions";
            this.Distributions.Size = new System.Drawing.Size(86, 20);
            this.Distributions.Text = "Distributions";
            // 
            // OneParameterDistributions
            // 
            this.OneParameterDistributions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExponentialDistribution,
            this.RayleighDistribution});
            this.OneParameterDistributions.Name = "OneParameterDistributions";
            this.OneParameterDistributions.Size = new System.Drawing.Size(155, 22);
            this.OneParameterDistributions.Text = "One-parameter";
            // 
            // ExponentialDistribution
            // 
            this.ExponentialDistribution.Name = "ExponentialDistribution";
            this.ExponentialDistribution.Size = new System.Drawing.Size(135, 22);
            this.ExponentialDistribution.Text = "Exponential";
            this.ExponentialDistribution.Click += (sender, args) => 
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // RayleighDistribution
            // 
            this.RayleighDistribution.Name = "RayleighDistribution";
            this.RayleighDistribution.Size = new System.Drawing.Size(135, 22);
            this.RayleighDistribution.Text = "Rayleigh";
            this.RayleighDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // TwoParameterDistributions
            // 
            this.TwoParameterDistributions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UniformDistribution,
            this.CauchyDistribution,
            this.WeibullDistribution,
            this.LaplaceDistribution,
            this.NormalDistribution,
            this.ParabolaDistribution});
            this.TwoParameterDistributions.Name = "TwoParameterDistributions";
            this.TwoParameterDistributions.Size = new System.Drawing.Size(155, 22);
            this.TwoParameterDistributions.Text = "Two-parameter";
            // 
            // UniformDistribution
            // 
            this.UniformDistribution.Name = "UniformDistribution";
            this.UniformDistribution.Size = new System.Drawing.Size(120, 22);
            this.UniformDistribution.Text = "Uniform";
            this.UniformDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // CauchyDistribution
            // 
            this.CauchyDistribution.Name = "CauchyDistribution";
            this.CauchyDistribution.Size = new System.Drawing.Size(120, 22);
            this.CauchyDistribution.Text = "Cauchy";
            this.CauchyDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // WeibullDistribution
            // 
            this.WeibullDistribution.Name = "WeibullDistribution";
            this.WeibullDistribution.Size = new System.Drawing.Size(120, 22);
            this.WeibullDistribution.Text = "Weibull";
            this.WeibullDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // LaplaceDistribution
            // 
            this.LaplaceDistribution.Name = "LaplaceDistribution";
            this.LaplaceDistribution.Size = new System.Drawing.Size(120, 22);
            this.LaplaceDistribution.Text = "Laplace";
            this.LaplaceDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // NormalDistribution
            // 
            this.NormalDistribution.Name = "NormalDistribution";
            this.NormalDistribution.Size = new System.Drawing.Size(120, 22);
            this.NormalDistribution.Text = "Normal";
            this.NormalDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // ParabolaDistribution
            // 
            this.ParabolaDistribution.Name = "ParabolaDistribution";
            this.ParabolaDistribution.Size = new System.Drawing.Size(120, 22);
            this.ParabolaDistribution.Text = "Parabola";
            this.ParabolaDistribution.Click += (sender, args) =>
            InvokeWithTwoParameters<string, (double, double)>(ApplyHistogramTransformation, ((ToolStripMenuItem)sender).Tag.ToString(), this.Parameters);
            // 
            // ConvolutionFilters
            // 
            this.ConvolutionFilters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdgeDetectionFilter,
            this.BlurFilter,
            this.EmbossFilter,
            this.SharpenFilter});
            this.ConvolutionFilters.Name = "ConvolutionFilters";
            this.ConvolutionFilters.Size = new System.Drawing.Size(119, 20);
            this.ConvolutionFilters.Text = "Convolution Filters";
            // 
            // EdgeDetectionFilter
            // 
            this.EdgeDetectionFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaplacianOperator,
            this.SobelOperator});
            this.EdgeDetectionFilter.Name = "EdgeDetectionFilter";
            this.EdgeDetectionFilter.Size = new System.Drawing.Size(154, 22);
            this.EdgeDetectionFilter.Text = "Edge Detection";
            // 
            // LaplacianOperator
            // 
            this.LaplacianOperator.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LaplacianOperator3x3,
            this.LaplacianOperator5x5,
            this.LaplacianOfGaussianOperator});
            this.LaplacianOperator.Name = "LaplacianOperator";
            this.LaplacianOperator.Size = new System.Drawing.Size(174, 22);
            this.LaplacianOperator.Text = "Laplacian Operator";
            // 
            // LaplacianOperator3x3
            // 
            this.LaplacianOperator3x3.Name = "LaplacianOperator3x3";
            this.LaplacianOperator3x3.Size = new System.Drawing.Size(135, 22);
            this.LaplacianOperator3x3.Text = "3 x 3";
            this.LaplacianOperator3x3.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // LaplacianOperator5x5
            // 
            this.LaplacianOperator5x5.Name = "LaplacianOperator5x5";
            this.LaplacianOperator5x5.Size = new System.Drawing.Size(135, 22);
            this.LaplacianOperator5x5.Text = "5 x 5";
            this.LaplacianOperator5x5.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // LaplacianOfGaussianOperator
            // 
            this.LaplacianOfGaussianOperator.Name = "LaplacianOfGaussianOperator";
            this.LaplacianOfGaussianOperator.Size = new System.Drawing.Size(135, 22);
            this.LaplacianOfGaussianOperator.Text = "of Gaussian";
            this.LaplacianOfGaussianOperator.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // SobelOperator
            // 
            this.SobelOperator.Name = "SobelOperator";
            this.SobelOperator.Size = new System.Drawing.Size(174, 22);
            this.SobelOperator.Text = "Sobel Operator";
          //  this.SobelOperator.Click += new System.EventHandler(this.SobelOperatorHorizontalClick);
            // 
            // BlurFilter
            // 
            this.BlurFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BoxBlur,
            this.GaussianBlur,
            this.MotionBlur});
            this.BlurFilter.Name = "BlurFilter";
            this.BlurFilter.Size = new System.Drawing.Size(154, 22);
            this.BlurFilter.Text = "Blur";
            // 
            // BoxBlur
            // 
            this.BoxBlur.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BoxBlur3x3,
            this.BoxBlur5x5});
            this.BoxBlur.Name = "BoxBlur";
            this.BoxBlur.Size = new System.Drawing.Size(145, 22);
            this.BoxBlur.Text = "Box Blur";
            // 
            // BoxBlur3x3
            // 
            this.BoxBlur3x3.Name = "BoxBlur3x3";
            this.BoxBlur3x3.Size = new System.Drawing.Size(97, 22);
            this.BoxBlur3x3.Text = "3 x 3";
            this.BoxBlur3x3.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // BoxBlur5x5
            // 
            this.BoxBlur5x5.Name = "BoxBlur5x5";
            this.BoxBlur5x5.Size = new System.Drawing.Size(97, 22);
            this.BoxBlur5x5.Text = "5 x 5";
            this.BoxBlur5x5.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // GaussianBlur
            // 
            this.GaussianBlur.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GaussianBlur3x3,
            this.GaussianBlur5x5});
            this.GaussianBlur.Name = "GaussianBlur";
            this.GaussianBlur.Size = new System.Drawing.Size(145, 22);
            this.GaussianBlur.Text = "Gaussian Blur";
            // 
            // GaussianBlur3x3
            // 
            this.GaussianBlur3x3.Name = "GaussianBlur3x3";
            this.GaussianBlur3x3.Size = new System.Drawing.Size(97, 22);
            this.GaussianBlur3x3.Text = "3 x 3";
            this.GaussianBlur3x3.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // GaussianBlur5x5
            // 
            this.GaussianBlur5x5.Name = "GaussianBlur5x5";
            this.GaussianBlur5x5.Size = new System.Drawing.Size(97, 22);
            this.GaussianBlur5x5.Text = "5 x 5";
            this.GaussianBlur5x5.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // MotionBlur
            // 
            this.MotionBlur.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MotionBlur9x9});
            this.MotionBlur.Name = "MotionBlur";
            this.MotionBlur.Size = new System.Drawing.Size(145, 22);
            this.MotionBlur.Text = "Motion Blur";
            // 
            // MotionBlur9x9
            // 
            this.MotionBlur9x9.Name = "MotionBlur9x9";
            this.MotionBlur9x9.Size = new System.Drawing.Size(97, 22);
            this.MotionBlur9x9.Text = "9 x 9";
            this.MotionBlur9x9.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // EmbossFilter
            // 
            this.EmbossFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Emboss3x3});
            this.EmbossFilter.Name = "EmbossFilter";
            this.EmbossFilter.Size = new System.Drawing.Size(154, 22);
            this.EmbossFilter.Text = "Emboss";
            // 
            // Emboss3x3
            // 
            this.Emboss3x3.Name = "Emboss3x3";
            this.Emboss3x3.Size = new System.Drawing.Size(97, 22);
            this.Emboss3x3.Text = "3 x 3";
            this.Emboss3x3.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // SharpenFilter
            // 
            this.SharpenFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sharpen3x3});
            this.SharpenFilter.Name = "SharpenFilter";
            this.SharpenFilter.Size = new System.Drawing.Size(154, 22);
            this.SharpenFilter.Text = "Sharpen";
            // 
            // Sharpen3x3
            // 
            this.Sharpen3x3.Name = "Sharpen3x3";
            this.Sharpen3x3.Size = new System.Drawing.Size(97, 22);
            this.Sharpen3x3.Text = "3 x 3";
            this.Sharpen3x3.Click += (sender, args) => InvokeWithParameter<string>(ApplyConvolutionFilter, ((ToolStripMenuItem)sender).Tag.ToString());
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(236, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(662, 25);
            this.miniToolStrip.Stretch = true;
            this.miniToolStrip.TabIndex = 1;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstParamLabel,
            this.FirstParam,
            this.SecondParamLabel,
            this.SecondParam,
            this.pmf,
            this.cdf,
            this.Expectation,
            this.Variance,
            this.sderivation,
            this.change,
            this.toolStripButton1,
            this.undo,
            this.PathToImage,
            this.toolStripButton5,
            this.toolStripButton7,
            this.ZoomInSrcBtn,
            this.ZoomOutSrcBtn,
            this.ZoomInDstBtn,
            this.ZoomOutDstBtn,
            this.toolStripButton11,
            this.compare});
            this.MenuStrip.Location = new System.Drawing.Point(20, 84);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(715, 25);
            this.MenuStrip.Stretch = true;
            this.MenuStrip.TabIndex = 5;
            this.MenuStrip.Text = "toolStrip1";
            // 
            // FirstParamLabel
            // 
            this.FirstParamLabel.Image = ((System.Drawing.Image)(resources.GetObject("FirstParamLabel.Image")));
            this.FirstParamLabel.Name = "FirstParamLabel";
            this.FirstParamLabel.Size = new System.Drawing.Size(16, 22);
            this.FirstParamLabel.ToolTipText = "Первый параметр ";
            // 
            // FirstParam
            // 
            this.FirstParam.Name = "FirstParam";
            this.FirstParam.Size = new System.Drawing.Size(75, 25);
        //    this.FirstParam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AcceptOnlyDigits);
        //    this.FirstParam.TextChanged += new System.EventHandler(this.CheckOverflow);
            // 
            // SecondParamLabel
            // 
            this.SecondParamLabel.Image = ((System.Drawing.Image)(resources.GetObject("SecondParamLabel.Image")));
            this.SecondParamLabel.Name = "SecondParamLabel";
            this.SecondParamLabel.Size = new System.Drawing.Size(16, 22);
            this.SecondParamLabel.ToolTipText = "Второй параметр";
            // 
            // SecondParam
            // 
            this.SecondParam.Name = "SecondParam";
            this.SecondParam.Size = new System.Drawing.Size(75, 25);
      //      this.SecondParam.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AcceptOnlyDigits);
        //    this.SecondParam.TextChanged += new System.EventHandler(this.CheckOverflow);
            // 
            // pmf
            // 
            this.pmf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pmf.Image = ((System.Drawing.Image)(resources.GetObject("pmf.Image")));
            this.pmf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pmf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pmf.Name = "pmf";
            this.pmf.Size = new System.Drawing.Size(37, 22);
            this.pmf.ToolTipText = "Гистограмма исходного изображения";
            //this.pmf.Click += new System.EventHandler(this.BuildSrcHistogramClick);
            // 
            // cdf
            // 
            this.cdf.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cdf.Image = ((System.Drawing.Image)(resources.GetObject("cdf.Image")));
            this.cdf.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cdf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cdf.Name = "cdf";
            this.cdf.Size = new System.Drawing.Size(41, 22);
            this.cdf.Text = "toolStripButton8";
            //this.cdf.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // change
            // 
            this.change.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.change.Image = ((System.Drawing.Image)(resources.GetObject("change.Image")));
            this.change.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(23, 22);
            this.change.ToolTipText = "Заменить исходное изображение";
         //   this.change.Click += new System.EventHandler(this.ChangeSrcImageClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
           // this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // undo
            // 
            this.undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undo.Image = ((System.Drawing.Image)(resources.GetObject("undo.Image")));
            this.undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undo.Name = "undo";
            this.undo.Size = new System.Drawing.Size(23, 22);
            this.undo.ToolTipText = "Назад";
         //   this.undo.Click += new System.EventHandler(this.UndoBtnClick);
            // 
            // PathToImage
            // 
            this.PathToImage.Name = "PathToImage";
            this.PathToImage.Size = new System.Drawing.Size(0, 22);
            this.PathToImage.Visible = false;
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
           // this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton7.Text = "Shuffle";
  //          this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_ClickAsync);
            // 
            // ZoomInSrcBtn
            // 
            this.ZoomInSrcBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInSrcBtn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomInSrcBtn.Image")));
            this.ZoomInSrcBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInSrcBtn.Name = "ZoomInSrcBtn";
            this.ZoomInSrcBtn.Size = new System.Drawing.Size(23, 22);
            this.ZoomInSrcBtn.Text = "toolStripButton8";
            this.ZoomInSrcBtn.ToolTipText = "100%";
          //  this.ZoomInSrcBtn.Click += new System.EventHandler(this.ZoomInSrc);
            // 
            // ZoomOutSrcBtn
            // 
            this.ZoomOutSrcBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutSrcBtn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOutSrcBtn.Image")));
            this.ZoomOutSrcBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutSrcBtn.Name = "ZoomOutSrcBtn";
            this.ZoomOutSrcBtn.Size = new System.Drawing.Size(23, 22);
            this.ZoomOutSrcBtn.Text = "toolStripButton9";
            this.ZoomOutSrcBtn.ToolTipText = "100%";
         //   this.ZoomOutSrcBtn.Click += new System.EventHandler(this.ZoomOutSrc);
            // 
            // ZoomInDstBtn
            // 
            this.ZoomInDstBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomInDstBtn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomInDstBtn.Image")));
            this.ZoomInDstBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomInDstBtn.Name = "ZoomInDstBtn";
            this.ZoomInDstBtn.Size = new System.Drawing.Size(23, 22);
            this.ZoomInDstBtn.Text = "toolStripButton10";
            this.ZoomInDstBtn.ToolTipText = "100%";
         //   this.ZoomInDstBtn.Click += new System.EventHandler(this.ZoomInDst);
            // 
            // ZoomOutDstBtn
            // 
            this.ZoomOutDstBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ZoomOutDstBtn.Image = ((System.Drawing.Image)(resources.GetObject("ZoomOutDstBtn.Image")));
            this.ZoomOutDstBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ZoomOutDstBtn.Name = "ZoomOutDstBtn";
            this.ZoomOutDstBtn.Size = new System.Drawing.Size(23, 22);
            this.ZoomOutDstBtn.Text = "toolStripButton11";
            this.ZoomOutDstBtn.ToolTipText = "100%";
        //    this.ZoomOutDstBtn.Click += new System.EventHandler(this.ZoomOutDst);
            // 
            // toolStripButton11
            // 
            this.toolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton11.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton11.Image")));
            this.toolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton11.Name = "toolStripButton11";
            this.toolStripButton11.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton11.Text = "toolStripButton11";
          //  this.toolStripButton11.Click += new System.EventHandler(this.toolStripButton11_Click);
            // 
            // compare
            // 
            this.compare.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compare.Image = ((System.Drawing.Image)(resources.GetObject("compare.Image")));
            this.compare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compare.Name = "compare";
            this.compare.Size = new System.Drawing.Size(23, 22);
            this.compare.Text = "toolStripButton1";
        //    this.compare.Click += new System.EventHandler(this.compare_Click);
            // 
            // Src
            // 
            this.Src.Cursor = System.Windows.Forms.Cursors.Default;
            this.Src.Location = new System.Drawing.Point(3, 3);
            this.Src.Name = "Src";
            this.Src.Size = new System.Drawing.Size(160, 132);
            this.Src.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Src.TabIndex = 2;
            this.Src.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 109);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.Src);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.Dst);
            this.splitContainer1.Size = new System.Drawing.Size(715, 372);
            this.splitContainer1.SplitterDistance = 389;
            this.splitContainer1.TabIndex = 9;
            // 
            // Dst
            // 
            this.Dst.Cursor = System.Windows.Forms.Cursors.Default;
            this.Dst.Location = new System.Drawing.Point(3, 3);
            this.Dst.Name = "Dst";
            this.Dst.Size = new System.Drawing.Size(160, 132);
            this.Dst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Dst.TabIndex = 3;
            this.Dst.TabStop = false;
            // 
            // Expectation
            // 
            this.Expectation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Expectation.Image = ((System.Drawing.Image)(resources.GetObject("Expectation.Image")));
            this.Expectation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Expectation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Expectation.Name = "Expectation";
            this.Expectation.Size = new System.Drawing.Size(41, 22);
            this.Expectation.Text = "toolStripButton2";
          //  this.Expectation.Click += new System.EventHandler(this.Expectation_Click);
            // 
            // Variance
            // 
            this.Variance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Variance.Image = ((System.Drawing.Image)(resources.GetObject("Variance.Image")));
            this.Variance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Variance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Variance.Name = "Variance";
            this.Variance.Size = new System.Drawing.Size(56, 22);
            this.Variance.Text = "toolStripButton2";
          //  this.Variance.Click += new System.EventHandler(this.Variance_Click);
            // 
            // sderivation
            // 
            this.sderivation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.sderivation.Image = ((System.Drawing.Image)(resources.GetObject("sderivation.Image")));
            this.sderivation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.sderivation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sderivation.Name = "sderivation";
            this.sderivation.Size = new System.Drawing.Size(23, 22);
            this.sderivation.Text = "toolStripButton2";
            //this.sderivation.Click += new System.EventHandler(this.sderivation_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 501);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Image Processing";
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Filters;
        private System.Windows.Forms.ToolStripMenuItem InverseFilter;
        private System.Windows.Forms.ToolStripMenuItem GrayScaleFilter;
        private System.Windows.Forms.ToolStripMenuItem BinaryFilter;
        private System.Windows.Forms.ToolStripMenuItem ColorFilter;
        private System.Windows.Forms.ToolStripMenuItem ColorFilterRed;
        private System.Windows.Forms.ToolStripMenuItem ColorFilterGreen;
        private System.Windows.Forms.ToolStripMenuItem ColorFilterBlue;
        private System.Windows.Forms.ToolStripMenuItem Distributions;
        private System.Windows.Forms.ToolStripMenuItem OneParameterDistributions;
        private System.Windows.Forms.ToolStripMenuItem ExponentialDistribution;
        private System.Windows.Forms.ToolStripMenuItem RayleighDistribution;
        private System.Windows.Forms.ToolStripMenuItem TwoParameterDistributions;
        private System.Windows.Forms.ToolStripMenuItem UniformDistribution;
        private System.Windows.Forms.ToolStripMenuItem CauchyDistribution;
        private System.Windows.Forms.ToolStripMenuItem WeibullDistribution;
        private System.Windows.Forms.ToolStripMenuItem ConvolutionFilters;
        private System.Windows.Forms.ToolStripMenuItem EdgeDetectionFilter;
        private System.Windows.Forms.ToolStripMenuItem LaplacianOperator;
        private System.Windows.Forms.ToolStripMenuItem LaplacianOperator3x3;
        private System.Windows.Forms.ToolStripMenuItem LaplacianOperator5x5;
        private System.Windows.Forms.ToolStripMenuItem BlurFilter;
        private System.Windows.Forms.ToolStripMenuItem EmbossFilter;
        private System.Windows.Forms.ToolStripMenuItem SobelOperator;
        private System.Windows.Forms.ToolStripMenuItem BoxBlur;
        private System.Windows.Forms.ToolStripMenuItem BoxBlur3x3;
        private System.Windows.Forms.ToolStripMenuItem BoxBlur5x5;
        private System.Windows.Forms.ToolStripMenuItem GaussianBlur;
        private System.Windows.Forms.ToolStripMenuItem GaussianBlur3x3;
        private System.Windows.Forms.ToolStripMenuItem GaussianBlur5x5;
        private System.Windows.Forms.ToolStripMenuItem SharpenFilter;
        private System.Windows.Forms.ToolStripMenuItem Sharpen3x3;
        private System.Windows.Forms.ToolStripMenuItem LaplacianOfGaussianOperator;
        private System.Windows.Forms.ToolStripMenuItem Emboss3x3;
        private System.Windows.Forms.ToolStripMenuItem MotionBlur;
        private System.Windows.Forms.ToolStripMenuItem MotionBlur9x9;
        private System.Windows.Forms.ToolStripMenuItem LaplaceDistribution;
        private System.Windows.Forms.ToolStripMenuItem NormalDistribution;
        private System.Windows.Forms.ToolStripMenuItem ParabolaDistribution;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip MenuStrip;
        private System.Windows.Forms.ToolStripTextBox FirstParam;
        private System.Windows.Forms.ToolStripTextBox SecondParam;
        private System.Windows.Forms.ToolStripButton pmf;
        private System.Windows.Forms.PictureBox Src;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox Dst;
        private System.Windows.Forms.ToolStripButton change;
        private System.Windows.Forms.ToolStripButton undo;
        private System.Windows.Forms.ToolStripLabel FirstParamLabel;
        private System.Windows.Forms.ToolStripLabel SecondParamLabel;
        private System.Windows.Forms.ToolStripLabel PathToImage;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private System.Windows.Forms.ToolStripButton ZoomInSrcBtn;
        private System.Windows.Forms.ToolStripButton ZoomOutSrcBtn;
        private System.Windows.Forms.ToolStripButton ZoomInDstBtn;
        private System.Windows.Forms.ToolStripButton ZoomOutDstBtn;
        private System.Windows.Forms.ToolStripButton cdf;
        private System.Windows.Forms.ToolStripButton toolStripButton11;
        private System.Windows.Forms.ToolStripButton compare;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Expectation;
        private System.Windows.Forms.ToolStripButton Variance;
        private System.Windows.Forms.ToolStripButton sderivation;
    }
}

