using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

using ImageProcessing.Utility.BitmapStack;
using ImageProcessing.Presentation.Views.Main;

using MetroFramework.Forms;
using ImageProcessing.RGBFilters.ColorFilter.Colors;

namespace ImageProcessing
{
    public partial class MainForm : MetroForm, IMainView
    {
        private readonly ApplicationContext _context;

        public double FirstParameter { get { return Convert.ToDouble(FirstParam.Text); } }
        public double SecondParameter { get { return Convert.ToDouble(SecondParam.Text); } }
        public Bitmap SrcImage { get { return new Bitmap(Src.Image); } set { Src.Image = value; } }
        public Bitmap DstImage { get { return new Bitmap(Dst.Image); } set { Dst.Image = value; } }

        public bool SrcIsNull { get { return Src.Image is null; } }
        public bool DstIsNull { get { return Dst.Image is null; } }

        public string Path { get { return PathToImage.Text; } set { PathToImage.Text = value; } }
        public (double, double) Parameters
        {
            get { return (Convert.ToDouble(FirstParam.Text), Convert.ToDouble(SecondParam.Text));  }
        }

        public event Action SaveImage;
        public event Action OpenImage;
        public event Action<string> ApplyConvolutionFilter;
        public event Action<string, (double, double)> ApplyHistogramTransformation;
        public event Action<string> ApplyRGBFilter;
        public event Action<RGBColor> ApplyRGBColorFilter;
        public event Action Shuffle;
        public event Action BuildPmf;
        public event Action BuildCdf;
        public event Action BuildLuminanceIntervals;
     
