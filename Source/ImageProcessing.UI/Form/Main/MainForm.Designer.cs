using System.Windows.Forms;

namespace ImageProcessing.Form.Main
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAs = new System.Windows.Forms.ToolStripMenuItem();
            this.FiltersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.InversionFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.GrayscaleFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.BinaryFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilterRed = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilterGreen = new System.Windows.Forms.ToolStripMenuItem();
            this.ColorFilterBlue = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvolutionFiltersMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.DistributionsMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolBarMenu = new System.Windows.Forms.ToolStrip();
            this.FirstParamLabel = new System.Windows.Forms.ToolStripLabel();
            this.FirstParam = new System.Windows.Forms.ToolStripTextBox();
            this.SecondParamLabel = new System.Windows.Forms.ToolStripLabel();
            this.SecondParam = new System.Windows.Forms.ToolStripTextBox();
            this.PMF = new System.Windows.Forms.ToolStripButton();
            this.CDF = new System.Windows.Forms.ToolStripButton();
            this.Expectation = new System.Windows.Forms.ToolStripButton();
            this.Variance = new System.Windows.Forms.ToolStripButton();
            this.StandardDeviation = new System.Windows.Forms.ToolStripButton();
            this.ReplaceSrcByDst = new System.Windows.Forms.ToolStripButton();
            this.ReplaceDstBySrc = new System.Windows.Forms.ToolStripButton();
            this.Undo = new System.Windows.Forms.ToolStripButton();
            this.PathToImage = new System.Windows.Forms.ToolStripLabel();
            this.Entropy = new System.Windows.Forms.ToolStripButton();
            this.ShuffleSrc = new System.Windows.Forms.ToolStripButton();
            this.Container = new System.Windows.Forms.SplitContainer();
            this.PictureBoxSrcPanel = new System.Windows.Forms.Panel();
            this.Src = new System.Windows.Forms.PictureBox();
            this.TrackBarSrcPanel = new System.Windows.Forms.Panel();
            this.PictureBoxDstPanel = new System.Windows.Forms.Panel();
            this.Dst = new System.Windows.Forms.PictureBox();
            this.TrackBarDstPanel = new System.Windows.Forms.Panel();
            this.ErrorTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.RandomVariableInfo = new MetroFramework.Components.MetroToolTip();
            this.SrcZoom = new ImageProcessing.UI.Control.ZoomTrackBar();
            this.DstZoom = new ImageProcessing.UI.Control.ZoomTrackBar();
            this.appendProcessedBitmapToolStripButton1 = new ImageProcessing.UI.Control.AppendProcessedBitmapToolStripButton();
            this.MainMenu.SuspendLayout();
            this.ToolBarMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            this.PictureBoxSrcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).BeginInit();
            this.TrackBarSrcPanel.SuspendLayout();
            this.PictureBoxDstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).BeginInit();
            this.TrackBarDstPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.FiltersMenu,
            this.ConvolutionFiltersMenu,
            this.DistributionsMenu});
            this.MainMenu.Location = new System.Drawing.Point(20, 60);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(715, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.SaveFile,
            this.SaveFileAs});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.OpenFile.Size = new System.Drawing.Size(186, 22);
            this.OpenFile.Text = "Open";
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(186, 22);
            this.SaveFile.Text = "Save";
            // 
            // SaveFileAs
            // 
            this.SaveFileAs.Name = "SaveFileAs";
            this.SaveFileAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveFileAs.Size = new System.Drawing.Size(186, 22);
            this.SaveFileAs.Text = "Save As";
            // 
            // FiltersMenu
            // 
            this.FiltersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InversionFilter,
            this.GrayscaleFilter,
            this.BinaryFilter,
            this.ColorFilter});
            this.FiltersMenu.Name = "FiltersMenu";
            this.FiltersMenu.Size = new System.Drawing.Size(50, 20);
            this.FiltersMenu.Text = "Filters";
            // 
            // InversionFilter
            // 
            this.InversionFilter.Name = "InversionFilter";
            this.InversionFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
            this.InversionFilter.Size = new System.Drawing.Size(172, 22);
            this.InversionFilter.Tag = "Inversion";
            this.InversionFilter.Text = "Inversion";
            // 
            // GrayscaleFilter
            // 
            this.GrayscaleFilter.Name = "GrayscaleFilter";
            this.GrayscaleFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.W)));
            this.GrayscaleFilter.Size = new System.Drawing.Size(172, 22);
            this.GrayscaleFilter.Tag = "Grayscale";
            this.GrayscaleFilter.Text = "GrayScale";
            // 
            // BinaryFilter
            // 
            this.BinaryFilter.Name = "BinaryFilter";
            this.BinaryFilter.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.BinaryFilter.Size = new System.Drawing.Size(172, 22);
            this.BinaryFilter.Tag = "Binary";
            this.BinaryFilter.Text = "Binary";
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
            this.ColorFilterRed.Tag = "Red";
            this.ColorFilterRed.Text = "Red";
            // 
            // ColorFilterGreen
            // 
            this.ColorFilterGreen.Name = "ColorFilterGreen";
            this.ColorFilterGreen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.ColorFilterGreen.Size = new System.Drawing.Size(147, 22);
            this.ColorFilterGreen.Tag = "Green";
            this.ColorFilterGreen.Text = "Green";
            // 
            // ColorFilterBlue
            // 
            this.ColorFilterBlue.Name = "ColorFilterBlue";
            this.ColorFilterBlue.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.ColorFilterBlue.Size = new System.Drawing.Size(147, 22);
            this.ColorFilterBlue.Tag = "Blue";
            this.ColorFilterBlue.Text = "Blue";
            // 
            // ConvolutionFiltersMenu
            // 
            this.ConvolutionFiltersMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EdgeDetectionFilter,
            this.BlurFilter,
            this.EmbossFilter,
            this.SharpenFilter});
            this.ConvolutionFiltersMenu.Name = "ConvolutionFiltersMenu";
            this.ConvolutionFiltersMenu.Size = new System.Drawing.Size(119, 20);
            this.ConvolutionFiltersMenu.Text = "Convolution Filters";
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
            this.LaplacianOperator3x3.Tag = "LaplacianOperator3x3";
            this.LaplacianOperator3x3.Text = "3 x 3";
            // 
            // LaplacianOperator5x5
            // 
            this.LaplacianOperator5x5.Name = "LaplacianOperator5x5";
            this.LaplacianOperator5x5.Size = new System.Drawing.Size(135, 22);
            this.LaplacianOperator5x5.Tag = "LaplacianOperator5x5";
            this.LaplacianOperator5x5.Text = "5 x 5";
            // 
            // LaplacianOfGaussianOperator
            // 
            this.LaplacianOfGaussianOperator.Name = "LaplacianOfGaussianOperator";
            this.LaplacianOfGaussianOperator.Size = new System.Drawing.Size(135, 22);
            this.LaplacianOfGaussianOperator.Tag = "LoGOperator ";
            this.LaplacianOfGaussianOperator.Text = "of Gaussian";
            // 
            // SobelOperator
            // 
            this.SobelOperator.Name = "SobelOperator";
            this.SobelOperator.Size = new System.Drawing.Size(174, 22);
            this.SobelOperator.Text = "Sobel Operator";
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
            this.BoxBlur3x3.Size = new System.Drawing.Size(98, 22);
            this.BoxBlur3x3.Tag = "BoxBlur3x3";
            this.BoxBlur3x3.Text = "3 x 3";
            // 
            // BoxBlur5x5
            // 
            this.BoxBlur5x5.Name = "BoxBlur5x5";
            this.BoxBlur5x5.Size = new System.Drawing.Size(98, 22);
            this.BoxBlur5x5.Tag = "BoxBlur5x5";
            this.BoxBlur5x5.Text = "5 x 5";
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
            this.GaussianBlur3x3.Size = new System.Drawing.Size(98, 22);
            this.GaussianBlur3x3.Tag = "GaussianBlur3x3";
            this.GaussianBlur3x3.Text = "3 x 3";
            // 
            // GaussianBlur5x5
            // 
            this.GaussianBlur5x5.Name = "GaussianBlur5x5";
            this.GaussianBlur5x5.Size = new System.Drawing.Size(98, 22);
            this.GaussianBlur5x5.Tag = "GaussianBlur5x5";
            this.GaussianBlur5x5.Text = "5 x 5";
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
            this.MotionBlur9x9.Size = new System.Drawing.Size(98, 22);
            this.MotionBlur9x9.Tag = "MotionBlur9x9";
            this.MotionBlur9x9.Text = "9 x 9";
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
            this.Emboss3x3.Size = new System.Drawing.Size(98, 22);
            this.Emboss3x3.Tag = "Emboss3x3";
            this.Emboss3x3.Text = "3 x 3";
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
            this.Sharpen3x3.Size = new System.Drawing.Size(98, 22);
            this.Sharpen3x3.Tag = "Sharpen3x3";
            this.Sharpen3x3.Text = "3 x 3";
            // 
            // DistributionsMenu
            // 
            this.DistributionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OneParameterDistributions,
            this.TwoParameterDistributions});
            this.DistributionsMenu.Name = "DistributionsMenu";
            this.DistributionsMenu.Size = new System.Drawing.Size(86, 20);
            this.DistributionsMenu.Text = "Distributions";
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
            this.ExponentialDistribution.Size = new System.Drawing.Size(136, 22);
            this.ExponentialDistribution.Tag = "Exponential";
            this.ExponentialDistribution.Text = "Exponential";
            // 
            // RayleighDistribution
            // 
            this.RayleighDistribution.Name = "RayleighDistribution";
            this.RayleighDistribution.Size = new System.Drawing.Size(136, 22);
            this.RayleighDistribution.Tag = "Rayleigh";
            this.RayleighDistribution.Text = "Rayleigh";
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
            this.UniformDistribution.Tag = "Uniform";
            this.UniformDistribution.Text = "Uniform";
            // 
            // CauchyDistribution
            // 
            this.CauchyDistribution.Name = "CauchyDistribution";
            this.CauchyDistribution.Size = new System.Drawing.Size(120, 22);
            this.CauchyDistribution.Tag = "Cauchy";
            this.CauchyDistribution.Text = "Cauchy";
            // 
            // WeibullDistribution
            // 
            this.WeibullDistribution.Name = "WeibullDistribution";
            this.WeibullDistribution.Size = new System.Drawing.Size(120, 22);
            this.WeibullDistribution.Tag = "Weibull";
            this.WeibullDistribution.Text = "Weibull";
            // 
            // LaplaceDistribution
            // 
            this.LaplaceDistribution.Name = "LaplaceDistribution";
            this.LaplaceDistribution.Size = new System.Drawing.Size(120, 22);
            this.LaplaceDistribution.Tag = "Laplace";
            this.LaplaceDistribution.Text = "Laplace";
            // 
            // NormalDistribution
            // 
            this.NormalDistribution.Name = "NormalDistribution";
            this.NormalDistribution.Size = new System.Drawing.Size(120, 22);
            this.NormalDistribution.Tag = "Normal";
            this.NormalDistribution.Text = "Normal";
            // 
            // ParabolaDistribution
            // 
            this.ParabolaDistribution.Name = "ParabolaDistribution";
            this.ParabolaDistribution.Size = new System.Drawing.Size(120, 22);
            this.ParabolaDistribution.Tag = "Parabola";
            this.ParabolaDistribution.Text = "Parabola";
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
            // ToolBarMenu
            // 
            this.ToolBarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstParamLabel,
            this.FirstParam,
            this.SecondParamLabel,
            this.SecondParam,
            this.PMF,
            this.CDF,
            this.Expectation,
            this.Variance,
            this.StandardDeviation,
            this.ReplaceSrcByDst,
            this.ReplaceDstBySrc,
            this.Undo,
            this.PathToImage,
            this.Entropy,
            this.ShuffleSrc,
            this.appendProcessedBitmapToolStripButton1});
            this.ToolBarMenu.Location = new System.Drawing.Point(20, 84);
            this.ToolBarMenu.Name = "ToolBarMenu";
            this.ToolBarMenu.Size = new System.Drawing.Size(715, 25);
            this.ToolBarMenu.Stretch = true;
            this.ToolBarMenu.TabIndex = 5;
            // 
            // FirstParamLabel
            // 
            this.FirstParamLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstParamLabel.Image = global::ImageProcessing.UI.Properties.Resources.FirstParamLabel_Image;
            this.FirstParamLabel.Name = "FirstParamLabel";
            this.FirstParamLabel.Size = new System.Drawing.Size(16, 22);
            this.FirstParamLabel.ToolTipText = "First parameter";
            // 
            // FirstParam
            // 
            this.FirstParam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FirstParam.Name = "FirstParam";
            this.FirstParam.Size = new System.Drawing.Size(75, 25);
            // 
            // SecondParamLabel
            // 
            this.SecondParamLabel.Image = global::ImageProcessing.UI.Properties.Resources.SecondParamLabel_Image;
            this.SecondParamLabel.Name = "SecondParamLabel";
            this.SecondParamLabel.Size = new System.Drawing.Size(16, 22);
            this.SecondParamLabel.ToolTipText = "Второй параметр";
            // 
            // SecondParam
            // 
            this.SecondParam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SecondParam.Name = "SecondParam";
            this.SecondParam.Size = new System.Drawing.Size(75, 25);
            // 
            // PMF
            // 
            this.PMF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PMF.Image = global::ImageProcessing.UI.Properties.Resources.PMF_Image;
            this.PMF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PMF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PMF.Name = "PMF";
            this.PMF.Size = new System.Drawing.Size(37, 22);
            this.PMF.Tag = "PMF";
            this.PMF.ToolTipText = "PMF of the image";
            // 
            // CDF
            // 
            this.CDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CDF.Image = global::ImageProcessing.UI.Properties.Resources.CDF_Image;
            this.CDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CDF.Name = "CDF";
            this.CDF.Size = new System.Drawing.Size(41, 22);
            this.CDF.Tag = "CDF";
            this.CDF.ToolTipText = "CDF of the image";
            // 
            // Expectation
            // 
            this.Expectation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Expectation.Image = global::ImageProcessing.UI.Properties.Resources.Expectation_Image;
            this.Expectation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Expectation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Expectation.Name = "Expectation";
            this.Expectation.Size = new System.Drawing.Size(41, 22);
            this.Expectation.Tag = "Expectation";
            this.Expectation.Text = "Expectation";
            this.Expectation.ToolTipText = "Expected value";
            // 
            // Variance
            // 
            this.Variance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Variance.Image = global::ImageProcessing.UI.Properties.Resources.Variance_Image;
            this.Variance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Variance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Variance.Name = "Variance";
            this.Variance.Size = new System.Drawing.Size(56, 22);
            this.Variance.Tag = "Variance";
            this.Variance.Text = "toolStripButton2";
            this.Variance.ToolTipText = "Variance";
            // 
            // StandardDeviation
            // 
            this.StandardDeviation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StandardDeviation.Image = global::ImageProcessing.UI.Properties.Resources.StandardDeviation_Image;
            this.StandardDeviation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StandardDeviation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StandardDeviation.Name = "StandardDeviation";
            this.StandardDeviation.Size = new System.Drawing.Size(23, 22);
            this.StandardDeviation.Tag = "StandardDeviation";
            this.StandardDeviation.Text = "StandardDeviation";
            this.StandardDeviation.ToolTipText = "StandardDeviation";
            // 
            // ReplaceSrcByDst
            // 
            this.ReplaceSrcByDst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReplaceSrcByDst.Image = global::ImageProcessing.UI.Properties.Resources.change_Image;
            this.ReplaceSrcByDst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReplaceSrcByDst.Name = "ReplaceSrcByDst";
            this.ReplaceSrcByDst.Size = new System.Drawing.Size(23, 22);
            this.ReplaceSrcByDst.Tag = "Destination";
            this.ReplaceSrcByDst.ToolTipText = "Replace source by destination";
            // 
            // ReplaceDstBySrc
            // 
            this.ReplaceDstBySrc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReplaceDstBySrc.Image = global::ImageProcessing.UI.Properties.Resources.toolStripButton1_Image;
            this.ReplaceDstBySrc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReplaceDstBySrc.Name = "ReplaceDstBySrc";
            this.ReplaceDstBySrc.Size = new System.Drawing.Size(23, 22);
            this.ReplaceDstBySrc.Tag = "Source";
            this.ReplaceDstBySrc.ToolTipText = "Replace destination by source";
            // 
            // Undo
            // 
            this.Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Undo.Image = global::ImageProcessing.UI.Properties.Resources.Undo_Image;
            this.Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(23, 22);
            this.Undo.ToolTipText = "Undo last transformation";
            // 
            // PathToImage
            // 
            this.PathToImage.Name = "PathToImage";
            this.PathToImage.Size = new System.Drawing.Size(0, 22);
            this.PathToImage.Visible = false;
            // 
            // Entropy
            // 
            this.Entropy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Entropy.Image = global::ImageProcessing.UI.Properties.Resources.Entropy_Image;
            this.Entropy.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Entropy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Entropy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Entropy.Name = "Entropy";
            this.Entropy.Size = new System.Drawing.Size(23, 22);
            this.Entropy.Tag = "Entropy";
            this.Entropy.ToolTipText = "Entropy of the image";
            // 
            // ShuffleSrc
            // 
            this.ShuffleSrc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShuffleSrc.Image = global::ImageProcessing.UI.Properties.Resources.ShuffleSrc_Image;
            this.ShuffleSrc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShuffleSrc.Name = "ShuffleSrc";
            this.ShuffleSrc.Size = new System.Drawing.Size(23, 22);
            this.ShuffleSrc.Text = "Shuffle";
            this.ShuffleSrc.ToolTipText = "Shuffle pixels of a source image";
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(20, 109);
            this.Container.Name = "Container";
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.AllowDrop = true;
            this.Container.Panel1.AutoScroll = true;
            this.Container.Panel1.Controls.Add(this.PictureBoxSrcPanel);
            this.Container.Panel1.Controls.Add(this.TrackBarSrcPanel);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.AutoScroll = true;
            this.Container.Panel2.Controls.Add(this.PictureBoxDstPanel);
            this.Container.Panel2.Controls.Add(this.TrackBarDstPanel);
            this.Container.Size = new System.Drawing.Size(715, 372);
            this.Container.SplitterDistance = 389;
            this.Container.TabIndex = 9;
            // 
            // PictureBoxSrcPanel
            // 
            this.PictureBoxSrcPanel.AutoScroll = true;
            this.PictureBoxSrcPanel.Controls.Add(this.Src);
            this.PictureBoxSrcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxSrcPanel.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSrcPanel.Name = "PictureBoxSrcPanel";
            this.PictureBoxSrcPanel.Size = new System.Drawing.Size(389, 338);
            this.PictureBoxSrcPanel.TabIndex = 4;
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
            this.Src.Tag = "Source";
            // 
            // TrackBarSrcPanel
            // 
            this.TrackBarSrcPanel.Controls.Add(this.SrcZoom);
            this.TrackBarSrcPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TrackBarSrcPanel.Location = new System.Drawing.Point(0, 338);
            this.TrackBarSrcPanel.Name = "TrackBarSrcPanel";
            this.TrackBarSrcPanel.Size = new System.Drawing.Size(389, 34);
            this.TrackBarSrcPanel.TabIndex = 3;
            // 
            // PictureBoxDstPanel
            // 
            this.PictureBoxDstPanel.AutoScroll = true;
            this.PictureBoxDstPanel.Controls.Add(this.Dst);
            this.PictureBoxDstPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxDstPanel.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxDstPanel.Name = "PictureBoxDstPanel";
            this.PictureBoxDstPanel.Size = new System.Drawing.Size(322, 338);
            this.PictureBoxDstPanel.TabIndex = 5;
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
            this.Dst.Tag = "Destination";
            // 
            // TrackBarDstPanel
            // 
            this.TrackBarDstPanel.Controls.Add(this.DstZoom);
            this.TrackBarDstPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TrackBarDstPanel.Location = new System.Drawing.Point(0, 338);
            this.TrackBarDstPanel.Name = "TrackBarDstPanel";
            this.TrackBarDstPanel.Size = new System.Drawing.Size(322, 34);
            this.TrackBarDstPanel.TabIndex = 4;
            // 
            // RandomVariableInfo
            // 
            this.RandomVariableInfo.Style = MetroFramework.MetroColorStyle.Blue;
            this.RandomVariableInfo.StyleManager = null;
            this.RandomVariableInfo.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // SrcZoom
            // 
            this.SrcZoom.BackColor = System.Drawing.Color.Transparent;
            this.SrcZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SrcZoom.Enabled = false;
            this.SrcZoom.Location = new System.Drawing.Point(0, 0);
            this.SrcZoom.Maximum = 200;
            this.SrcZoom.Minimum = -200;
            this.SrcZoom.Name = "SrcZoom";
            this.SrcZoom.Size = new System.Drawing.Size(389, 34);
            this.SrcZoom.TabIndex = 0;
            this.SrcZoom.Tag = "Source";
            this.SrcZoom.TrackBarValue = 0;
            this.SrcZoom.Value = 0;
            // 
            // DstZoom
            // 
            this.DstZoom.BackColor = System.Drawing.Color.Transparent;
            this.DstZoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DstZoom.Enabled = false;
            this.DstZoom.Location = new System.Drawing.Point(0, 0);
            this.DstZoom.Maximum = 200;
            this.DstZoom.Minimum = -200;
            this.DstZoom.Name = "DstZoom";
            this.DstZoom.Size = new System.Drawing.Size(322, 34);
            this.DstZoom.TabIndex = 0;
            this.DstZoom.Tag = "Destination";
            this.DstZoom.TrackBarValue = 0;
            this.DstZoom.Value = 0;
            // 
            // appendProcessedBitmapToolStripButton1
            // 
            this.appendProcessedBitmapToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.appendProcessedBitmapToolStripButton1.Image = global::ImageProcessing.UI.Properties.Resources.toolStripButton11_Image;
            this.appendProcessedBitmapToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.appendProcessedBitmapToolStripButton1.Name = "appendProcessedBitmapToolStripButton1";
            this.appendProcessedBitmapToolStripButton1.Size = new System.Drawing.Size(23, 22);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 501);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.ToolBarMenu);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Image Processing";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ToolBarMenu.ResumeLayout(false);
            this.ToolBarMenu.PerformLayout();
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            this.PictureBoxSrcPanel.ResumeLayout(false);
            this.PictureBoxSrcPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).EndInit();
            this.TrackBarSrcPanel.ResumeLayout(false);
            this.PictureBoxDstPanel.ResumeLayout(false);
            this.PictureBoxDstPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).EndInit();
            this.TrackBarDstPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAs;
        private System.Windows.Forms.ToolStripMenuItem FiltersMenu;
        private System.Windows.Forms.ToolStripMenuItem InversionFilter;
        private System.Windows.Forms.ToolStripMenuItem GrayscaleFilter;
        private System.Windows.Forms.ToolStripMenuItem BinaryFilter;
        private System.Windows.Forms.ToolStripMenuItem ColorFilter;
        private System.Windows.Forms.ToolStripMenuItem ColorFilterRed;
        private System.Windows.Forms.ToolStripMenuItem ColorFilterGreen;
        private System.Windows.Forms.ToolStripMenuItem ColorFilterBlue;
        private System.Windows.Forms.ToolStripMenuItem DistributionsMenu;
        private System.Windows.Forms.ToolStripMenuItem OneParameterDistributions;
        private System.Windows.Forms.ToolStripMenuItem ExponentialDistribution;
        private System.Windows.Forms.ToolStripMenuItem RayleighDistribution;
        private System.Windows.Forms.ToolStripMenuItem TwoParameterDistributions;
        private System.Windows.Forms.ToolStripMenuItem UniformDistribution;
        private System.Windows.Forms.ToolStripMenuItem CauchyDistribution;
        private System.Windows.Forms.ToolStripMenuItem WeibullDistribution;
        private System.Windows.Forms.ToolStripMenuItem ConvolutionFiltersMenu;
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
        private System.Windows.Forms.ToolStrip ToolBarMenu;
        private System.Windows.Forms.ToolStripTextBox FirstParam;
        private System.Windows.Forms.ToolStripTextBox SecondParam;
        private System.Windows.Forms.ToolStripButton PMF;
        private System.Windows.Forms.PictureBox Src;
        private System.Windows.Forms.SplitContainer Container;
        private System.Windows.Forms.PictureBox Dst;
        private System.Windows.Forms.ToolStripButton ReplaceSrcByDst;
        private System.Windows.Forms.ToolStripButton Undo;
        private System.Windows.Forms.ToolStripLabel FirstParamLabel;
        private System.Windows.Forms.ToolStripLabel SecondParamLabel;
        private System.Windows.Forms.ToolStripLabel PathToImage;
        private System.Windows.Forms.ToolStripButton Entropy;
        private System.Windows.Forms.ToolStripButton ShuffleSrc;
        private System.Windows.Forms.ToolStripButton CDF;
        private System.Windows.Forms.ToolStripButton ReplaceDstBySrc;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private System.Windows.Forms.ToolStripButton Expectation;
        private System.Windows.Forms.ToolStripButton Variance;
        private System.Windows.Forms.ToolStripButton StandardDeviation;
        private ToolTip ErrorTooltip;
        private Panel PictureBoxSrcPanel;
        private Panel TrackBarSrcPanel;
        private Panel PictureBoxDstPanel;
        private Panel TrackBarDstPanel;
        private UI.Control.ZoomTrackBar SrcZoom;
        private UI.Control.ZoomTrackBar DstZoom;
        private MetroFramework.Components.MetroToolTip RandomVariableInfo;
        private UI.Control.AppendProcessedBitmapToolStripButton appendProcessedBitmapToolStripButton1;
    }
}

