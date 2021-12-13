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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)(this.ColorMatrixGrid)).BeginInit();
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
            this.ApplyCustomColorMatrixButton.Location = new System.Drawing.Point(323, 119);
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
            this.CustomColorMatrix.Location = new System.Drawing.Point(343, 98);
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
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            this.ColorMatrixGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle16;
            this.ColorMatrixGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ColorMatrixGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ColorMatrixGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.ColorMatrixGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorMatrixGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.ColorMatrixGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ColorMatrixGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.j0,
            this.j1,
            this.j2,
            this.j3,
            this.j4});
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorMatrixGrid.DefaultCellStyle = dataGridViewCellStyle18;
            this.ColorMatrixGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.ColorMatrixGrid.EnableHeadersVisualStyles = false;
            this.ColorMatrixGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ColorMatrixGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ColorMatrixGrid.Location = new System.Drawing.Point(24, 63);
            this.ColorMatrixGrid.Name = "ColorMatrixGrid";
            this.ColorMatrixGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColorMatrixGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.ColorMatrixGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColorMatrixGrid.RowsDefaultCellStyle = dataGridViewCellStyle20;
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
            this.ApplyColorMatrixButton.Location = new System.Drawing.Point(323, 119);
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
            this.ColorMatrixComboBox.Location = new System.Drawing.Point(323, 63);
            this.ColorMatrixComboBox.Name = "ColorMatrixComboBox";
            this.ColorMatrixComboBox.Size = new System.Drawing.Size(293, 29);
            this.ColorMatrixComboBox.TabIndex = 8;
            this.ColorMatrixComboBox.UseSelectable = true;
            // 
            // ColorMatrixForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 272);
            this.Controls.Add(this.ApplyCustomColorMatrixButton);
            this.Controls.Add(this.CustomColorMatrix);
            this.Controls.Add(this.ColorMatrixGrid);
            this.Controls.Add(this.ApplyColorMatrixButton);
            this.Controls.Add(this.ColorMatrixComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "ColorMatrixForm";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            this.Text = "Color Matrix";
            ((System.ComponentModel.ISupportInitialize)(this.ColorMatrixGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
