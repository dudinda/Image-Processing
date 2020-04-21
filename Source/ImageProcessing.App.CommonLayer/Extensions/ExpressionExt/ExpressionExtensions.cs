using System;
using System.Linq.Expressions;

namespace ImageProcessing.App.CommonLayer.Extensions.ExpressionExt
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<object, object>> ConvertFunction<TIn, TOut>(
            this Expression<Func<TIn, TOut>> function)
        {
            var param = Expression.Parameter(typeof(object));

            return Expression.Lambda<Func<object, object>>
            (
                Expression.Invoke(
                    function,
                    Expression.Convert(param, typeof(TIn))
                ),
                param        
            );
        }

        public static Expression<Action<object>> ConvertFunction<TIn>(
           this Expression<Action<TIn>> function)
        {
            var param = Expression.Parameter(typeof(object));

            return Expression.Lambda<Action<object>>
            (
                Expression.Invoke(
                    function,
                    Expression.Convert(param, typeof(TIn))
                ),
                param
            );
        }
    }
}
