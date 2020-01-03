using ImageProcessing.Utility.BitmapStack;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageProcessing
{
    public partial class QualityMeasure : MetroForm
    {
        private List<Bitmap> list = new List<Bitmap>();

        public QualityMeasure(BitmapStack<Bitmap> stack = null)
        {
            InitializeComponent();

            SetHistogram();

            while (stack.Any())
            {
                var bmp = stack.Pop();


                if (Histogram.Series.FindByName(bmp.Tag.ToString()) == null)
                {
                    list.Add(bmp);
                    Histogram.Series.Add(bmp.Tag.ToString());
                }
            }
        }

        public QualityMeasure(Bitmap bmp)
        {
            InitializeComponent();

            SetHistogram();

            if (bmp.Tag == null)
            {
                bmp.Tag = "Source";
            }

            list.Add(bmp);
            Histogram.Series.Add(bmp.Tag.ToString());

        }

        private void SetHistogram()
        {
            Histogram.Series.Clear();
            Histogram.ChartAreas[0].AxisX.Interval = 1;
            Histogram.ChartAreas[0].AxisX.IsLabelAutoFit = false;
            Histogram.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
        }


        public void BuildHistogram()
        {
            this.Text = "Grayscale Levels";

            for (var step = 0; step < list.Count; ++step)
            {

                var bitmap = list[step];
                

                var pmf = DistributionContext.GetPMF(DistributionContext.GetFrequencies(bitmap), bitmap.Width * bitmap.Height);

                var frequencies = DistributionContext.GetFrequencies(bitmap);

                var variance = new List<double>();
                var names = new List<string>();

                for (int graylevel = 0; graylevel < 255; graylevel += 15)
                {
                    names.Add(string.Format($"{graylevel}-{graylevel + 15}"));
                    variance.Add(DistributionContext.GetConditionalVariance(graylevel, graylevel + 15, pmf));
                }
             
      
                Histogram.Series[bitmap.Tag.ToString()].Points.DataBindXY(names, variance);
                Histogram.Series[bitmap.Tag.ToString()].LabelAngle = -90;
            }
        }
    }
}

