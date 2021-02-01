namespace ImageProcessing.App.UILayer.Forms.QualityMeasure
{
    partial class QualityMeasureForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Histogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Histogram)).BeginInit();
            this.SuspendLayout();
            // 
            // Histogram
            // 
            chartArea2.AxisX.Interval = 1D;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Angle = 90;
            chartArea2.Name = "ChartArea1";
            this.Histogram.ChartAreas.Add(chartArea2);
            this.Histogram.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.Histogram.Legends.Add(legend2);
            this.Histogram.Location = new System.Drawing.Point(20, 60);
            this.Histogram.Name = "Histogram";
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "p(x)";
            this.Histogram.Series.Add(series2);
            this.Histogram.Size = new System.Drawing.Size(491, 387);
            this.Histogram.TabIndex = 1;
            // 
            // QualityMeasureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 467);
            this.Controls.Add(this.Histogram);
            this.Name = "QualityMeasureForm";
            this.Text = "Grayscale Levels";
            ((System.ComponentModel.ISupportInitialize)(this.Histogram)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart Histogram;
    }
}
