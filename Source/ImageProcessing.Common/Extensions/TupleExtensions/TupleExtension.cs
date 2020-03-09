using System;

using ImageProcessing.Common.Extensions.StringExtensions;

namespace ImageProcessing.Common.Extensions.TupleExtensions
{
    /// <summary>
    /// Extension methods for the <see cref="ValueTuple{string, string}(string string)" />.
    /// </summary>
    public static class TupleExtension
    {
        /// <summary>
        /// Try to parse the specified (string, string) pair.
        /// If the both items are successfully parsed then return <b>true</b>,
        /// otherwise <b>false</b>.
        /// </summary>
        public static bool TryParse<TOut1, TOut2>(this (string, string) input, out (TOut1, TOut2) output) 
            where TOut1 : struct
            where TOut2 : struct
                                                          
        {     
            if (!input.Item1.TryParse<TOut1>(out var first))
            {
                output = default;
                return false;
            }

            if (!input.Item2.TryParse<TOut2>(out var second))
            {
                output = default;
                return false;
            }

            output = (first, second);

            return true;
        }    
    }
}
