using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Presentation.Presenters.Main
{
    partial class MainPresenter
    {
        private void Bind()
        {
            View.BuildPmf += (modifier) 
                => BuildPMF(modifier);

            View.BuildCdf += (modifier) 
                => BuildCDF(modifier);

            View.ApplyConvolutionFilter += (filter) 
                => ApplyConvolutionFilter(filter);

            View.ApplyRGBFilter += (filter) 
                => ApplyRGBFilter(filter);

            View.ApplyRGBColorFilter += (filter) 
                => ApplyColorFilter(filter);

            View.ApplyHistogramTransformation += (distribution, parms)
                => ApplyHistogramTransformation(distribution, parms);

            View.SaveImage += ()
                => SaveImage();

            View.SaveImageAs += () 
                => SaveImageAs();

            View.OpenImage += () 
                => OpenImage();

            View.Shuffle += () 
                => Shuffle();

        }
    }
}
