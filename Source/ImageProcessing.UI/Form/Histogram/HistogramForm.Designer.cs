namespace ImageProcessing.Form.Histogram
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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Freq = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Freq)).BeginInit();
            this.SuspendLayout();
            // 
            // Freq
            // 
            chartArea1.AxisX.Interval = 50D;
            chartArea1.AxisX.Maximum = 255D;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.Freq.ChartAreas.Add(chartArea1);
            this.Freq.Dock = System.Windows.Forms.DockStyle.Fill;
            legendItem1.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem1.Name = "E[X]";
            legendItem2.ImageStyle = System.Windows.Forms.DataVisualization.Charting.LegendImageStyle.Line;
            legendItem2.Name = "σ";
            legend1.CustomItems.Add(legendItem1);
            legend1.CustomItems.Add(legendItem2);
            legend1.Name = "Legend1";
            this.Freq.Legends.Add(legend1);
            this.Freq.Location = new System.Drawing.Point(20, 60);
            this.Freq.Name = "Freq";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "p(x)";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.Name = "F(x)";
            this.Freq.Series.Add(series1);
            this.Freq.Series.Add(series2);
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