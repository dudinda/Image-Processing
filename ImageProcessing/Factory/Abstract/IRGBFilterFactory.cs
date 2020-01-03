using ImageProcessing.RGBFilter.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageProcessing.Factory.Abstract
{
    public interface IRGBFilterFactory
    {
        IRGBFilter GetFilter();
    }
}