        public MainForm(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();

            Src.SizeMode = PictureBoxSizeMode.AutoSize;
            Dst.SizeMode = PictureBoxSizeMode.AutoSize;

            splitContainer1.BringToFront();
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        private void InvokeWithTwoParameters<T1, T2>(Action<T1, T2> action, T1 first, T2 second)
        => action?.Invoke(first, second);
        private void InvokeWithParameter<T>(Action<T> action, T parameter)
        => action?.Invoke(parameter);
        private void Invoke(Action action)
         => action?.Invoke();

        public void InitSrcImageZoom()
        {
            throw new NotImplementedException();
        }

        public void InitDstImageZoom()
        {
            throw new NotImplementedException();
        }




        /*
      
        private async void UniformDistributionClick(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam() || CheckSecondParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {

                var a = Convert.ToDouble(FirstParam.Text);
                var b = Convert.ToDouble(SecondParam.Text);

                return new Bitmap(srcImage).Distribute(new UniformDistribution(a, b));

            });

            InitDstFactor();

            dstImage = new Bitmap(Dst.Image);
            dstImage.Tag = "Uniform";

        }

        private async void CauchyDistributionClick(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam() || CheckSecondParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var x0 = Convert.ToDouble(FirstParam.Text);
                var gamma = Convert.ToDouble(SecondParam.Text);

                return new Bitmap(srcImage).Distribute(new CauchyDistribution(x0, gamma));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
        }

        private async void NormalDistributionClick(object sender, EventArgs e)
        {

            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam() || CheckSecondParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var mu = Convert.ToDouble(FirstParam.Text);
                var sigma = Convert.ToDouble(SecondParam.Text);

                return new Bitmap(srcImage).Distribute(new NormalDistribution(mu, sigma));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
            dstImage.Tag = "Normal";
        }

        private async void RayleighDistributionClick(object sender, EventArgs e)
        {

            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var sigma = Convert.ToDouble(FirstParam.Text);

                return new Bitmap(srcImage).Distribute(new RayleighDistribution(sigma));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
            dstImage.Tag = "Rayleigh";
        }



        private async void ExponentialDistributionClick(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var lambda = Convert.ToDouble(FirstParam.Text);

                return new Bitmap(srcImage).Distribute(new ExponentialDistribution(lambda));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
            dstImage.Tag = "Exponential";
        }

        private async void WeibullDistributionClick(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam() || CheckSecondParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var lambda = Convert.ToDouble(FirstParam.Text);
                var k = Convert.ToDouble(SecondParam.Text);

                return new Bitmap(srcImage).Distribute(new WeibullDistribution(lambda, k));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
        }



        private async void LaplacianDistributionClick(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam() || CheckSecondParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var mu = Convert.ToDouble(FirstParam.Text);
                var b = Convert.ToDouble(SecondParam.Text);

                return new Bitmap(srcImage).Distribute(new LaplaceDistribution(mu, b));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
        }

        private async void ParabolaDistributionClick(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (CheckFirstParam())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                var k = Convert.ToDouble(FirstParam.Text);

                return new Bitmap(srcImage).Distribute(new ParabolaDistribution(k));
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);

        }

        private async void SobelOperatorHorizontalClick(object sender, EventArgs e)
        {

            if (CheckFirstImage())
            {
                return;
            }

            var yDerivative = await Task.Factory.StartNew(() =>
            {
                return new Bitmap(srcImage).ConvolutionFilter(new SobelOperatorHorizontal());
            });

            var xDerivative = await Task.Factory.StartNew(() =>
            {
                return new Bitmap(srcImage).ConvolutionFilter(new SobelOperatorVertical());
            });


            Dst.Image = await Task.Factory.StartNew(() =>
            {
                return Utility.Utility.Magnitude(xDerivative, yDerivative);
            });

            InitDstFactor();
            dstImage = new Bitmap(Dst.Image);
        }


        private void BuildDstHistogramClick(object sender, EventArgs e)
        {

            if (CheckSecondImage())
            {
                return;
            }

            var histogram = new HistogramForm();
            histogram.Show();
            histogram.BuildHistogram(new Bitmap(dstImage));

        }

        private void BuildSrcHistogramClick(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys == Keys.Shift))
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var histogram = new HistogramForm();
                histogram.Show();
                histogram.BuildHistogram(new Bitmap(srcImage));
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var histogram = new HistogramForm();
                histogram.Show();
                histogram.BuildHistogram(new Bitmap(dstImage));
            }
        }

        private async void ChangeSrcImageClick(object sender, EventArgs e)
        {

            if (CheckFirstImage() || CheckSecondImage())
            {
                return;
            }

            Src.Image = await Task.Factory.StartNew(() =>
            {
                shapes.Push(new Bitmap(srcImage));
                return dstImage;
            });


            InitSrcFactor();

            srcImage = dstImage;

        }

        private async void UndoBtnClick(object sender, EventArgs e)
        {

            if (CheckFirstImage())
            {
                return;
            }

            await Task.Factory.StartNew(() =>
            {
                if (shapes.Any())
                {
                    Src.Image = shapes.Pop();
                }
            });

            InitSrcFactor();
            srcImage = new Bitmap(Src.Image);
        }



        /// <summary>
        /// Проверить, верно ли указано значение первого параметра
        /// </summary>
        /// <returns>true - если не указано, false - если указано</returns>
        private bool CheckFirstParam()
        {
            //если не введен первый параметр
            if (String.IsNullOrWhiteSpace(FirstParam.Text) || FirstParam.Text.Equals("-"))
            {
                return true;
            }

            double result;

            if (!double.TryParse(FirstParam.Text, out result))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Проверить верно ли указано значение второго параметра
        /// </summary>
        /// <returns>true - если не указано, false - если указано</returns>
        private bool CheckSecondParam()
        {
            //если не введен второй параметр
            if (String.IsNullOrWhiteSpace(SecondParam.Text) || SecondParam.Text.Equals("-"))
            {
                return true;
            }

            double result;

            if (!double.TryParse(FirstParam.Text, out result))
            {
                return true;
            }

            return false;
        }

        private void AcceptOnlyDigits(object sender, KeyPressEventArgs e)
        {

            var box = ((ToolStripTextBox)(sender));

            if (!box.Text.Contains("-"))
            {
                if (e.KeyChar == ',' && box.SelectionStart == 0)
                {
                    e.Handled = true;
                    return;
                }
            }
            else
            {
                if (e.KeyChar == ',' && (box.SelectionStart == 0 || box.SelectionStart == 1))
                {
                    e.Handled = true;
                    return;
                }
            }

            //исключить постановку знака отрицания где - либо, кроме начала
            if (e.KeyChar == '-' && box.SelectionStart != 0)
            {
                e.Handled = true;
                return;
            }


            //если уже введена плавающая точка
            if (box.Text.Contains(",") && e.KeyChar == ',')
            {
                e.Handled = true;
                return;
            }


            //исключить введение любых символов, кроме цифр, а также - и ,
            e.Handled = !char.IsDigit(e.KeyChar) &&
                        !char.IsControl(e.KeyChar) &&
                        e.KeyChar != ',' &&
                        e.KeyChar != '-';
        }

        //проверять переполнение при вводе числа
        private void CheckOverflow(object sender, EventArgs e)
        {


            var box = ((ToolStripTextBox)(sender));

            if (String.IsNullOrEmpty(box.Text))
            {
                return;
            }

            try
            {
                Convert.ToInt32(box.Text);
            }
            catch (OverflowException ex)
            {
                box.Text = box.Text.Remove(box.Text.Length - 1, 1);
                box.SelectionStart = box.Text.Length;
            }
            catch(FormatException ex)
            {

            }
        }

        private async void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var ToolTip = new ToolTip();

                var SrcEntropy = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetEntropy(new Bitmap(srcImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                ToolTip.Show(SrcEntropy, this, new Point(rect.Left, rect.Bottom));
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var ToolTip = new ToolTip();

                var SrcEntropy = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetEntropy(new Bitmap(dstImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                ToolTip.Show(SrcEntropy, this, new Point(rect.Left, rect.Bottom));
            }
        }

        private async void toolStripButton7_ClickAsync(object sender, EventArgs e)
        {
            if(CheckFirstImage())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                return new Bitmap(srcImage).Shuffle();
            });

            dstImage = new Bitmap(Dst.Image);
        }

        /// <summary>
        /// Приблизить исходное изображение до 250%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomInSrc(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (srcImageFactor < 0.25 - Double.Epsilon)
            {
                srcImageFactor += 0.1;
            }
            else if(srcImageFactor < 2.5 - Double.Epsilon)
            {
                srcImageFactor += 0.25;
            }

            var newSize = new Size((int)(srcImage.Width * srcImageFactor), (int)(srcImage.Height * srcImageFactor));

            Src.Image = new Bitmap(srcImage, newSize);

            var text = String.Format($"{Convert.ToInt32(srcImageFactor * 100)}%");

            ZoomInSrcBtn.ToolTipText = text;
            ZoomOutSrcBtn.ToolTipText = text;
        }

        /// <summary>
        /// Отдалить исходное изображение до 5%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomOutSrc(object sender, EventArgs e)
        {
            if (CheckFirstImage())
            {
                return;
            }

            if (srcImageFactor > 0.25 + Double.Epsilon)
            {
                srcImageFactor -= 0.25;
            }
            else if (srcImageFactor > 0.05 + Double.Epsilon)
            {
                srcImageFactor -= 0.1;
            }


            var newSize = new Size((int)(srcImage.Width * srcImageFactor), (int)(srcImage.Height * srcImageFactor));

            Src.Image = new Bitmap(srcImage, newSize);

            var text = String.Format($"{Convert.ToInt32(srcImageFactor * 100)}%");

            ZoomInSrcBtn.ToolTipText = text;
            ZoomOutSrcBtn.ToolTipText = text;
        }

        /// <summary>
        /// Приблизить обработанное изображение до 250%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomInDst(object sender, EventArgs e)
        {
            if (CheckSecondImage())
            {
                return;
            }

            if (dstImageFactor < 0.25 - Double.Epsilon)
            {
                dstImageFactor += 0.1;
            }
            else if (dstImageFactor < 2.5 - Double.Epsilon)
            {
                dstImageFactor += 0.25;
            }

            var newSize = new Size((int)(dstImage.Width * dstImageFactor), (int)(dstImage.Height * dstImageFactor));

            Dst.Image = new Bitmap(dstImage, newSize);

            var text = String.Format($"{Convert.ToInt32(dstImageFactor * 100)}%");

            ZoomInDstBtn.ToolTipText = text;
            ZoomOutDstBtn.ToolTipText = text;
        }

        /// <summary>
        /// Отдалить обработанное изображение до 5%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomOutDst(object sender, EventArgs e)
        {
            if (CheckSecondImage())
            {
                return;
            }

            if (dstImageFactor > 0.25 + Double.Epsilon)
            {
                dstImageFactor -= 0.25;
            }
            else if (dstImageFactor > 0.05 + Double.Epsilon)
            {
                dstImageFactor -= 0.1;
            }


            var newSize = new Size((int)(dstImage.Width * dstImageFactor), (int)(dstImage.Height * dstImageFactor));

            Dst.Image = new Bitmap(dstImage, newSize);

            var text = String.Format($"{Convert.ToInt32(dstImageFactor * 100)}%");

            ZoomInDstBtn.ToolTipText = text;
            ZoomOutDstBtn.ToolTipText = text;
        }


        private void InitDstImageZoom()
        {
            dstImageFactor = 1.0;
            ZoomInDstBtn.ToolTipText = "100%";
            ZoomOutDstBtn.ToolTipText = "100%";
        }

        private void InitSrcImageZoom()
        {
            srcImageFactor = 1.0;
            ZoomInSrcBtn.ToolTipText = "100%";
            ZoomOutSrcBtn.ToolTipText = "100%";
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var histogram = new HistogramForm();
                histogram.Show();
                histogram.BuildCDF(new Bitmap(srcImage));
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var histogram = new HistogramForm();
                histogram.Show();
                histogram.BuildCDF(new Bitmap(dstImage));
            }
        }
 

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
         
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var histogram = new QualityMeasureForm(srcImage);
                histogram.Show();
                histogram.BuildHistogram();
            }
            else if(Control.ModifierKeys == Keys.Alt)
            {
                if (view.Any())
                {
                    var histogram = new QualityMeasureForm(view);
                    histogram.Show();
                    histogram.BuildHistogram();
                }
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var histogram = new QualityMeasureForm(dstImage);
                histogram.Show();
                histogram.BuildHistogram();
            }
        }

        private void compare_Click(object sender, EventArgs e)
        {
            view.Push(dstImage);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (CheckFirstImage() || CheckSecondImage())
            {
                return;
            }

            Dst.Image = await Task.Factory.StartNew(() =>
            {
                shapes.Push(new Bitmap(dstImage));
                return dstImage;
            });


            InitDstFactor();

            dstImage = srcImage;
        }

        private async void Expectation_Click(object sender, EventArgs e)
        {

            if (Control.ModifierKeys == Keys.Shift)
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var toolTip = new ToolTip();

                var srcExpectation = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetExpectation(new Bitmap(srcImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                toolTip.Show(srcExpectation, this, new Point(rect.Left, rect.Bottom));
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var ToolTip = new ToolTip();

                var srcExpectation = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetExpectation(new Bitmap(dstImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                ToolTip.Show(srcExpectation, this, new Point(rect.Left, rect.Bottom));
            }
        }

        private async void Variance_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var toolTip = new ToolTip();

                var srcVariance = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetVariance(new Bitmap(srcImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                toolTip.Show(srcVariance, this, new Point(rect.Left, rect.Bottom));
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var ToolTip = new ToolTip();

                var srcVariance = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetVariance(new Bitmap(dstImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                ToolTip.Show(srcVariance, this, new Point(rect.Left, rect.Bottom));
            }
        }

        private async void sderivation_Click(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Shift)
            {

                if (CheckFirstImage())
                {
                    return;
                }

                var toolTip = new ToolTip();

                var srcsderivation = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetStandardDeviation(new Bitmap(srcImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                toolTip.Show(srcsderivation, this, new Point(rect.Left, rect.Bottom));
            }
            else
            {
                if (CheckSecondImage())
                {
                    return;
                }

                var ToolTip = new ToolTip();

                var srcsderivation = await Task.Factory.StartNew(() =>
                {
                    return DistributionContext.GetStandardDeviation(new Bitmap(dstImage)).ToString();
                });

                var rect = toolStripButton5.Bounds;

                ToolTip.Show(srcsderivation, this, new Point(rect.Left, rect.Bottom));
            }
        }*/
    }
}
