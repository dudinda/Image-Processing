using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.CommonLayer.Extensions.BitmapExt;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Control
{
    public class ZoomTrackBar : MetroTrackBar
    {
        private Image _image;

        private readonly object _sync = new object();

        private double _factor
           => Convert.ToDouble(base.Value) /
              Convert.ToDouble(base.Maximum - base.Minimum);

        private Size _originalSize;

        private Size _factorSize
        {
            get
            {
                var scale = _factor;

                return new Size(_originalSize.Width + Convert.ToInt32(_originalSize.Width * scale),
                                _originalSize.Height + Convert.ToInt32(_originalSize.Height * scale));
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Image ImageToZoom {
            get 
            {
                lock (_sync)
                {
                    return _image;
                }
            } 
            set
            {
                lock (_sync)
                {
                    _image = value;
                    _originalSize = _image.Size;
                }
            }
        }
 
        public int TrackBarValue { 
            get => base.Value;
            set => base.Value = value;
        }

        public Image Zoom()
            => ImageToZoom.ResizeImage(_factorSize);

        protected override void OnMouseEnter(EventArgs e)
            => Focus();

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                base.Value = Math.Min(base.Value + 25, Maximum);
            }

            if(e.Delta < 0)
            {
                base.Value = Math.Max(base.Value - 25, Minimum);
            }

            base.OnMouseWheel(e);
        }

        /// <summary>
        /// OnPreviewKeyDown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Add:
                    base.Value = Math.Min(base.Value + 50, Maximum);
                    e.IsInputKey = true;
                    break;
                case Keys.Subtract:
                    base.Value = Math.Max(base.Value - 50, Minimum);
                    e.IsInputKey = true;
                    break;
            }
        }

        /// <summary>
        /// onKeyDown
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.RButton:
                    e.Handled = true;
                    break;
            }
        }

        /// <summary>
        /// onKeyUp
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.Left:
                    e.Handled = true;
                    break;
            }
        }
    }
}
