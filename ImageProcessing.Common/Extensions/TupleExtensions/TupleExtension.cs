using ImageProcessing.Common.Extensions.StringExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ImageProcessing.Common.Extensions.TupleExtensions
{
    public static class TupleExtension
    {
        public static bool TryParse<TOut1, TOut2>(this (string, string) input, out (TOut1, TOut2) output) 
            where TOut1 : struct
            where TOut2 : struct
                                                          
        {

            if (input.Item1.TryParse<TOut1>(out var first))
            {
                output = default;
                return false;
            }

            if (input.Item2.TryParse<TOut2>(out var second))
            {
                output = default;
                return false;
            }

            output = (first, second);

            return true;
        }    
    }
}
