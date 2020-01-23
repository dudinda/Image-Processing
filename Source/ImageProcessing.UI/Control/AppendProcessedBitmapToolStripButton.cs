using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageProcessing.UI.Control
{
    public class AppendProcessedBitmapToolStripButton : ToolStripButton
    {
        private readonly Queue<Bitmap> _queue = new Queue<Bitmap>();

        public bool IsQueued(Bitmap bitmap)
            => _queue.Any(bmp => bmp.Tag.Equals(bitmap.Tag));

        public bool Add(Bitmap bitmap)
        {
            if(!IsQueued(bitmap))
            {
                _queue.Enqueue(bitmap);
                return true;
            }


            return false;
        }

        public void Reset()
        {
            _queue.Clear();
        }
        

    }
}
