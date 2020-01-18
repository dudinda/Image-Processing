using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Presentation.Presenters.Main
{
    partial class MainPresenter
    {
        private void Bind()
        {
            View.Zoom += (container)
                => Zoom(container);

            View.BuildPMF += (container, function)
                 => BuildFunction(container, function);

            View.BuildCDF += (container, function) 
                => BuildFunction(container, function);

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

            View.ReplaceImage += (image) 
                => Replace(image);

        }
    }
}
