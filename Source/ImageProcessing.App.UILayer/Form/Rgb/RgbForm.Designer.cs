namespace ImageProcessing.App.UILayer.Form.Rgb
{
    partial class RgbForm
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
            this.RadioColorGroup = new MetroFramework.Controls.MetroPanel();
            this.BlueColor = new MetroFramework.Controls.MetroRadioButton();
            this.GreenColor = new MetroFramework.Controls.MetroRadioButton();
            this.RedColor = new MetroFramework.Controls.MetroRadioButton();
            this.Palette = new MetroFramework.Controls.MetroButton();
            this.RgbFilterComboBox = new MetroFramework.Controls.MetroComboBox();
            this.ApplyFilter = new MetroFramework.Controls.MetroButton();
            this.ShowToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RadioColorGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // RadioColorGroup
            // 
            this.RadioColorGroup.Controls.Add(this.BlueColor);
            this.RadioColorGroup.Controls.Add(this.GreenColor);
            this.RadioColorGroup.Controls.Add(this.RedColor);
            this.RadioColorGroup.HorizontalScrollbarBarColor = true;
            this.RadioColorGroup.HorizontalScrollbarHighlightOnWheel = false;
            this.RadioColorGroup.HorizontalScrollbarSize = 10;
            this.RadioColorGroup.Location = new System.Drawing.Point(264, 62);
            this.RadioColorGroup.Name = "RadioColorGroup";
            this.RadioColorGroup.Size = new System.Drawing.Size(135, 88);
            this.RadioColorGroup.TabIndex = 0;
            this.RadioColorGroup.VerticalScrollbarBarColor = true;
            this.RadioColorGroup.VerticalScrollbarHighlightOnWheel = false;
            this.RadioColorGroup.VerticalScrollbarSize = 10;
            // 
            // BlueColor
            // 
            this.BlueColor.AutoSize = true;
            this.BlueColor.Location = new System.Drawing.Point(41, 55);
            this.BlueColor.Name = "BlueColor";
            this.BlueColor.Size = new System.Drawing.Size(46, 15);
            this.BlueColor.TabIndex = 5;
            this.BlueColor.Text = "Blue";
            this.BlueColor.UseSelectable = true;
            // 
            // GreenColor
            // 
            this.GreenColor.AutoSize = true;
            this.GreenColor.Location = new System.Drawing.Point(41, 33);
            this.GreenColor.Name = "GreenColor";
            this.GreenColor.Size = new System.Drawing.Size(54, 15);
            this.GreenColor.TabIndex = 4;
            this.GreenColor.Text = "Green";
            this.GreenColor.UseSelectable = true;
            // 
            // RedColor
            // 
            this.RedColor.AutoSize = true;
            this.RedColor.Location = new System.Drawing.Point(41, 12);
            this.RedColor.Name = "RedColor";
            this.RedColor.Size = new System.Drawing.Size(43, 15);
            this.RedColor.TabIndex = 2;
            this.RedColor.Text = "Red";
            this.RedColor.UseSelectable = true;
            // 
            // Palette
            // 
            this.Palette.Location = new System.Drawing.Point(23, 127);
            this.Palette.Name = "Palette";
            this.Palette.Size = new System.Drawing.Size(235, 23);
            this.Palette.TabIndex = 6;
            this.Palette.Text = "Select color";
            this.Palette.UseSelectable = true;
            // 
            // RgbFilterComboBox
            // 
            this.RgbFilterComboBox.FormattingEnabled = true;
            this.RgbFilterComboBox.ItemHeight = 23;
            this.RgbFilterComboBox.Location = new System.Drawing.Point(23, 62);
            this.RgbFilterComboBox.Name = "RgbFilterComboBox";
            this.RgbFilterComboBox.Size = new System.Drawing.Size(235, 29);
            this.RgbFilterComboBox.TabIndex = 7;
            this.RgbFilterComboBox.UseSelectable = true;
            // 
            // ApplyFilter
            // 
            this.ApplyFilter.Location = new System.Drawing.Point(23, 98);
            this.ApplyFilter.Name = "ApplyFilter";
            this.ApplyFilter.Size = new System.Drawing.Size(235, 23);
            this.ApplyFilter.TabIndex = 8;
            this.ApplyFilter.Text = "Apply Filter";
            this.ApplyFilter.UseSelectable = true;
            // 
            // RgbForm
            // 
            this.ClientSize = new System.Drawing.Size(422, 172);
            this.Controls.Add(this.ApplyFilter);
            this.Controls.Add(this.RgbFilterComboBox);
            this.Controls.Add(this.Palette);
            this.Controls.Add(this.RadioColorGroup);
            this.Name = "RgbForm";
            this.Resizable = false;
            this.Text = "Rgb Filters";
            this.RadioColorGroup.ResumeLayout(false);
            this.RadioColorGroup.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private MetroFramework.Controls.MetroPanel RadioColorGroup;
        private MetroFramework.Controls.MetroButton Palette;
        private MetroFramework.Controls.MetroComboBox RgbFilterComboBox;
        public MetroFramework.Controls.MetroRadioButton BlueColor;
        public MetroFramework.Controls.MetroRadioButton GreenColor;
        public MetroFramework.Controls.MetroRadioButton RedColor;
        public MetroFramework.Controls.MetroButton ApplyFilter;
        private System.Windows.Forms.ToolTip ShowToolTip;
    }
}
