using System.Windows.Forms;

namespace ImageProcessing.App.UILayer.Forms.Main
{
    internal partial class MainForm
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

        }
     
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileAs = new System.Windows.Forms.ToolStripMenuItem();
            this.RgbMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvolutionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DistributionMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AffineTransformationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.RotationMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ScalingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.MorphologyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolBarMenu = new System.Windows.Forms.ToolStrip();
            this.UndoBtn = new System.Windows.Forms.ToolStripButton();
            this.RedoBtn = new System.Windows.Forms.ToolStripButton();
            this.SetSourceBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PathToImage = new System.Windows.Forms.ToolStripLabel();
            this.SelectionBtn = new System.Windows.Forms.ToolStripButton();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SrcRotation = new ImageProcessing.App.UILayer.FormControl.TrackBar.RotationTrackBar();
            this.SrcZoom = new ImageProcessing.App.UILayer.Control.ScaleTrackBar();
            this.MainContainer = new MetroFramework.Controls.MetroPanel();
            this.Src = new ImageProcessing.App.UILayer.Controls.BitmapWithRulerControl();
            this.Tabs = new MetroFramework.Controls.MetroTabControl();
            this.MainMenu.SuspendLayout();
            this.ToolBarMenu.SuspendLayout();
            this.MainContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.RgbMenu,
            this.ConvolutionMenu,
            this.DistributionMenu,
            this.AffineTransformationMenu,
            this.RotationMenu,
            this.ScalingMenu,
            this.MorphologyMenu,
            this.SettingsMenu});
            this.MainMenu.Location = new System.Drawing.Point(20, 60);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.MainMenu.Size = new System.Drawing.Size(715, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenFile,
            this.SaveFile,
            this.SaveFileAs});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // OpenFile
            // 
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.OpenFile.Size = new System.Drawing.Size(186, 22);
            this.OpenFile.Text = "Open";
            // 
            // SaveFile
            // 
            this.SaveFile.Name = "SaveFile";
            this.SaveFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveFile.Size = new System.Drawing.Size(186, 22);
            this.SaveFile.Text = "Save";
            // 
            // SaveFileAs
            // 
            this.SaveFileAs.Name = "SaveFileAs";
            this.SaveFileAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveFileAs.Size = new System.Drawing.Size(186, 22);
            this.SaveFileAs.Text = "Save As";
            // 
            // RgbMenu
            // 
            this.RgbMenu.Name = "RgbMenu";
            this.RgbMenu.ShortcutKeyDisplayString = "R";
            this.RgbMenu.Size = new System.Drawing.Size(40, 20);
            this.RgbMenu.Text = "Rgb";
            // 
            // ConvolutionMenu
            // 
            this.ConvolutionMenu.Name = "ConvolutionMenu";
            this.ConvolutionMenu.Size = new System.Drawing.Size(85, 20);
            this.ConvolutionMenu.Text = "Convolution";
            // 
            // DistributionMenu
            // 
            this.DistributionMenu.Name = "DistributionMenu";
            this.DistributionMenu.Size = new System.Drawing.Size(81, 20);
            this.DistributionMenu.Text = "Distribution";
            // 
            // AffineTransformationMenu
            // 
            this.AffineTransformationMenu.Name = "AffineTransformationMenu";
            this.AffineTransformationMenu.Size = new System.Drawing.Size(134, 20);
            this.AffineTransformationMenu.Text = "Affine Transformation";
            // 
            // RotationMenu
            // 
            this.RotationMenu.Name = "RotationMenu";
            this.RotationMenu.Size = new System.Drawing.Size(64, 20);
            this.RotationMenu.Text = "Rotation";
            // 
            // ScalingMenu
            // 
            this.ScalingMenu.Name = "ScalingMenu";
            this.ScalingMenu.Size = new System.Drawing.Size(57, 20);
            this.ScalingMenu.Text = "Scaling";
            // 
            // MorphologyMenu
            // 
            this.MorphologyMenu.Name = "MorphologyMenu";
            this.MorphologyMenu.Size = new System.Drawing.Size(85, 20);
            this.MorphologyMenu.Text = "Morphology";
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.Name = "SettingsMenu";
            this.SettingsMenu.Size = new System.Drawing.Size(61, 20);
            this.SettingsMenu.Text = "Settings";
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.miniToolStrip.Location = new System.Drawing.Point(236, 3);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(662, 25);
            this.miniToolStrip.Stretch = true;
            this.miniToolStrip.TabIndex = 1;
            // 
            // ToolBarMenu
            // 
            this.ToolBarMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ToolBarMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UndoBtn,
            this.RedoBtn,
            this.SetSourceBtn,
            this.toolStripSeparator1,
            this.PathToImage,
            this.SelectionBtn});
            this.ToolBarMenu.Location = new System.Drawing.Point(20, 84);
            this.ToolBarMenu.Name = "ToolBarMenu";
            this.ToolBarMenu.Size = new System.Drawing.Size(715, 27);
            this.ToolBarMenu.Stretch = true;
            this.ToolBarMenu.TabIndex = 5;
            // 
            // UndoBtn
            // 
            this.UndoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.UndoBtn.Enabled = false;
            this.UndoBtn.Image = ((System.Drawing.Image)(resources.GetObject("UndoBtn.Image")));
            this.UndoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(24, 24);
            this.UndoBtn.ToolTipText = "Undo last transformation";
            // 
            // RedoBtn
            // 
            this.RedoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoBtn.Enabled = false;
            this.RedoBtn.Image = ((System.Drawing.Image)(resources.GetObject("RedoBtn.Image")));
            this.RedoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoBtn.Name = "RedoBtn";
            this.RedoBtn.Size = new System.Drawing.Size(24, 24);
            this.RedoBtn.ToolTipText = "Redo last transformation";
            // 
            // SetSourceBtn
            // 
            this.SetSourceBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SetSourceBtn.Enabled = false;
            this.SetSourceBtn.Image = global::ImageProcessing.App.UILayer.Properties.Resources.ReplaceSource_Image;
            this.SetSourceBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SetSourceBtn.Name = "SetSourceBtn";
            this.SetSourceBtn.Size = new System.Drawing.Size(24, 24);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // PathToImage
            // 
            this.PathToImage.Name = "PathToImage";
            this.PathToImage.Size = new System.Drawing.Size(0, 24);
            this.PathToImage.Visible = false;
            // 
            // SelectionBtn
            // 
            this.SelectionBtn.CheckOnClick = true;
            this.SelectionBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SelectionBtn.Image = ((System.Drawing.Image)(resources.GetObject("SelectionBtn.Image")));
            this.SelectionBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SelectionBtn.Name = "SelectionBtn";
            this.SelectionBtn.Size = new System.Drawing.Size(24, 24);
            // 
            // SrcRotation
            // 
            this.SrcRotation.BackColor = System.Drawing.Color.Transparent;
            this.SrcRotation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SrcRotation.Enabled = false;
            this.SrcRotation.Location = new System.Drawing.Point(0, 367);
            this.SrcRotation.Maximum = 360;
            this.SrcRotation.Minimum = -360;
            this.SrcRotation.Name = "SrcRotation";
            this.SrcRotation.Size = new System.Drawing.Size(715, 34);
            this.SrcRotation.TabIndex = 1;
            this.SrcRotation.TrackBarValue = 0;
            this.SrcRotation.Value = 0;
            // 
            // SrcZoom
            // 
            this.SrcZoom.BackColor = System.Drawing.Color.Transparent;
            this.SrcZoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SrcZoom.Enabled = false;
            this.SrcZoom.Location = new System.Drawing.Point(0, 401);
            this.SrcZoom.Maximum = 200;
            this.SrcZoom.Minimum = -200;
            this.SrcZoom.Name = "SrcZoom";
            this.SrcZoom.Size = new System.Drawing.Size(715, 31);
            this.SrcZoom.TabIndex = 0;
            this.SrcZoom.Tag = "Source";
            this.SrcZoom.TrackBarValue = 0;
            this.SrcZoom.Value = 0;
            // 
            // MainContainer
            // 
            this.MainContainer.Controls.Add(this.Src);
            this.MainContainer.Controls.Add(this.SrcRotation);
            this.MainContainer.Controls.Add(this.SrcZoom);
            this.MainContainer.Controls.Add(this.Tabs);
            this.MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContainer.HorizontalScrollbarBarColor = true;
            this.MainContainer.HorizontalScrollbarHighlightOnWheel = false;
            this.MainContainer.HorizontalScrollbarSize = 10;
            this.MainContainer.Location = new System.Drawing.Point(20, 111);
            this.MainContainer.Name = "MainContainer";
            this.MainContainer.Size = new System.Drawing.Size(715, 678);
            this.MainContainer.TabIndex = 16;
            this.MainContainer.VerticalScrollbarBarColor = true;
            this.MainContainer.VerticalScrollbarHighlightOnWheel = false;
            this.MainContainer.VerticalScrollbarSize = 10;
            // 
            // Src
            // 
            this.Src.AutoScroll = true;
            this.Src.AutoSize = true;
            this.Src.Cursor = System.Windows.Forms.Cursors.Default;
            this.Src.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Src.Location = new System.Drawing.Point(0, 0);
            this.Src.Name = "Src";
            this.Src.Padding = new System.Windows.Forms.Padding(40);
            this.Src.Size = new System.Drawing.Size(715, 367);
            this.Src.TabIndex = 2;
            this.Src.UseSelectable = true;
            // 
            // Tabs
            // 
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Tabs.Location = new System.Drawing.Point(0, 432);
            this.Tabs.Name = "Tabs";
            this.Tabs.Size = new System.Drawing.Size(715, 246);
            this.Tabs.TabIndex = 14;
            this.Tabs.UseSelectable = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(755, 809);
            this.Controls.Add(this.MainContainer);
            this.Controls.Add(this.ToolBarMenu);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Image Processing";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ToolBarMenu.ResumeLayout(false);
            this.ToolBarMenu.PerformLayout();
            this.MainContainer.ResumeLayout(false);
            this.MainContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenFile;
        private System.Windows.Forms.ToolStripMenuItem SaveFileAs;
        private System.Windows.Forms.ToolStripMenuItem DistributionMenu;
        private System.Windows.Forms.ToolStripMenuItem ConvolutionMenu;
        private System.Windows.Forms.ToolStrip miniToolStrip;
        private System.Windows.Forms.ToolStrip ToolBarMenu;
        private System.Windows.Forms.ToolStripButton UndoBtn;
        private System.Windows.Forms.ToolStripLabel PathToImage;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private ToolTip ErrorToolTip;
        private ToolStripButton RedoBtn;
        private ToolStripMenuItem RgbMenu;
        private ToolStripMenuItem SettingsMenu;
        private ToolStripMenuItem AffineTransformationMenu;
        private ToolStripMenuItem RotationMenu;
        private ToolStripMenuItem ScalingMenu;
        private ToolStripMenuItem MorphologyMenu;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton SelectionBtn;
        private FormControl.TrackBar.RotationTrackBar SrcRotation;
        private Control.ScaleTrackBar SrcZoom;
        private MetroFramework.Controls.MetroPanel MainContainer;
        private MetroFramework.Controls.MetroTabControl Tabs;
        private Controls.BitmapWithRulerControl Src;
        private ToolStripButton SetSourceBtn;
    }
}

