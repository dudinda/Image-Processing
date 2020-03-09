using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ImageProcessing.Common.Extensions.BitmapExtensions;
using ImageProcessing.Common.Helpers;
using ImageProcessing.Core.Model.Morphology.BinaryOperator;

namespace ImageProcessing.DomainModel.Model.Morphology
{
    /// <summary>
    /// Implements the <see cref="IMorphologyBinary"/>.
    /// </summary>
    public class AdditionOperator : IMorphologyBinary
    {
        /// <inheritdoc />
        public Bitmap Filter(Bitmap lvalue, Bitmap rvalue)
        {
            Requires.IsNotNull(lvalue, nameof(lvalue));
            Requires.IsNotNull(rvalue, nameof(rvalue));

            var result = new Bitmap(lvalue);

            var lvalueBitmapData = lvalue.LockBits(new Rectangle(0, 0, lvalue.Width, lvalue.Height),
                                                   ImageLockMode.ReadOnly,
                                                   lvalue.PixelFormat);

            var rvalueBitmapData = rvalue.LockBits(new Rectangle(0, 0, rvalue.Width, rvalue.Height),
                                                   ImageLockMode.ReadOnly,
                                                   rvalue.PixelFormat);

            var resultBitmapData = result.LockBits(new Rectangle(0, 0, result.Width, result.Height),
                                                   ImageLockMode.WriteOnly,
                                                   result.PixelFormat);

            var size = result.Size;
            var ptrStep = result.GetBitsPerPixel() / 8;

            unsafe
            {
                var rvalueStartPtr = (byte*)rvalueBitmapData.Scan0.ToPointer();
                var lvalueStartPtr = (byte*)lvalueBitmapData.Scan0.ToPointer();
                var resultStartPtr = (byte*)resultBitmapData.Scan0.ToPointer();

                var options = new ParallelOptions()
                {
                    MaxDegreeOfParallelism = Environment.ProcessorCount
                };

                Parallel.For(0, size.Height, options, y =>
                {
                    //get the address of a new line
                    var rvaluePtr = rvalueStartPtr + y * rvalueBitmapData.Stride;
                    var lvaluePtr = lvalueStartPtr + y * lvalueBitmapData.Stride;
                    var resultPtr = resultStartPtr + y * resultBitmapData.Stride;

                    for (var x = 0; x < size.Width; ++x, rvaluePtr += ptrStep, lvaluePtr += ptrStep, resultPtr += ptrStep)
                    {
                        resultPtr[0] = GetByteValue(lvaluePtr[0] + rvaluePtr[0]);
                        resultPtr[1] = GetByteValue(lvaluePtr[1] + rvaluePtr[1]);
                        resultPtr[2] = GetByteValue(lvaluePtr[2] + rvaluePtr[2]);
                    }
                });
            }

            rvalue.UnlockBits(rvalueBitmapData);
            lvalue.UnlockBits(lvalueBitmapData);
            result.UnlockBits(resultBitmapData);

            return result;

            byte GetByteValue(int value)
            {
                if (value > 255)
                {
                    value = 255;
                }
                else if (value < 0)
                {
                    value = 0;
                }

                return (byte)value;
            };
        }
    }
}
