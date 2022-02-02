
namespace ImageProcessing.App.UILayer.Forms.Rotation
{
    partial class RotationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotationForm));
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.DegreesTextBox = new MetroFramework.Controls.MetroTextBox();
            this.DegreesText = new System.Windows.Forms.PictureBox();
            this.RotationComboBox = new MetroFramework.Controls.MetroComboBox();
            this.ApplyRotation = new MetroFramework.Controls.MetroButton();
            this.ShowToolTip = new MetroFramework.Components.MetroToolTip();
            this.RotationButtonPanel = new MetroFramework.Controls.MetroPanel();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DegreesText)).BeginInit();
            this.RotationButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.DegreesTextBox);
            this.metroPanel1.Controls.Add(this.DegreesText);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 50);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(286, 29);
            this.metroPanel1.TabIndex = 10;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // DegreesTextBox
            // 
            // 
            // 
            // 
            this.DegreesTextBox.CustomButton.Image = null;
            this.DegreesTextBox.CustomButton.Location = new System.Drawing.Point(245, 1);
            this.DegreesTextBox.CustomButton.Name = "";
            this.DegreesTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.DegreesTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DegreesTextBox.CustomButton.TabIndex = 1;
            this.DegreesTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DegreesTextBox.CustomButton.UseSelectable = true;
            this.DegreesTextBox.CustomButton.Visible = false;
            this.DegreesTextBox.Lines = new string[0];
            this.DegreesTextBox.Location = new System.Drawing.Point(19, 1);
            this.DegreesTextBox.MaxLength = 32767;
            this.DegreesTextBox.Name = "DegreesTextBox";
            this.DegreesTextBox.PasswordChar = '\0';
            this.DegreesTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DegreesTextBox.SelectedText = "";
            this.DegreesTextBox.SelectionLength = 0;
            this.DegreesTextBox.SelectionStart = 0;
            this.DegreesTextBox.ShortcutsEnabled = true;
            this.DegreesTextBox.Size = new System.Drawing.Size(267, 23);
            this.DegreesTextBox.TabIndex = 3;
            this.DegreesTextBox.UseSelectable = true;
            this.DegreesTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DegreesTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DegreesText
            // 
            this.DegreesText.Image = ((System.Drawing.Image)(resources.GetObject("DegreesText.Image")));
            this.DegreesText.Location = new System.Drawing.Point(0, 1);
            this.DegreesText.Name = "DegreesText";
            this.DegreesText.Size = new System.Drawing.Size(10, 25);
            this.DegreesText.TabIndex = 2;
            this.DegreesText.TabStop = false;
            // 
            // RotationComboBox
            // 
            this.RotationComboBox.FormattingEnabled = true;
            this.RotationComboBox.ItemHeight = 23;
            this.RotationComboBox.Location = new System.Drawing.Point(3, 15);
            this.RotationComboBox.MaxDropDownItems = 100;
            this.RotationComboBox.Name = "RotationComboBox";
            this.RotationComboBox.Size = new System.Drawing.Size(286, 29);
            this.RotationComboBox.TabIndex = 8;
            this.RotationComboBox.UseSelectable = true;
            // 
            // ApplyRotation
            // 
            this.ApplyRotation.Location = new System.Drawing.Point(3, 85);
            this.ApplyRotation.Name = "ApplyRotation";
            this.ApplyRotation.Size = new System.Drawing.Size(286, 31);
            this.ApplyRotation.TabIndex = 9;
            this.ApplyRotation.Text = "Rotate";
            this.ApplyRotation.UseSelectable = true;
            // 
            // ShowToolTip
            // 
            this.ShowToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.ShowToolTip.StyleManager = null;
            this.ShowToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // RotationButtonPanel
            // 
            this.RotationButtonPanel.Controls.Add(this.RotationComboBox);
            this.RotationButtonPanel.Controls.Add(this.metroPanel1);
            this.RotationButtonPanel.Controls.Add(this.ApplyRotation);
            this.RotationButtonPanel.HorizontalScrollbarBarColor = true;
            this.RotationButtonPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.RotationButtonPanel.HorizontalScrollbarSize = 10;
            this.RotationButtonPanel.Location = new System.Drawing.Point(23, 63);
            this.RotationButtonPanel.Name = "RotationButtonPanel";
            this.RotationButtonPanel.Size = new System.Drawing.Size(298, 119);
            this.RotationButtonPanel.TabIndex = 11;
            this.RotationButtonPanel.VerticalScrollbarBarColor = true;
            this.RotationButtonPanel.VerticalScrollbarHighlightOnWheel = false;
            this.RotationButtonPanel.VerticalScrollbarSize = 10;
            // 
            // RotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 194);
            this.Controls.Add(this.RotationButtonPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "RotationForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Rotation";
            this.metroPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DegreesText)).EndInit();
            this.RotationButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTextBox DegreesTextBox;
        private System.Windows.Forms.PictureBox DegreesText;
        private MetroFramework.Controls.MetroComboBox RotationComboBox;
        private MetroFramework.Controls.MetroButton ApplyRotation;
        private MetroFramework.Components.MetroToolTip ShowToolTip;
        private MetroFramework.Controls.MetroPanel RotationButtonPanel;
    }
}