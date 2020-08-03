using System.Windows.Forms;

namespace ImageProcessing.App.UILayer.Form.Main
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
            => Dispose();
     
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAs = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvolutionFiltersMenu = new System.Windows.Forms.ToolStripMenuItem();
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
            this.Entropy = new System.Windows.Forms.ToolStripButton();
            this.Undo = new System.Windows.Forms.ToolStripButton();
            this.Redo = new System.Windows.Forms.ToolStripButton();
            this.ReplaceSrcByDst = new System.Windows.Forms.ToolStripButton();
            this.ReplaceDstBySrc = new System.Windows.Forms.ToolStripButton();
            this.PathToImage = new System.Windows.Forms.ToolStripLabel();
            this.ShuffleSrc = new System.Windows.Forms.ToolStripButton();
            this.QualityMeasure = new ImageProcessing.App.UILayer.Control.QualityMeasureToolStripButton();
            this.PictureBoxSrcPanel = new System.Windows.Forms.Panel();
            this.Src = new System.Windows.Forms.PictureBox();
            this.TrackBarSrcPanel = new System.Windows.Forms.Panel();
            this.SrcZoom = new ImageProcessing.App.UILayer.Control.ZoomTrackBar();
            this.PictureBoxDstPanel = new System.Windows.Forms.Panel();
            this.Dst = new System.Windows.Forms.PictureBox();
            this.TrackBarDstPanel = new System.Windows.Forms.Panel();
            this.DstZoom = new ImageProcessing.App.UILayer.Control.ZoomTrackBar();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RandomVariableInformation = new MetroFramework.Components.MetroToolTip();
            this.Container = new ImageProcessing.App.UILayer.Control.UndoRedoSplitContainer();
            this.RgbMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.ToolBarMenu.SuspendLayout();
            this.PictureBoxSrcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).BeginInit();
            this.TrackBarSrcPanel.SuspendLayout();
            this.PictureBoxDstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).BeginInit();
            this.TrackBarDstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Container)).BeginInit();
            this.Container.Panel1.SuspendLayout();
            this.Container.Panel2.SuspendLayout();
            this.Container.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.RgbMenu,
            this.ConvolutionFiltersMenu,
            this.DistributionsMenu});
            this.MainMenu.Location = new System.Drawing.Point(20, 60);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
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
            // ConvolutionFiltersMenu
            // 
            this.ConvolutionFiltersMenu.Name = "ConvolutionFiltersMenu";
            this.ConvolutionFiltersMenu.Size = new System.Drawing.Size(119, 20);
            this.ConvolutionFiltersMenu.Text = "Convolution Filters";
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
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(236, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(662, 25);
            this.miniToolStrip.Stretch = true;
            this.miniToolStrip.TabIndex = 1;
            // 
            // ToolBarMenu
            // 
            this.ToolBarMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.Entropy,
            this.Undo,
            this.Redo,
            this.ReplaceSrcByDst,
            this.ReplaceDstBySrc,
            this.PathToImage,
            this.ShuffleSrc,
            this.QualityMeasure});
            this.ToolBarMenu.Location = new System.Drawing.Point(20, 84);
            this.ToolBarMenu.Name = "ToolBarMenu";
            this.ToolBarMenu.Size = new System.Drawing.Size(715, 27);
            this.ToolBarMenu.Stretch = true;
            this.ToolBarMenu.TabIndex = 5;
            // 
            // FirstParamLabel
            // 
            this.FirstParamLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FirstParamLabel.Image = ((System.Drawing.Image)(resources.GetObject("FirstParamLabel.Image")));
            this.FirstParamLabel.Name = "FirstParamLabel";
            this.FirstParamLabel.Size = new System.Drawing.Size(20, 24);
            this.FirstParamLabel.ToolTipText = "First parameter";
            // 
            // FirstParam
            // 
            this.FirstParam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FirstParam.Name = "FirstParam";
            this.FirstParam.Size = new System.Drawing.Size(75, 27);
            // 
            // SecondParamLabel
            // 
            this.SecondParamLabel.Image = ((System.Drawing.Image)(resources.GetObject("SecondParamLabel.Image")));
            this.SecondParamLabel.Name = "SecondParamLabel";
            this.SecondParamLabel.Size = new System.Drawing.Size(20, 24);
            this.SecondParamLabel.ToolTipText = "Второй параметр";
            // 
            // SecondParam
            // 
            this.SecondParam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SecondParam.Name = "SecondParam";
            this.SecondParam.Size = new System.Drawing.Size(75, 27);
            // 
            // PMF
            // 
            this.PMF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PMF.Image = ((System.Drawing.Image)(resources.GetObject("PMF.Image")));
            this.PMF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PMF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PMF.Name = "PMF";
            this.PMF.Size = new System.Drawing.Size(37, 24);
            this.PMF.Tag = "PMF";
            this.PMF.ToolTipText = "PMF of the image";
            // 
            // CDF
            // 
            this.CDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CDF.Image = ((System.Drawing.Image)(resources.GetObject("CDF.Image")));
            this.CDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CDF.Name = "CDF";
            this.CDF.Size = new System.Drawing.Size(41, 24);
            this.CDF.Tag = "CDF";
            this.CDF.ToolTipText = "CDF of the image";
            // 
            // Expectation
            // 
            this.Expectation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Expectation.Image = ((System.Drawing.Image)(resources.GetObject("Expectation.Image")));
            this.Expectation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Expectation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Expectation.Name = "Expectation";
            this.Expectation.Size = new System.Drawing.Size(41, 24);
            this.Expectation.Tag = "Expectation";
            this.Expectation.ToolTipText = "Expected value";
            // 
            // Variance
            // 
            this.Variance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Variance.Image = ((System.Drawing.Image)(resources.GetObject("Variance.Image")));
            this.Variance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Variance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Variance.Name = "Variance";
            this.Variance.Size = new System.Drawing.Size(56, 24);
            this.Variance.Tag = "Variance";
            this.Variance.ToolTipText = "Variance";
            // 
            // StandardDeviation
            // 
            this.StandardDeviation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StandardDeviation.Image = ((System.Drawing.Image)(resources.GetObject("StandardDeviation.Image")));
            this.StandardDeviation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StandardDeviation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StandardDeviation.Name = "StandardDeviation";
            this.StandardDeviation.Size = new System.Drawing.Size(23, 24);
            this.StandardDeviation.Tag = "StandardDeviation";
            this.StandardDeviation.Text = "StandardDeviation";
            this.StandardDeviation.ToolTipText = "StandardDeviation";
            // 
            // Entropy
            // 
            this.Entropy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Entropy.Image = ((System.Drawing.Image)(resources.GetObject("Entropy.Image")));
            this.Entropy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Entropy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Entropy.Name = "Entropy";
            this.Entropy.Size = new System.Drawing.Size(23, 24);
            this.Entropy.Tag = "Entropy";
            this.Entropy.ToolTipText = "Entropy of the image";
            // 
            // Undo
            // 
            this.Undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Undo.Enabled = false;
            this.Undo.Image = ((System.Drawing.Image)(resources.GetObject("Undo.Image")));
            this.Undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(24, 24);
            this.Undo.ToolTipText = "Undo last transformation";
            // 
            // Redo
            // 
            this.Redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Redo.Enabled = false;
            this.Redo.Image = ((System.Drawing.Image)(resources.GetObject("Redo.Image")));
            this.Redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(24, 24);
            this.Redo.ToolTipText = "Redo last transformation";
            // 
            // ReplaceSrcByDst
            // 
            this.ReplaceSrcByDst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReplaceSrcByDst.Image = ((System.Drawing.Image)(resources.GetObject("ReplaceSrcByDst.Image")));
            this.ReplaceSrcByDst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReplaceSrcByDst.Name = "ReplaceSrcByDst";
            this.ReplaceSrcByDst.Size = new System.Drawing.Size(24, 24);
            this.ReplaceSrcByDst.Tag = "Destination";
            this.ReplaceSrcByDst.ToolTipText = "Replace source by destination";
            // 
            // ReplaceDstBySrc
            // 
            this.ReplaceDstBySrc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReplaceDstBySrc.Image = ((System.Drawing.Image)(resources.GetObject("ReplaceDstBySrc.Image")));
            this.ReplaceDstBySrc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReplaceDstBySrc.Name = "ReplaceDstBySrc";
            this.ReplaceDstBySrc.Size = new System.Drawing.Size(24, 24);
            this.ReplaceDstBySrc.Tag = "Source";
            this.ReplaceDstBySrc.ToolTipText = "Replace destination by source";
            // 
            // PathToImage
            // 
            this.PathToImage.Name = "PathToImage";
            this.PathToImage.Size = new System.Drawing.Size(0, 24);
            this.PathToImage.Visible = false;
            // 
            // ShuffleSrc
            // 
            this.ShuffleSrc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShuffleSrc.Image = ((System.Drawing.Image)(resources.GetObject("ShuffleSrc.Image")));
            this.ShuffleSrc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShuffleSrc.Name = "ShuffleSrc";
            this.ShuffleSrc.Size = new System.Drawing.Size(24, 24);
            this.ShuffleSrc.Text = "Shuffle";
            this.ShuffleSrc.ToolTipText = "Shuffle pixels of a source image";
            // 
            // QualityMeasure
            // 
            this.QualityMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QualityMeasure.Enabled = false;
            this.QualityMeasure.Image = ((System.Drawing.Image)(resources.GetObject("QualityMeasure.Image")));
            this.QualityMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QualityMeasure.Name = "QualityMeasure";
            this.QualityMeasure.Size = new System.Drawing.Size(24, 24);
            // 
            // PictureBoxSrcPanel
            // 
            this.PictureBoxSrcPanel.AutoScroll = true;
            this.PictureBoxSrcPanel.Controls.Add(this.Src);
            this.PictureBoxSrcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxSrcPanel.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSrcPanel.Name = "PictureBoxSrcPanel";
            this.PictureBoxSrcPanel.Size = new System.Drawing.Size(359, 336);
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
            this.TrackBarSrcPanel.Location = new System.Drawing.Point(0, 336);
            this.TrackBarSrcPanel.Name = "TrackBarSrcPanel";
            this.TrackBarSrcPanel.Size = new System.Drawing.Size(359, 34);
            this.TrackBarSrcPanel.TabIndex = 3;
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
            this.SrcZoom.Size = new System.Drawing.Size(359, 34);
            this.SrcZoom.TabIndex = 0;
            this.SrcZoom.Tag = "Source";
            this.SrcZoom.TrackBarValue = 0;
            this.SrcZoom.Value = 0;
            // 
            // PictureBoxDstPanel
            // 
            this.PictureBoxDstPanel.AutoScroll = true;
            this.PictureBoxDstPanel.Controls.Add(this.Dst);
            this.PictureBoxDstPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxDstPanel.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxDstPanel.Name = "PictureBoxDstPanel";
            this.PictureBoxDstPanel.Size = new System.Drawing.Size(352, 336);
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
            this.TrackBarDstPanel.Location = new System.Drawing.Point(0, 336);
            this.TrackBarDstPanel.Name = "TrackBarDstPanel";
            this.TrackBarDstPanel.Size = new System.Drawing.Size(352, 34);
            this.TrackBarDstPanel.TabIndex = 4;
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
            this.DstZoom.Size = new System.Drawing.Size(352, 34);
            this.DstZoom.TabIndex = 0;
            this.DstZoom.Tag = "Destination";
            this.DstZoom.TrackBarValue = 0;
            this.DstZoom.Value = 0;
            // 
            // RandomVariableInformation
            // 
            this.RandomVariableInformation.Style = MetroFramework.MetroColorStyle.Blue;
            this.RandomVariableInformation.StyleManager = null;
            this.RandomVariableInformation.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(20, 111);
            this.Container.Name = "Container";
            // 
            // Container.Panel1
            // 
            this.Container.Panel1.Controls.Add(this.PictureBoxSrcPanel);
            this.Container.Panel1.Controls.Add(this.TrackBarSrcPanel);
            // 
            // Container.Panel2
            // 
            this.Container.Panel2.Controls.Add(this.PictureBoxDstPanel);
            this.Container.Panel2.Controls.Add(this.TrackBarDstPanel);
            this.Container.Size = new System.Drawing.Size(715, 370);
            this.Container.SplitterDistance = 359;
            this.Container.TabIndex = 10;
            // 
            // RgbMenu
            // 
            this.RgbMenu.Name = "RgbMenu";
            this.RgbMenu.Size = new System.Drawing.Size(50, 20);
            this.RgbMenu.Text = "Filters";
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
            this.PictureBoxSrcPanel.ResumeLayout(false);
            this.PictureBoxSrcPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).EndInit();
            this.TrackBarSrcPanel.ResumeLayout(false);
            this.PictureBoxDstPanel.ResumeLayout(false);
            this.PictureBoxDstPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).EndInit();
            this.TrackBarDstPanel.ResumeLayout(false);
            this.Container.Panel1.ResumeLayout(false);
            this.Container.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Container)).EndInit();
            this.Container.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAs;
        private System.Windows.Forms.ToolStripMenuItem DistributionsMenu;
        private System.Windows.Forms.ToolStripMenuItem OneParameterDistributions;
        private System.Windows.Forms.ToolStripMenuItem ExponentialDistribution;
        private System.Windows.Forms.ToolStripMenuItem RayleighDistribution;
        private System.Windows.Forms.ToolStripMenuItem TwoParameterDistributions;
        private System.Windows.Forms.ToolStripMenuItem UniformDistribution;
        private System.Windows.Forms.ToolStripMenuItem CauchyDistribution;
        private System.Windows.Forms.ToolStripMenuItem WeibullDistribution;
        private System.Windows.Forms.ToolStripMenuItem ConvolutionFiltersMenu;
        private System.Windows.Forms.ToolStripMenuItem LaplaceDistribution;
        private System.Windows.Forms.ToolStripMenuItem NormalDistribution;
        private System.Windows.Forms.ToolStripMenuItem ParabolaDistribution;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip ToolBarMenu;
        private System.Windows.Forms.ToolStripTextBox FirstParam;
        private System.Windows.Forms.ToolStripTextBox SecondParam;
        private System.Windows.Forms.ToolStripButton PMF;
        private System.Windows.Forms.PictureBox Src;
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
        private ToolTip ErrorToolTip;
        private Panel PictureBoxSrcPanel;
        private Panel TrackBarSrcPanel;
        private Panel PictureBoxDstPanel;
        private Panel TrackBarDstPanel;
        private App.UILayer.Control.ZoomTrackBar SrcZoom;
        private MetroFramework.Components.MetroToolTip RandomVariableInformation;
        private App.UILayer.Control.QualityMeasureToolStripButton QualityMeasure;
        private App.UILayer.Control.UndoRedoSplitContainer Container;
        private ToolStripButton Redo;
        private App.UILayer.Control.ZoomTrackBar DstZoom;
        private ToolStripMenuItem RgbMenu;
    }
}

