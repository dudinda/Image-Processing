namespace ImageProcessing.App.UILayer.Forms.Rgb
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
            this.ShowToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ApplyFilter = new MetroFramework.Controls.MetroButton();
            this.RgbFilterComboBox = new MetroFramework.Controls.MetroComboBox();
            this.ColorMatrixMenu = new MetroFramework.Controls.MetroButton();
            this.CheckboxColorGroup = new MetroFramework.Controls.MetroPanel();
            this.BlueColor = new MetroFramework.Controls.MetroCheckBox();
            this.GreenColor = new MetroFramework.Controls.MetroCheckBox();
            this.RedColor = new MetroFramework.Controls.MetroCheckBox();
            this.CheckboxColorGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ApplyFilter
            // 
            this.ApplyFilter.Location = new System.Drawing.Point(23, 98);
            this.ApplyFilter.Name = "ApplyFilter";
            this.ApplyFilter.Size = new System.Drawing.Size(235, 23);
            this.ApplyFilter.TabIndex = 8;
            this.ApplyFilter.Text = "Apply ";
            this.ApplyFilter.UseSelectable = true;
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
            // ColorMatrixMenu
            // 
            this.ColorMatrixMenu.Location = new System.Drawing.Point(23, 127);
            this.ColorMatrixMenu.Name = "ColorMatrixMenu";
            this.ColorMatrixMenu.Size = new System.Drawing.Size(235, 23);
            this.ColorMatrixMenu.TabIndex = 6;
            this.ColorMatrixMenu.Text = "Color Matrix";
            this.ColorMatrixMenu.UseSelectable = true;
            // 
            // CheckboxColorGroup
            // 
            this.CheckboxColorGroup.Controls.Add(this.BlueColor);
            this.CheckboxColorGroup.Controls.Add(this.GreenColor);
            this.CheckboxColorGroup.Controls.Add(this.RedColor);
            this.CheckboxColorGroup.HorizontalScrollbarBarColor = true;
            this.CheckboxColorGroup.HorizontalScrollbarHighlightOnWheel = false;
            this.CheckboxColorGroup.HorizontalScrollbarSize = 10;
            this.CheckboxColorGroup.Location = new System.Drawing.Point(264, 62);
            this.CheckboxColorGroup.Name = "CheckboxColorGroup";
            this.CheckboxColorGroup.Size = new System.Drawing.Size(135, 88);
            this.CheckboxColorGroup.TabIndex = 0;
            this.CheckboxColorGroup.VerticalScrollbarBarColor = true;
            this.CheckboxColorGroup.VerticalScrollbarHighlightOnWheel = false;
            this.CheckboxColorGroup.VerticalScrollbarSize = 10;
            // 
            // BlueColor
            // 
            this.BlueColor.AutoSize = true;
            this.BlueColor.Location = new System.Drawing.Point(43, 57);
            this.BlueColor.Name = "BlueColor";
            this.BlueColor.Size = new System.Drawing.Size(46, 15);
            this.BlueColor.TabIndex = 4;
            this.BlueColor.Text = "Blue";
            this.BlueColor.UseSelectable = true;
            // 
            // GreenColor
            // 
            this.GreenColor.AutoSize = true;
            this.GreenColor.Location = new System.Drawing.Point(43, 36);
            this.GreenColor.Name = "GreenColor";
            this.GreenColor.Size = new System.Drawing.Size(54, 15);
            this.GreenColor.TabIndex = 3;
            this.GreenColor.Text = "Green";
            this.GreenColor.UseSelectable = true;
            // 
            // RedColor
            // 
            this.RedColor.AutoSize = true;
            this.RedColor.Location = new System.Drawing.Point(43, 14);
            this.RedColor.Name = "RedColor";
            this.RedColor.Size = new System.Drawing.Size(43, 15);
            this.RedColor.TabIndex = 2;
            this.RedColor.Text = "Red";
            this.RedColor.UseSelectable = true;
            // 
            // RgbForm
            // 
            this.ClientSize = new System.Drawing.Size(422, 172);
            this.Controls.Add(this.ApplyFilter);
            this.Controls.Add(this.RgbFilterComboBox);
            this.Controls.Add(this.ColorMatrixMenu);
            this.Controls.Add(this.CheckboxColorGroup);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RgbForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Rgb";
            this.CheckboxColorGroup.ResumeLayout(false);
            this.CheckboxColorGroup.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private MetroFramework.Controls.MetroPanel CheckboxColorGroup;
        private MetroFramework.Controls.MetroButton ColorMatrixMenu;
        private MetroFramework.Controls.MetroComboBox RgbFilterComboBox;
        public MetroFramework.Controls.MetroButton ApplyFilter;
        private System.Windows.Forms.ToolTip ShowToolTip;
        private MetroFramework.Controls.MetroCheckBox BlueColor;
        private MetroFramework.Controls.MetroCheckBox GreenColor;
        private MetroFramework.Controls.MetroCheckBox RedColor;
    }
}
