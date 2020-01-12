using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.Utility.BitmapStack;

using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing.Form.QualityMeasure
{
    public partial class QualityMeasureForm : MetroForm, IQualityMeasureView
    {
        public QualityMeasureForm()
        {
            InitializeComponent();
            SetHistogram();     
        }

        public Chart GetChart => Histogram;

        public new void Show()
        {
            ShowDialog();
        }

        private void SetHistogram()
        {
            Histogram.Series.Clear();
            Histogram.ChartAreas[0].AxisX.Interval = 1;
            Histogram.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Histogram.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
        }

    }
}

