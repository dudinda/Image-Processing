using ImageProcessing.App.UI.Models.Controls;

namespace ImageProcessing.App.UI.Forms.Distribution
{ 
    partial class DistributionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributionForm));
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
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
            this.PathToImage = new System.Windows.Forms.ToolStripLabel();
            this.ShuffleSrc = new System.Windows.Forms.ToolStripButton();
            this.QualityMeasure = new ImageProcessing.App.UI.Models.Controls.QualityMeasureToolStripButton();
            this.DistributionsComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Transform = new MetroFramework.Controls.MetroButton();
            this.DistributionButtonPanel = new MetroFramework.Controls.MetroPanel();
            this.SelectedArea = new ImageProcessing.App.UI.Controls.SelectedAreaControl();
            this.ToolBarMenu.SuspendLayout();
            this.DistributionButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarMenu
            // 
            this.ToolBarMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ToolBarMenu.AutoSize = false;
            this.ToolBarMenu.Dock = System.Windows.Forms.DockStyle.None;
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
            this.PathToImage,
            this.ShuffleSrc,
            this.QualityMeasure});
            this.ToolBarMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.ToolBarMenu.Location = new System.Drawing.Point(3, 35);
            this.ToolBarMenu.Name = "ToolBarMenu";
            this.ToolBarMenu.Size = new System.Drawing.Size(506, 27);
            this.ToolBarMenu.TabIndex = 6;
            // 
            // FirstParamLabel
            // 
            this.FirstParamLabel.Image = ((System.Drawing.Image)(resources.GetObject("FirstParamLabel.Image")));
            this.FirstParamLabel.Name = "FirstParamLabel";
            this.FirstParamLabel.Size = new System.Drawing.Size(20, 20);
            this.FirstParamLabel.ToolTipText = "First parameter";
            // 
            // FirstParam
            // 
            this.FirstParam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FirstParam.Name = "FirstParam";
            this.FirstParam.Size = new System.Drawing.Size(75, 23);
            // 
            // SecondParamLabel
            // 
            this.SecondParamLabel.Image = ((System.Drawing.Image)(resources.GetObject("SecondParamLabel.Image")));
            this.SecondParamLabel.Name = "SecondParamLabel";
            this.SecondParamLabel.Size = new System.Drawing.Size(20, 20);
            this.SecondParamLabel.ToolTipText = "Second parameter";
            // 
            // SecondParam
            // 
            this.SecondParam.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SecondParam.Name = "SecondParam";
            this.SecondParam.Size = new System.Drawing.Size(75, 23);
            // 
            // PMF
            // 
            this.PMF.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.PMF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.PMF.Image = ((System.Drawing.Image)(resources.GetObject("PMF.Image")));
            this.PMF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PMF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PMF.Name = "PMF";
            this.PMF.Size = new System.Drawing.Size(37, 22);
            this.PMF.Tag = "PMF";
            this.PMF.ToolTipText = "PMF of the image";
            // 
            // CDF
            // 
            this.CDF.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CDF.Image = ((System.Drawing.Image)(resources.GetObject("CDF.Image")));
            this.CDF.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CDF.Name = "CDF";
            this.CDF.Size = new System.Drawing.Size(41, 22);
            this.CDF.Tag = "CDF";
            this.CDF.ToolTipText = "CDF of the image";
            // 
            // Expectation
            // 
            this.Expectation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Expectation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Expectation.Image = ((System.Drawing.Image)(resources.GetObject("Expectation.Image")));
            this.Expectation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Expectation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Expectation.Name = "Expectation";
            this.Expectation.Size = new System.Drawing.Size(41, 22);
            this.Expectation.Tag = "Expectation";
            this.Expectation.ToolTipText = "Expected value";
            // 
            // Variance
            // 
            this.Variance.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Variance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Variance.Image = ((System.Drawing.Image)(resources.GetObject("Variance.Image")));
            this.Variance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Variance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Variance.Name = "Variance";
            this.Variance.Size = new System.Drawing.Size(56, 22);
            this.Variance.Tag = "Variance";
            this.Variance.ToolTipText = "Variance";
            // 
            // StandardDeviation
            // 
            this.StandardDeviation.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StandardDeviation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.StandardDeviation.Image = ((System.Drawing.Image)(resources.GetObject("StandardDeviation.Image")));
            this.StandardDeviation.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.StandardDeviation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StandardDeviation.Name = "StandardDeviation";
            this.StandardDeviation.Size = new System.Drawing.Size(23, 14);
            this.StandardDeviation.Tag = "StandardDeviation";
            this.StandardDeviation.Text = "StandardDeviation";
            this.StandardDeviation.ToolTipText = "StandardDeviation";
            // 
            // Entropy
            // 
            this.Entropy.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Entropy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Entropy.Image = ((System.Drawing.Image)(resources.GetObject("Entropy.Image")));
            this.Entropy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Entropy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Entropy.Name = "Entropy";
            this.Entropy.Size = new System.Drawing.Size(23, 20);
            this.Entropy.Tag = "Entropy";
            this.Entropy.ToolTipText = "Entropy of the image";
            // 
            // PathToImage
            // 
            this.PathToImage.Name = "PathToImage";
            this.PathToImage.Size = new System.Drawing.Size(0, 0);
            this.PathToImage.Visible = false;
            // 
            // ShuffleSrc
            // 
            this.ShuffleSrc.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
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
            this.QualityMeasure.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.QualityMeasure.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QualityMeasure.Enabled = false;
            this.QualityMeasure.Image = ((System.Drawing.Image)(resources.GetObject("QualityMeasure.Image")));
            this.QualityMeasure.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.QualityMeasure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QualityMeasure.Name = "QualityMeasure";
            this.QualityMeasure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.QualityMeasure.Size = new System.Drawing.Size(24, 24);
            // 
            // DistributionsComboBox
            // 
            this.DistributionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DistributionsComboBox.FormattingEnabled = true;
            this.DistributionsComboBox.ItemHeight = 23;
            this.DistributionsComboBox.Location = new System.Drawing.Point(207, 3);
            this.DistributionsComboBox.MaxDropDownItems = 100;
            this.DistributionsComboBox.Name = "DistributionsComboBox";
            this.DistributionsComboBox.Size = new System.Drawing.Size(299, 29);
            this.DistributionsComboBox.TabIndex = 0;
            this.DistributionsComboBox.UseSelectable = true;
            // 
            // Transform
            // 
            this.Transform.AutoSize = true;
            this.Transform.Location = new System.Drawing.Point(3, 3);
            this.Transform.Name = "Transform";
            this.Transform.Size = new System.Drawing.Size(198, 29);
            this.Transform.TabIndex = 1;
            this.Transform.Text = "Transform";
            this.Transform.UseSelectable = true;
            // 
            // DistributionButtonPanel
            // 
            this.DistributionButtonPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DistributionButtonPanel.Controls.Add(this.SelectedArea);
            this.DistributionButtonPanel.Controls.Add(this.DistributionsComboBox);
            this.DistributionButtonPanel.Controls.Add(this.ToolBarMenu);
            this.DistributionButtonPanel.Controls.Add(this.Transform);
            this.DistributionButtonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DistributionButtonPanel.HorizontalScrollbarBarColor = true;
            this.DistributionButtonPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.DistributionButtonPanel.HorizontalScrollbarSize = 10;
            this.DistributionButtonPanel.Location = new System.Drawing.Point(20, 60);
            this.DistributionButtonPanel.Name = "DistributionButtonPanel";
            this.DistributionButtonPanel.Size = new System.Drawing.Size(783, 134);
            this.DistributionButtonPanel.TabIndex = 7;
            this.DistributionButtonPanel.VerticalScrollbarBarColor = true;
            this.DistributionButtonPanel.VerticalScrollbarHighlightOnWheel = false;
            this.DistributionButtonPanel.VerticalScrollbarSize = 10;
            // 
            // SelectedArea
            // 
            this.SelectedArea.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedArea.AutoSize = true;
            this.SelectedArea.Location = new System.Drawing.Point(509, 0);
            this.SelectedArea.Margin = new System.Windows.Forms.Padding(0);
            this.SelectedArea.Name = "SelectedArea";
            this.SelectedArea.Size = new System.Drawing.Size(267, 131);
            this.SelectedArea.TabIndex = 7;
            this.SelectedArea.UseSelectable = true;
            // 
            // DistributionForm
            // 
            this.ClientSize = new System.Drawing.Size(823, 214);
            this.Controls.Add(this.DistributionButtonPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "DistributionForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Distribution";
            this.TopMost = true;
            this.ToolBarMenu.ResumeLayout(false);
            this.ToolBarMenu.PerformLayout();
            this.DistributionButtonPanel.ResumeLayout(false);
            this.DistributionButtonPanel.PerformLayout();
            this.ResumeLayout(false);

        }

		#endregion
        private System.Windows.Forms.ToolTip ErrorToolTip;
        private MetroFramework.Controls.MetroComboBox DistributionsComboBox;
        private MetroFramework.Controls.MetroButton Transform;
        private System.Windows.Forms.ToolStrip ToolBarMenu;
        private System.Windows.Forms.ToolStripLabel FirstParamLabel;
        private System.Windows.Forms.ToolStripTextBox FirstParam;
        private System.Windows.Forms.ToolStripLabel SecondParamLabel;
        private System.Windows.Forms.ToolStripTextBox SecondParam;
        private System.Windows.Forms.ToolStripButton PMF;
        private System.Windows.Forms.ToolStripButton CDF;
        private System.Windows.Forms.ToolStripButton Expectation;
        private System.Windows.Forms.ToolStripButton Variance;
        private System.Windows.Forms.ToolStripButton StandardDeviation;
        private System.Windows.Forms.ToolStripButton Entropy;
        private System.Windows.Forms.ToolStripLabel PathToImage;
        private System.Windows.Forms.ToolStripButton ShuffleSrc;
        private QualityMeasureToolStripButton QualityMeasure;
        private MetroFramework.Controls.MetroPanel DistributionButtonPanel;
        private Controls.SelectedAreaControl SelectedArea;
    }
}
