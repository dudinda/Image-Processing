namespace ImageProcessing.UILayer.Form.Convolution
{ 
    partial class ConvolutionFilterForm
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
            this.ConvolutionFilterComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Apply = new MetroFramework.Controls.MetroButton();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // ConvolutionFilterComboBox
            // 
            this.ConvolutionFilterComboBox.FormattingEnabled = true;
            this.ConvolutionFilterComboBox.ItemHeight = 23;
            this.ConvolutionFilterComboBox.Items.AddRange(new object[] {
            "Select a filter..."});
            this.ConvolutionFilterComboBox.Location = new System.Drawing.Point(23, 29);
            this.ConvolutionFilterComboBox.Name = "ConvolutionFilterComboBox";
            this.ConvolutionFilterComboBox.Size = new System.Drawing.Size(254, 29);
            this.ConvolutionFilterComboBox.TabIndex = 0;
            this.ConvolutionFilterComboBox.UseSelectable = true;
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(23, 81);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(254, 23);
            this.Apply.TabIndex = 1;
            this.Apply.Text = "Apply";
            this.Apply.UseSelectable = true;
            // 
            // ConvolutionFilterForm
            // 
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(300, 130);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.ConvolutionFilterComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvolutionFilterForm";
            this.Resizable = false;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

		#endregion
		private MetroFramework.Controls.MetroComboBox ConvolutionFilterComboBox;
        private MetroFramework.Controls.MetroButton Apply;
        private System.Windows.Forms.ToolTip ErrorToolTip;
    }
}
