namespace ImageProcessing.App.UILayer.Form.Histogram
{
    partial class HistogramForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
            => Dispose();
       
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Freq = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Freq)).BeginInit();
            this.SuspendLayout();
            // 
            // Freq
            // 
            chartArea1.AxisX.Interval = 50D;
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "PlotArea";
            this.Freq.ChartAreas.Add(chartArea1);
            this.Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "SeriesLegend";
            this.Freq.Legends.Add(legend1);
            this.Freq.Location = new System.Drawing.Point(20, 60);
            this.Freq.Name = "Freq";
            this.Freq.Size = new System.Drawing.Size(535, 417);
            this.Freq.TabIndex = 0;
            this.Freq.Text = "chart1";
            // 
            // HistogramForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 497);
            this.Controls.Add(this.Freq);
            this.Name = "HistogramForm";
            this.Text = "Histogram";
            ((System.ComponentModel.ISupportInitialize)(this.Freq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Freq;
    }
}
