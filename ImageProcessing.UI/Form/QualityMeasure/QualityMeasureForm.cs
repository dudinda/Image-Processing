using ImageProcessing.Presentation.Views.QualityMeasure;
using ImageProcessing.Utility.BitmapStack;

using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessing
{
    public partial class QualityMeasureForm : MetroForm, IQualityMeasureView
    {
        private readonly ApplicationContext _context;

        public QualityMeasureForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            SetHistogram();
        
        }

        public Chart GetChart { get { return Histogram; } }
        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }


        public event Action<Bitmap> BuildHistogram;

        private void SetHistogram()
        {
            Histogram.Series.Clear();
            Histogram.ChartAreas[0].AxisX.Interval = 1;
            Histogram.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Histogram.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
        }

    }
}

