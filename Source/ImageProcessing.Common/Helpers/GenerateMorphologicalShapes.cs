using System;
using System.Drawing;

using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Utility.BitMatrix.Implementation;

namespace ImageProcessing.Common.Helpers
{
    public static class GenerateMorphologicalShapes
    {
        public static BitMatrix GetShape(MorphologyShape shape, (int width, int height) kernelSize, Point? anchor = null)
        {
            switch (shape)
            {
                case MorphologyShape.Rectangular:
                    return GetRectangularKernel(kernelSize);

                case MorphologyShape.Elliptical:
                    return GetEllipticalKernel(kernelSize);

                case MorphologyShape.CrossShaped:
                    return GetCrossShapedKernel(kernelSize, anchor);

                default: throw new NotImplementedException(nameof(shape));
            }
        }

        private static BitMatrix GetRectangularKernel((int width, int height) kernelSize)
        {
            var kernel = new BitMatrix(kernelSize);

            for(var row = 0; row < kernelSize.height; ++row)
            {
                for(var column = 0; column < kernelSize.width; ++column)
                {
                    kernel[row, column] = true;
                }
            }

            return kernel;
        }

        private static BitMatrix GetCrossShapedKernel((int width, int height) kernelSize, Point? anchor = null)
        {
            if(anchor is null)
            {
                anchor = new Point(kernelSize.width / 2, kernelSize.height / 2);
            }

            var kernel = new BitMatrix(kernelSize);

            var x = anchor.Value.X;
            var y = anchor.Value.Y;

            for(var row = 0; row < kernelSize.height; ++row)
            {
                for(var column = 0; column < kernelSize.width; ++column)
                {
                    if (row == y)
                    {
                        kernel[row, column] = true;
                    }
                    else
                    {
                        if(column == x)
                        {
                            kernel[row, column] = true;
                        }
                    }                  
                }
            }

            return kernel;
        }

        private static BitMatrix GetEllipticalKernel((int width, int height) kernelSize)
        {
            var coVertex = kernelSize.height / 2;
            var focalDistance = kernelSize.width / 2;

            var unitsStartIndex = 0;
            var unitsEndIndex   = 0;

            var kernel = new BitMatrix(kernelSize);

            for(var row = 0; row < kernelSize.height; ++row)
            {
                var dy = Math.Abs(row - coVertex);

                if(dy <= coVertex)
                {
                    var dx = focalDistance * Math.Sqrt(1 - dy * dy / (coVertex * coVertex));

                    unitsStartIndex = (int)Math.Max(focalDistance - dx, 0);
                    unitsEndIndex   = (int)Math.Min(focalDistance + dx + 1, kernelSize.width);
                }

                for(int column = unitsStartIndex; column < unitsEndIndex; ++column)
                {
                    kernel[row, column] = true;
                }       
            }

            return kernel;
        }
    }
}
