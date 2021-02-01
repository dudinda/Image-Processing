using System.Windows.Forms;

namespace ImageProcessing.App.UILayer.Forms.Main
{
    partial class MainForm
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
            this.SettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.miniToolStrip = new System.Windows.Forms.ToolStrip();
            this.ToolBarMenu = new System.Windows.Forms.ToolStrip();
            this.UndoBtn = new System.Windows.Forms.ToolStripButton();
            this.RedoBtn = new System.Windows.Forms.ToolStripButton();
            this.ReplaceSrcByDst = new System.Windows.Forms.ToolStripButton();
            this.ReplaceDstBySrc = new System.Windows.Forms.ToolStripButton();
            this.PathToImage = new System.Windows.Forms.ToolStripLabel();
            this.PictureBoxSrcPanel = new System.Windows.Forms.Panel();
            this.Src = new System.Windows.Forms.PictureBox();
            this.TrackBarSrcPanel = new System.Windows.Forms.Panel();
            this.SrcZoom = new ImageProcessing.App.UILayer.Control.ScaleTrackBar();
            this.SrcRotation = new ImageProcessing.App.UILayer.FormControl.TrackBar.RotationTrackBar();
            this.PictureBoxDstPanel = new System.Windows.Forms.Panel();
            this.Dst = new System.Windows.Forms.PictureBox();
            this.TrackBarDstPanel = new System.Windows.Forms.Panel();
            this.DstZoom = new ImageProcessing.App.UILayer.Control.ScaleTrackBar();
            this.DstRotation = new ImageProcessing.App.UILayer.FormControl.TrackBar.RotationTrackBar();
            this.ErrorToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SplitContainer = new ImageProcessing.App.UILayer.Control.UndoRedoSplitContainer();
            this.MainMenu.SuspendLayout();
            this.ToolBarMenu.SuspendLayout();
            this.PictureBoxSrcPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).BeginInit();
            this.TrackBarSrcPanel.SuspendLayout();
            this.PictureBoxDstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).BeginInit();
            this.TrackBarDstPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
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
            this.ReplaceSrcByDst,
            this.ReplaceDstBySrc,
            this.PathToImage});
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
            this.UndoBtn.Image = global::ImageProcessing.App.UILayer.Properties.Resources.Undo_Image;
            this.UndoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UndoBtn.Name = "UndoBtn";
            this.UndoBtn.Size = new System.Drawing.Size(24, 24);
            this.UndoBtn.ToolTipText = "Undo last transformation";
            // 
            // RedoBtn
            // 
            this.RedoBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoBtn.Enabled = false;
            this.RedoBtn.Image = global::ImageProcessing.App.UILayer.Properties.Resources.Redo_Image;
            this.RedoBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoBtn.Name = "RedoBtn";
            this.RedoBtn.Size = new System.Drawing.Size(24, 24);
            this.RedoBtn.ToolTipText = "Redo last transformation";
            // 
            // ReplaceSrcByDst
            // 
            this.ReplaceSrcByDst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReplaceSrcByDst.Image = ((System.Drawing.Image)(resources.GetObject("ReplaceSrcByDst.Image")));
            this.ReplaceSrcByDst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReplaceSrcByDst.Name = "ReplaceSrcByDst";
            this.ReplaceSrcByDst.Size = new System.Drawing.Size(24, 24);
            this.ReplaceSrcByDst.Tag = "Destination";
            this.ReplaceSrcByDst.ToolTipText = "Replace source by destination";
            // 
            // ReplaceDstBySrc
            // 
            this.ReplaceDstBySrc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReplaceDstBySrc.Image = ((System.Drawing.Image)(resources.GetObject("ReplaceDstBySrc.Image")));
            this.ReplaceDstBySrc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReplaceDstBySrc.Name = "ReplaceDstBySrc";
            this.ReplaceDstBySrc.Size = new System.Drawing.Size(24, 24);
            this.ReplaceDstBySrc.Tag = "Source";
            this.ReplaceDstBySrc.ToolTipText = "Replace destination by source";
            // 
            // PathToImage
            // 
            this.PathToImage.Name = "PathToImage";
            this.PathToImage.Size = new System.Drawing.Size(0, 24);
            this.PathToImage.Visible = false;
            // 
            // PictureBoxSrcPanel
            // 
            this.PictureBoxSrcPanel.AutoScroll = true;
            this.PictureBoxSrcPanel.Controls.Add(this.Src);
            this.PictureBoxSrcPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxSrcPanel.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxSrcPanel.Name = "PictureBoxSrcPanel";
            this.PictureBoxSrcPanel.Size = new System.Drawing.Size(359, 299);
            this.PictureBoxSrcPanel.TabIndex = 4;
            // 
            // Src
            // 
            this.Src.Cursor = System.Windows.Forms.Cursors.Default;
            this.Src.InitialImage = global::ImageProcessing.App.UILayer.Properties.Resources.DefaultImage;
            this.Src.Location = new System.Drawing.Point(3, 3);
            this.Src.Name = "Src";
            this.Src.Size = new System.Drawing.Size(64, 64);
            this.Src.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Src.TabIndex = 2;
            this.Src.TabStop = false;
            this.Src.Tag = "Source";
            // 
            // TrackBarSrcPanel
            // 
            this.TrackBarSrcPanel.Controls.Add(this.SrcZoom);
            this.TrackBarSrcPanel.Controls.Add(this.SrcRotation);
            this.TrackBarSrcPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TrackBarSrcPanel.Location = new System.Drawing.Point(0, 299);
            this.TrackBarSrcPanel.Name = "TrackBarSrcPanel";
            this.TrackBarSrcPanel.Size = new System.Drawing.Size(359, 61);
            this.TrackBarSrcPanel.TabIndex = 3;
            // 
            // SrcZoom
            // 
            this.SrcZoom.BackColor = System.Drawing.Color.Transparent;
            this.SrcZoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.SrcZoom.Enabled = false;
            this.SrcZoom.Location = new System.Drawing.Point(0, 0);
            this.SrcZoom.Maximum = 200;
            this.SrcZoom.Minimum = -200;
            this.SrcZoom.Name = "SrcZoom";
            this.SrcZoom.Size = new System.Drawing.Size(359, 31);
            this.SrcZoom.TabIndex = 0;
            this.SrcZoom.Tag = "Source";
            this.SrcZoom.TrackBarValue = 0;
            this.SrcZoom.Value = 0;
            // 
            // SrcRotation
            // 
            this.SrcRotation.BackColor = System.Drawing.Color.Transparent;
            this.SrcRotation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SrcRotation.Enabled = false;
            this.SrcRotation.Location = new System.Drawing.Point(0, 27);
            this.SrcRotation.Maximum = 360;
            this.SrcRotation.Minimum = -360;
            this.SrcRotation.Name = "SrcRotation";
            this.SrcRotation.Size = new System.Drawing.Size(359, 34);
            this.SrcRotation.TabIndex = 1;
            this.SrcRotation.TrackBarValue = 0;
            this.SrcRotation.Value = 0;
            // 
            // PictureBoxDstPanel
            // 
            this.PictureBoxDstPanel.AutoScroll = true;
            this.PictureBoxDstPanel.Controls.Add(this.Dst);
            this.PictureBoxDstPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBoxDstPanel.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxDstPanel.Name = "PictureBoxDstPanel";
            this.PictureBoxDstPanel.Size = new System.Drawing.Size(352, 299);
            this.PictureBoxDstPanel.TabIndex = 5;
            // 
            // Dst
            // 
            this.Dst.Cursor = System.Windows.Forms.Cursors.Default;
            this.Dst.InitialImage = global::ImageProcessing.App.UILayer.Properties.Resources.DefaultImage;
            this.Dst.Location = new System.Drawing.Point(3, 3);
            this.Dst.Name = "Dst";
            this.Dst.Size = new System.Drawing.Size(64, 64);
            this.Dst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Dst.TabIndex = 3;
            this.Dst.TabStop = false;
            this.Dst.Tag = "Destination";
            // 
            // TrackBarDstPanel
            // 
            this.TrackBarDstPanel.Controls.Add(this.DstZoom);
            this.TrackBarDstPanel.Controls.Add(this.DstRotation);
            this.TrackBarDstPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TrackBarDstPanel.Location = new System.Drawing.Point(0, 299);
            this.TrackBarDstPanel.Name = "TrackBarDstPanel";
            this.TrackBarDstPanel.Size = new System.Drawing.Size(352, 61);
            this.TrackBarDstPanel.TabIndex = 4;
            // 
            // DstZoom
            // 
            this.DstZoom.BackColor = System.Drawing.Color.Transparent;
            this.DstZoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.DstZoom.Enabled = false;
            this.DstZoom.Location = new System.Drawing.Point(0, 0);
            this.DstZoom.Maximum = 200;
            this.DstZoom.Minimum = -200;
            this.DstZoom.Name = "DstZoom";
            this.DstZoom.Size = new System.Drawing.Size(352, 31);
            this.DstZoom.TabIndex = 0;
            this.DstZoom.Tag = "Destination";
            this.DstZoom.TrackBarValue = 0;
            this.DstZoom.Value = 0;
            // 
            // DstRotation
            // 
            this.DstRotation.BackColor = System.Drawing.Color.Transparent;
            this.DstRotation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DstRotation.Enabled = false;
            this.DstRotation.Location = new System.Drawing.Point(0, 27);
            this.DstRotation.Maximum = 360;
            this.DstRotation.Minimum = -360;
            this.DstRotation.Name = "DstRotation";
            this.DstRotation.Size = new System.Drawing.Size(352, 34);
            this.DstRotation.TabIndex = 11;
            this.DstRotation.TrackBarValue = 0;
            this.DstRotation.Value = 0;
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(20, 111);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.PictureBoxSrcPanel);
            this.SplitContainer.Panel1.Controls.Add(this.TrackBarSrcPanel);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.PictureBoxDstPanel);
            this.SplitContainer.Panel2.Controls.Add(this.TrackBarDstPanel);
            this.SplitContainer.Size = new System.Drawing.Size(715, 360);
            this.SplitContainer.SplitterDistance = 359;
            this.SplitContainer.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 491);
            this.Controls.Add(this.SplitContainer);
            this.Controls.Add(this.ToolBarMenu);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "Image Processing";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ToolBarMenu.ResumeLayout(false);
            this.ToolBarMenu.PerformLayout();
            this.PictureBoxSrcPanel.ResumeLayout(false);
            this.PictureBoxSrcPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Src)).EndInit();
            this.TrackBarSrcPanel.ResumeLayout(false);
            this.PictureBoxDstPanel.ResumeLayout(false);
            this.PictureBoxDstPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dst)).EndInit();
            this.TrackBarDstPanel.ResumeLayout(false);
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
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
        private System.Windows.Forms.PictureBox Src;
        private System.Windows.Forms.PictureBox Dst;
        private System.Windows.Forms.ToolStripButton ReplaceSrcByDst;
        private System.Windows.Forms.ToolStripButton UndoBtn;
        private System.Windows.Forms.ToolStripLabel PathToImage;
        private System.Windows.Forms.ToolStripButton ReplaceDstBySrc;
        private System.Windows.Forms.ToolStripMenuItem SaveFile;
        private ToolTip ErrorToolTip;
        private Panel PictureBoxSrcPanel;
        private Panel TrackBarSrcPanel;
        private Panel PictureBoxDstPanel;
        private Panel TrackBarDstPanel;
        private App.UILayer.Control.ScaleTrackBar SrcZoom;
        private App.UILayer.Control.UndoRedoSplitContainer SplitContainer;
        private ToolStripButton RedoBtn;
        private App.UILayer.Control.ScaleTrackBar DstZoom;
        private ToolStripMenuItem RgbMenu;
        private ToolStripMenuItem SettingsMenu;
        private ToolStripMenuItem AffineTransformationMenu;
        private FormControl.TrackBar.RotationTrackBar SrcRotation;
        private FormControl.TrackBar.RotationTrackBar DstRotation;
    }
}

