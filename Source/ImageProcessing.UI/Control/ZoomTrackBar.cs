using System;
using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.Common.Extensions.BitmapExtensions;

using MetroFramework.Controls;

namespace ImageProcessing.UI.Control
{
    public class ZoomTrackBar : MetroTrackBar
    {
        private Image _image;

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

        public Image ImageToZoom {
            get 
            {
                return _image;
            } 
            set
            {
                _image = value;
                _originalSize = _image.Size;
            }
        }
 
        public int TrackBarValue { 
            get => base.Value;
            set => base.Value = value;
        }

        public Image Zoom()
            => ImageToZoom.ResizeImage(_factorSize);
        
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                base.Value = base.Value + 10 > Maximum ?
                       Maximum : base.Value + 10;
            }

            if(e.Delta < 0)
            {
                base.Value = base.Value - 10 < Minimum ?
                       Minimum : base.Value - 10;
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
                    base.Value  = base.Value + 50 > Maximum ?
                        Maximum : base.Value + 50;
                    e.IsInputKey = true;
                    break;
                case Keys.Subtract:
                    base.Value  = base.Value - 50 < Minimum ?
                        Minimum : base.Value - 50;
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
