﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ImageProcessing.UI.Control
{
    public class AppendProcessedBitmapToolStripButton : ToolStripButton
    {
        private readonly Queue<Image> _queue = new Queue<Image>();

        public bool IsQueued(Image bitmap)
            => _queue.Any(bmp => bmp.Tag.Equals(bitmap.Tag));

        public bool Add(Image bitmap)
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