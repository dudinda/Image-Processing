namespace ImageProcessing.App.UILayer.Form.Convolution
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
            this.SuspendLayout();
            // 
            // ConvolutionFilterComboBox
            // 
            this.ConvolutionFilterComboBox.FormattingEnabled = true;
            this.ConvolutionFilterComboBox.ItemHeight = 23;
            this.ConvolutionFilterComboBox.Location = new System.Drawing.Point(23, 60);
            this.ConvolutionFilterComboBox.MaxDropDownItems = 100;
            this.ConvolutionFilterComboBox.Name = "ConvolutionFilterComboBox";
            this.ConvolutionFilterComboBox.Size = new System.Drawing.Size(254, 29);
            this.ConvolutionFilterComboBox.TabIndex = 0;
            this.ConvolutionFilterComboBox.UseSelectable = true;
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(23, 95);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(254, 23);
            this.Apply.TabIndex = 1;
            this.Apply.Text = "Apply";
            this.Apply.UseSelectable = true;
            // 
            // ConvolutionForm
            // 
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(300, 130);
            this.Controls.Add(this.ConvolutionFilterComboBox);
            this.Controls.Add(this.Apply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvolutionForm";
            this.Resizable = false;
            this.Text = "Convolution Kernel";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ErrorToolTip;
        private MetroFramework.Controls.MetroComboBox ConvolutionFilterComboBox;
        private MetroFramework.Controls.MetroButton Apply;
    }
}
