using System;
using System.Drawing;

using MetroFramework.Controls;

namespace ImageProcessing.UI.Control
{
    public class ZoomTrackBar : MetroTrackBar
    {
        public Size OriginalSize { get; set; }

        public double Factor
            => Convert.ToDouble(base.Value) / Convert.ToDouble(base.Maximum - base.Minimum);  
        
        public Size FactorSize
        {
            get
            {
                var scale = Factor;

                return new Size(OriginalSize.Width - Convert.ToInt32(OriginalSize.Width * scale), 
                                OriginalSize.Height- Convert.ToInt32(OriginalSize.Height * scale) );
            }
        } 
    }
}
