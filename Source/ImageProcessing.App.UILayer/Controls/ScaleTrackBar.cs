using System;
using System.ComponentModel;
using System.Windows.Forms;

using MetroFramework.Controls;

namespace ImageProcessing.App.UILayer.Controls
{
    public class ScaleTrackBar : MetroTrackBar
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public double Factor
           => 2 * Convert.ToDouble(Value)  /
              Convert.ToDouble(Maximum - Minimum);

        public int TrackBarValue { 
            get => base.Value;
            set => base.Value = value;
        }

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
