using System;

namespace ImageProcessing.Common.Extensions.FuncExtensions
{
    public static class FuncExtension
    {
        public static TOut Process<TIn, TOut>(this TIn v, Func<TIn, TOut> f)
                                    where TIn : class
                                    where TOut : class
        {
            if (v == null)
            {
                return null;
            }

            return f(v);
        }

        public static TIn Process<TIn>(this TIn v, Action f)
                                    where TIn : class
        {
            if (v == null)
            {
                return null;
            }

            f();

            return v;
        }

        public static TOut Process<TIn1, TIn2, TOut>(this TIn1 first, TIn2 second, Func<TIn1, TIn2, TOut> f)
                                   where TIn1 : class
                                   where TIn2 : class
                                   where TOut : class
            
        {
            if (first == null)
            {
                return null;
            }

            return f(first, second);
        }


    }

}


