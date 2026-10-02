
namespace ImageProcessing.App.UILayer.Controls
{
    sealed partial class BitmapWithRulerControl
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
            this.SourceContainer = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SourceContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // SourceContainer
            // 
            this.SourceContainer.Location = new System.Drawing.Point(40, 40);
            this.SourceContainer.Margin = new System.Windows.Forms.Padding(0);
            this.SourceContainer.Name = "SourceContainer";
            this.SourceContainer.Size = new System.Drawing.Size(200, 200);
            this.SourceContainer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SourceContainer.TabIndex = 4;
            this.SourceContainer.TabStop = false;
            // 
            // BitmapWithRulerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.SourceContainer);
            this.DoubleBuffered = true;
            this.Name = "BitmapWithRulerControl";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Size = new System.Drawing.Size(465, 301);
            ((System.ComponentModel.ISupportInitialize)(this.SourceContainer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox SourceContainer;
    }
}
