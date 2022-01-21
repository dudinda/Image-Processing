namespace ImageProcessing.App.UILayer.Forms.ColorMatrix
{
    partial class ColorMatrixForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ErrorToolTip = new MetroFramework.Components.MetroToolTip();
            this.ApplyCustomColorMatrixButton = new MetroFramework.Controls.MetroButton();
            this.CustomColorMatrix = new MetroFramework.Controls.MetroCheckBox();
            this.ColorMatrixGrid = new MetroFramework.Controls.MetroGrid();
            this.j0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.j4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplyColorMatrixButton = new MetroFramework.Controls.MetroButton();
            this.ColorMatrixComboBox = new MetroFramework.Controls.MetroComboBox();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.selectedAreaControl1 = new ImageProcessing.App.UILayer.Controls.SelectedAreaControl();
            ((System.ComponentModel.ISupportInitialize)(this.ColorMatrixGrid)).BeginInit();
            this.metroPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorToolTip
            // 
            this.ErrorToolTip.Style = MetroFramework.MetroColorStyle.Blue;
            this.ErrorToolTip.StyleManager = null;
            this.ErrorToolTip.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // ApplyCustomColorMatrixButton
            // 
            this.ApplyCustomColorMatrixButton.Location = new System.Drawing.Point(320, 92);
            this.ApplyCustomColorMatrixButton.Name = "ApplyCustomColorMatrixButton";
            this.ApplyCustomColorMatrixButton.Size = new System.Drawing.Size(293, 36);
            this.ApplyCustomColorMatrixButton.TabIndex = 15;
            this.ApplyCustomColorMatrixButton.Text = "Apply";
            this.ApplyCustomColorMatrixButton.UseSelectable = true;
            this.ApplyCustomColorMatrixButton.Visible = false;
            // 
            // CustomColorMatrix
            // 
            this.CustomColorMatrix.AutoSize = true;
            this.CustomColorMatrix.Location = new System.Drawing.Point(320, 71);
            this.CustomColorMatrix.Name = "CustomColorMatrix";
            this.CustomColorMatrix.Size = new System.Drawing.Size(134, 15);
            this.CustomColorMatrix.TabIndex = 14;
            this.CustomColorMatrix.Text = "Custom Color Matrix";
            this.CustomColorMatrix.UseSelectable = true;
            // 
            // ColorMatrixGrid
            // 
            this.ColorMatrixGrid.AllowUserToAddRows = false;
            this.ColorMatrixGrid.AllowUserToDeleteRows = false;
            this.ColorMatrixGrid.AllowUserToResizeColumns = false;
            this.ColorMatrixGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.ColorMatrixGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.ColorMatrixGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ColorMatrixGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColorMatrixGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ColorMatrixGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorMatrixGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ColorMatrixGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColorMatrixGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.j0,
            this.j1,
            this.j2,
            this.j3,
            this.j4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorMatrixGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColorMatrixGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ColorMatrixGrid.EnableHeadersVisualStyles = false;
            this.ColorMatrixGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ColorMatrixGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ColorMatrixGrid.Location = new System.Drawing.Point(21, 36);
            this.ColorMatrixGrid.Name = "ColorMatrixGrid";
            this.ColorMatrixGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorMatrixGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ColorMatrixGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColorMatrixGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ColorMatrixGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ColorMatrixGrid.Size = new System.Drawing.Size(293, 145);
            this.ColorMatrixGrid.TabIndex = 13;
            // 
            // j0
            // 
            this.j0.FillWeight = 50F;
            this.j0.HeaderText = "R";
            this.j0.MinimumWidth = 50;
            this.j0.Name = "j0";
            this.j0.ReadOnly = true;
            this.j0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j0.Width = 50;
            // 
            // j1
            // 
            this.j1.FillWeight = 50F;
            this.j1.HeaderText = "G";
            this.j1.MinimumWidth = 50;
            this.j1.Name = "j1";
            this.j1.ReadOnly = true;
            this.j1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j1.Width = 50;
            // 
            // j2
            // 
            this.j2.FillWeight = 50F;
            this.j2.HeaderText = "B";
            this.j2.MinimumWidth = 50;
            this.j2.Name = "j2";
            this.j2.ReadOnly = true;
            this.j2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j2.Width = 50;
            // 
            // j3
            // 
            this.j3.FillWeight = 50F;
            this.j3.HeaderText = "A";
            this.j3.MinimumWidth = 50;
            this.j3.Name = "j3";
            this.j3.ReadOnly = true;
            this.j3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j3.Width = 50;
            // 
            // j4
            // 
            this.j4.FillWeight = 50F;
            this.j4.HeaderText = "W";
            this.j4.MinimumWidth = 50;
            this.j4.Name = "j4";
            this.j4.ReadOnly = true;
            this.j4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.j4.Width = 50;
            // 
            // ApplyColorMatrixButton
            // 
            this.ApplyColorMatrixButton.Location = new System.Drawing.Point(320, 92);
            this.ApplyColorMatrixButton.Name = "ApplyColorMatrixButton";
            this.ApplyColorMatrixButton.Size = new System.Drawing.Size(293, 36);
            this.ApplyColorMatrixButton.TabIndex = 12;
            this.ApplyColorMatrixButton.Text = "Apply";
            this.ApplyColorMatrixButton.UseSelectable = true;
            // 
            // ColorMatrixComboBox
            // 
            this.ColorMatrixComboBox.FormattingEnabled = true;
            this.ColorMatrixComboBox.ItemHeight = 23;
            this.ColorMatrixComboBox.Location = new System.Drawing.Point(320, 36);
            this.ColorMatrixComboBox.Name = "ColorMatrixComboBox";
            this.ColorMatrixComboBox.Size = new System.Drawing.Size(293, 29);
            this.ColorMatrixComboBox.TabIndex = 8;
            this.ColorMatrixComboBox.UseSelectable = true;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.selectedAreaControl1);
            this.metroPanel1.Controls.Add(this.ColorMatrixComboBox);
            this.metroPanel1.Controls.Add(this.CustomColorMatrix);
            this.metroPanel1.Controls.Add(this.ApplyCustomColorMatrixButton);
            this.metroPanel1.Controls.Add(this.ApplyColorMatrixButton);
            this.metroPanel1.Controls.Add(this.ColorMatrixGrid);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 52);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(911, 197);
            this.metroPanel1.TabIndex = 16;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // selectedAreaControl1
            // 
            this.selectedAreaControl1.Location = new System.Drawing.Point(620, 36);
            this.selectedAreaControl1.Margin = new System.Windows.Forms.Padding(0);
            this.selectedAreaControl1.Name = "selectedAreaControl1";
            this.selectedAreaControl1.Size = new System.Drawing.Size(267, 118);
            this.selectedAreaControl1.TabIndex = 16;
            this.selectedAreaControl1.UseSelectable = true;
            // 
            // ColorMatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 272);
            this.Controls.Add(this.metroPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ColorMatrixForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Color Matrix";
            ((System.ComponentModel.ISupportInitialize)(this.ColorMatrixGrid)).EndInit();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroComboBox ColorMatrixComboBox;
        private MetroFramework.Controls.MetroButton ApplyColorMatrixButton;
        private MetroFramework.Controls.MetroGrid ColorMatrixGrid;
        private MetroFramework.Controls.MetroCheckBox CustomColorMatrix;
        private MetroFramework.Controls.MetroButton ApplyCustomColorMatrixButton;
        private MetroFramework.Components.MetroToolTip ErrorToolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn j0;
        private System.Windows.Forms.DataGridViewTextBoxColumn j1;
        private System.Windows.Forms.DataGridViewTextBoxColumn j2;
        private System.Windows.Forms.DataGridViewTextBoxColumn j3;
        private System.Windows.Forms.DataGridViewTextBoxColumn j4;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private Controls.SelectedAreaControl selectedAreaControl1;
    }
}
