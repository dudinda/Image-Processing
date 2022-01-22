namespace ImageProcessing.App.UILayer.Forms.Distribution
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
            this.QualityMeasure = new ImageProcessing.App.UILayer.Control.QualityMeasureToolStripButton();
            this.DistributionsComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Transform = new MetroFramework.Controls.MetroButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.selectedAreaControl1 = new ImageProcessing.App.UILayer.Controls.SelectedAreaControl();
            this.ToolBarMenu.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarMenu
            // 
            this.ToolBarMenu.AutoSize = false;
            this.ToolBarMenu.CanOverflow = false;
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
            this.ToolBarMenu.Location = new System.Drawing.Point(3, 75);
            this.ToolBarMenu.Name = "ToolBarMenu";
            this.ToolBarMenu.Size = new System.Drawing.Size(478, 27);
            this.ToolBarMenu.Stretch = true;
            this.ToolBarMenu.TabIndex = 6;
            // 
            // FirstParamLabel
            // 
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
            // DistributionsComboBox
            // 
            this.DistributionsComboBox.FormattingEnabled = true;
            this.DistributionsComboBox.ItemHeight = 23;
            this.DistributionsComboBox.Location = new System.Drawing.Point(207, 43);
            this.DistributionsComboBox.MaxDropDownItems = 100;
            this.DistributionsComboBox.Name = "DistributionsComboBox";
            this.DistributionsComboBox.Size = new System.Drawing.Size(274, 29);
            this.DistributionsComboBox.TabIndex = 0;
            this.DistributionsComboBox.UseSelectable = true;
            // 
            // Transform
            // 
            this.Transform.Location = new System.Drawing.Point(3, 43);
            this.Transform.Name = "Transform";
            this.Transform.Size = new System.Drawing.Size(201, 29);
            this.Transform.TabIndex = 1;
            this.Transform.Text = "Transform";
            this.Transform.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.selectedAreaControl1);
            this.metroPanel1.Controls.Add(this.DistributionsComboBox);
            this.metroPanel1.Controls.Add(this.ToolBarMenu);
            this.metroPanel1.Controls.Add(this.Transform);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(874, 131);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // selectedAreaControl1
            // 
            this.selectedAreaControl1.Location = new System.Drawing.Point(503, 0);
            this.selectedAreaControl1.Margin = new System.Windows.Forms.Padding(0);
            this.selectedAreaControl1.Name = "selectedAreaControl1";
            this.selectedAreaControl1.Size = new System.Drawing.Size(267, 135);
            this.selectedAreaControl1.TabIndex = 7;
            this.selectedAreaControl1.UseSelectable = true;
            // 
            // DistributionForm
            // 
            this.ClientSize = new System.Drawing.Size(922, 214);
            this.Controls.Add(this.metroPanel1);
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
            this.metroPanel1.ResumeLayout(false);
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
        private Control.QualityMeasureToolStripButton QualityMeasure;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private Controls.SelectedAreaControl selectedAreaControl1;
    }
}
