
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
            this.SuspendLayout();
            // 
            // TopLeft
            // 
            this.TopLeft.Location = new System.Drawing.Point(3, 16);
            this.TopLeft.Name = "TopLeft";
            this.TopLeft.Size = new System.Drawing.Size(68, 20);
            this.TopLeft.TabIndex = 0;
            // 
            // TopRight
            // 
            this.TopRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopRight.Location = new System.Drawing.Point(196, 16);
            this.TopRight.Name = "TopRight";
            this.TopRight.Size = new System.Drawing.Size(68, 20);
            this.TopRight.TabIndex = 1;
            // 
            // BottomLeft
            // 
            this.BottomLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BottomLeft.Location = new System.Drawing.Point(3, 77);
            this.BottomLeft.Name = "BottomLeft";
            this.BottomLeft.Size = new System.Drawing.Size(68, 20);
            this.BottomLeft.TabIndex = 2;
            // 
            // BottomRight
            // 
            this.BottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BottomRight.Location = new System.Drawing.Point(196, 77);
            this.BottomRight.Name = "BottomRight";
            this.BottomRight.Size = new System.Drawing.Size(68, 20);
            this.BottomRight.TabIndex = 3;
            // 
            // SelectedAreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BottomRight);
            this.Controls.Add(this.BottomLeft);
            this.Controls.Add(this.TopRight);
            this.Controls.Add(this.TopLeft);
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
    }
}
