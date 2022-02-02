namespace ImageProcessing.App.UILayer.Forms.Convolution
{
    partial class ConvolutionForm
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
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ConvolutionFilterComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Apply = new MetroFramework.Controls.MetroButton();
            this.ConvoltuionButtonPanel = new MetroFramework.Controls.MetroPanel();
            this.ConvoltuionButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConvolutionFilterComboBox
            // 
            this.ConvolutionFilterComboBox.FormattingEnabled = true;
            this.ConvolutionFilterComboBox.ItemHeight = 23;
            this.ConvolutionFilterComboBox.Location = new System.Drawing.Point(3, 10);
            this.ConvolutionFilterComboBox.MaxDropDownItems = 100;
            this.ConvolutionFilterComboBox.Name = "ConvolutionFilterComboBox";
            this.ConvolutionFilterComboBox.Size = new System.Drawing.Size(254, 29);
            this.ConvolutionFilterComboBox.TabIndex = 0;
            this.ConvolutionFilterComboBox.UseSelectable = true;
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(3, 45);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(254, 23);
            this.Apply.TabIndex = 1;
            this.Apply.Text = "Apply";
            this.Apply.UseSelectable = true;
            // 
            // ConvoltuionButtonPanel
            // 
            this.ConvoltuionButtonPanel.Controls.Add(this.ConvolutionFilterComboBox);
            this.ConvoltuionButtonPanel.Controls.Add(this.Apply);
            this.ConvoltuionButtonPanel.HorizontalScrollbarBarColor = true;
            this.ConvoltuionButtonPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ConvoltuionButtonPanel.HorizontalScrollbarSize = 10;
            this.ConvoltuionButtonPanel.Location = new System.Drawing.Point(23, 53);
            this.ConvoltuionButtonPanel.Name = "ConvoltuionButtonPanel";
            this.ConvoltuionButtonPanel.Size = new System.Drawing.Size(263, 76);
            this.ConvoltuionButtonPanel.TabIndex = 2;
            this.ConvoltuionButtonPanel.VerticalScrollbarBarColor = true;
            this.ConvoltuionButtonPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ConvoltuionButtonPanel.VerticalScrollbarSize = 10;
            // 
            // ConvolutionForm
            // 
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(319, 130);
            this.Controls.Add(this.ConvoltuionButtonPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ConvolutionForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Convolution Kernel";
            this.ConvoltuionButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ErrorToolTip;
        private MetroFramework.Controls.MetroComboBox ConvolutionFilterComboBox;
        private MetroFramework.Controls.MetroButton Apply;
        private MetroFramework.Controls.MetroPanel ConvoltuionButtonPanel;
    }
}
