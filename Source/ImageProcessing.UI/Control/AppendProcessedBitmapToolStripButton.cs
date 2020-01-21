using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageProcessing.UI.Control
{
    public class AppendProcessedBitmapToolStripButton : ToolStripButton
    {
        public Queue<Bitmap> Queue { get; } = new Queue<Bitmap>();

        public bool IsQueued(Bitmap bitmap)
            => Queue.Any(bmp => bmp.Tag.Equals(bitmap.Tag));

        public bool Add(Bitmap bitmap)
        {
            if(!IsQueued(bitmap))
            {
                Queue.Enqueue(bitmap);
                return true;
            }


            return false;
        }

        public void Reset()
        {
            Queue.Clear();
        }
        

    }
}
