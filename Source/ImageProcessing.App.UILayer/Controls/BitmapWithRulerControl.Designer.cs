
namespace ImageProcessing.App.UILayer.Controls
{
    partial class BitmapWithRulerControl
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
            this.ParentPanel = new MetroFramework.Controls.MetroPanel();
            this.SuspendLayout();
            // 
            // ParentPanel
            // 
            this.ParentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ParentPanel.HorizontalScrollbarBarColor = true;
            this.ParentPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ParentPanel.HorizontalScrollbarSize = 10;
            this.ParentPanel.Location = new System.Drawing.Point(40, 40);
            this.ParentPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ParentPanel.Name = "ParentPanel";
            this.ParentPanel.Padding = new System.Windows.Forms.Padding(30);
            this.ParentPanel.Size = new System.Drawing.Size(620, 620);
            this.ParentPanel.TabIndex = 0;
            this.ParentPanel.VerticalScrollbarBarColor = true;
            this.ParentPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ParentPanel.VerticalScrollbarSize = 10;
            // 
            // BitmapWithRulerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ParentPanel);
            this.Name = "BitmapWithRulerControl";
            this.Padding = new System.Windows.Forms.Padding(40);
            this.Size = new System.Drawing.Size(700, 700);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel ParentPanel;
    }
}
