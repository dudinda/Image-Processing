namespace ImageProcessing.UI.Form.Convolution
{ 
    public partial class ConvolutionFilterForm
    {
        private void InitializeComponent()
        {
            this.ConvolutionFilterComboBox = new MetroFramework.Controls.MetroComboBox();
            this.Apply = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // ConvolutionFilterComboBox
            // 
            this.ConvolutionFilterComboBox.FormattingEnabled = true;
            this.ConvolutionFilterComboBox.ItemHeight = 24;
            this.ConvolutionFilterComboBox.Items.AddRange(new object[] {
            "Select a filter..."});
            this.ConvolutionFilterComboBox.Location = new System.Drawing.Point(23, 29);
            this.ConvolutionFilterComboBox.Name = "ConvolutionFilterComboBox";
            this.ConvolutionFilterComboBox.Size = new System.Drawing.Size(254, 30);
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
            this.ClientSize = new System.Drawing.Size(300, 130);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.ConvolutionFilterComboBox);
            this.Name = "ConvolutionFilterForm";
            this.Resizable = false;
            this.ResumeLayout(false);

        }

        private MetroFramework.Controls.MetroComboBox ConvolutionFilterComboBox;
        private MetroFramework.Controls.MetroButton Apply;
    }
}
