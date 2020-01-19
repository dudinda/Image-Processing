using System;
using System.Drawing;
using System.Windows.Forms;

using MetroFramework.Controls;

namespace ImageProcessing.UI.Control
{
    public class ZoomTrackBar : MetroTrackBar
    {
        public Size OriginalSize { get; set; }

        public double Factor
            => Convert.ToDouble(base.Value) /
               Convert.ToDouble(base.Maximum - base.Minimum);  

        public int TrackBarValue { 
            get => base.Value;
            set => base.Value = value;
        }
      
        public Size FactorSize
        {
            get
            {
                var scale = Factor;

                return new Size(OriginalSize.Width  + Convert.ToInt32(OriginalSize.Width * scale), 
                                OriginalSize.Height + Convert.ToInt32(OriginalSize.Height * scale) );
            }
        }

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
