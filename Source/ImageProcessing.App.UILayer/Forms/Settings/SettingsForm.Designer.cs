namespace ImageProcessing.App.UILayer.Forms.Settings
{
    partial class SettingsForm
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
        { }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LumaLabel = new MetroFramework.Controls.MetroLabel();
            this.RotationLabel = new MetroFramework.Controls.MetroLabel();
            this.ScalingLabel = new MetroFramework.Controls.MetroLabel();
            this.RotationComboBox = new MetroFramework.Controls.MetroComboBox();
            this.LumaComboBox = new MetroFramework.Controls.MetroComboBox();
            this.ScalingComboBox = new MetroFramework.Controls.MetroComboBox();
            this.SuspendLayout();
            // 
            // LumaLabel
            // 
            this.LumaLabel.AutoSize = true;
            this.LumaLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.LumaLabel.Location = new System.Drawing.Point(455, 60);
            this.LumaLabel.Name = "LumaLabel";
            this.LumaLabel.Size = new System.Drawing.Size(146, 25);
            this.LumaLabel.TabIndex = 13;
            this.LumaLabel.Text = "Recommendation";
            // 
            // RotationLabel
            // 
            this.RotationLabel.AutoSize = true;
            this.RotationLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.RotationLabel.Location = new System.Drawing.Point(239, 60);
            this.RotationLabel.Name = "RotationLabel";
            this.RotationLabel.Size = new System.Drawing.Size(75, 25);
            this.RotationLabel.TabIndex = 12;
            this.RotationLabel.Text = "Rotation";
            // 
            // ScalingLabel
            // 
            this.ScalingLabel.AutoSize = true;
            this.ScalingLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.ScalingLabel.Location = new System.Drawing.Point(23, 60);
            this.ScalingLabel.Name = "ScalingLabel";
            this.ScalingLabel.Size = new System.Drawing.Size(66, 25);
            this.ScalingLabel.TabIndex = 11;
            this.ScalingLabel.Text = "Scaling";
            // 
            // RotationComboBox
            // 
            this.RotationComboBox.FormattingEnabled = true;
            this.RotationComboBox.ItemHeight = 23;
            this.RotationComboBox.Location = new System.Drawing.Point(239, 88);
            this.RotationComboBox.Name = "RotationComboBox";
            this.RotationComboBox.Size = new System.Drawing.Size(210, 29);
            this.RotationComboBox.TabIndex = 10;
            this.RotationComboBox.UseSelectable = true;
            // 
            // LumaComboBox
            // 
            this.LumaComboBox.FormattingEnabled = true;
            this.LumaComboBox.ItemHeight = 23;
            this.LumaComboBox.Location = new System.Drawing.Point(455, 88);
            this.LumaComboBox.Name = "LumaComboBox";
            this.LumaComboBox.Size = new System.Drawing.Size(210, 29);
            this.LumaComboBox.TabIndex = 9;
            this.LumaComboBox.UseSelectable = true;
            // 
            // ScalingComboBox
            // 
            this.ScalingComboBox.FormattingEnabled = true;
            this.ScalingComboBox.ItemHeight = 23;
            this.ScalingComboBox.Location = new System.Drawing.Point(23, 88);
            this.ScalingComboBox.Name = "ScalingComboBox";
            this.ScalingComboBox.Size = new System.Drawing.Size(210, 29);
            this.ScalingComboBox.TabIndex = 8;
            this.ScalingComboBox.UseSelectable = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 157);
            this.Controls.Add(this.LumaLabel);
            this.Controls.Add(this.RotationLabel);
            this.Controls.Add(this.ScalingLabel);
            this.Controls.Add(this.RotationComboBox);
            this.Controls.Add(this.LumaComboBox);
            this.Controls.Add(this.ScalingComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox ScalingComboBox;
        private MetroFramework.Controls.MetroComboBox LumaComboBox;
        private MetroFramework.Controls.MetroComboBox RotationComboBox;
        private MetroFramework.Controls.MetroLabel ScalingLabel;
        private MetroFramework.Controls.MetroLabel RotationLabel;
        private MetroFramework.Controls.MetroLabel LumaLabel;
    }
}
