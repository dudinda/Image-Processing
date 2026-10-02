
namespace ImageProcessing.App.UILayer.Controls
{
    partial class SelectedAreaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopLeft = new System.Windows.Forms.TextBox();
            this.TopRight = new System.Windows.Forms.TextBox();
            this.BottomLeft = new System.Windows.Forms.TextBox();
            this.BottomRight = new System.Windows.Forms.TextBox();
            this.XLabel = new MetroFramework.Controls.MetroLabel();
            this.YLabel = new MetroFramework.Controls.MetroLabel();
            this.WidthLabel = new MetroFramework.Controls.MetroLabel();
            this.HeightLabel = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // TopLeft
            // 
            this.TopLeft.Location = new System.Drawing.Point(3, 3);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(68, 20);
            this.TopLeft.TabIndex = 0;
            // 
            // TopRight
            // 
            this.TopRight.Location = new System.Drawing.Point(77, 3);
            this.TopRight.Name = "TopRight";
            this.TopRight.Size = new System.Drawing.Size(68, 20);
            this.TopRight.TabIndex = 1;
            // 
            // BottomLeft
            // 
            this.BottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomLeft.Location = new System.Drawing.Point(122, 101);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(68, 20);
            this.BottomLeft.TabIndex = 2;
            // 
            // BottomRight
            // 
            this.BottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomRight.Location = new System.Drawing.Point(196, 101);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(68, 20);
            this.BottomRight.TabIndex = 3;
            // 
            // XLabel
            // 
            this.XLabel.AutoSize = true;
            this.XLabel.Location = new System.Drawing.Point(3, 26);
            this.XLabel.Name = "XLabel";
            this.XLabel.Size = new System.Drawing.Size(17, 19);
            this.XLabel.TabIndex = 4;
            this.XLabel.Text = "X";
            // 
            // YLabel
            // 
            this.YLabel.AutoSize = true;
            this.YLabel.Location = new System.Drawing.Point(77, 26);
            this.YLabel.Name = "YLabel";
            this.YLabel.Size = new System.Drawing.Size(17, 19);
            this.YLabel.TabIndex = 5;
            this.YLabel.Text = "Y";
            // 
            // WidthLabel
            // 
            this.WidthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(122, 79);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(44, 19);
            this.WidthLabel.TabIndex = 6;
            this.WidthLabel.Text = "Width";
            // 
            // HeightLabel
            // 
            this.HeightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(196, 79);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(47, 19);
            this.HeightLabel.TabIndex = 7;
            this.HeightLabel.Text = "Height";
            // 
            // SelectedAreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.YLabel);
            this.Controls.Add(this.XLabel);
            this.Controls.Add(this.BottomRight);
            this.Controls.Add(this.BottomLeft);
            this.Controls.Add(this.TopRight);
            this.Controls.Add(this.TopLeft);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SelectedAreaControl";
            this.Size = new System.Drawing.Size(267, 124);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TopLeft;
        private System.Windows.Forms.TextBox TopRight;
        private System.Windows.Forms.TextBox BottomLeft;
        private System.Windows.Forms.TextBox BottomRight;
        private MetroFramework.Controls.MetroLabel XLabel;
        private MetroFramework.Controls.MetroLabel YLabel;
        private MetroFramework.Controls.MetroLabel WidthLabel;
        private MetroFramework.Controls.MetroLabel HeightLabel;
    }
}
