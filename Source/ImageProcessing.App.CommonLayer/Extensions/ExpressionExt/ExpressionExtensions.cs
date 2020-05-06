using System;
using System.Linq.Expressions;

namespace ImageProcessing.App.CommonLayer.Extensions.ExpressionExt
{
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Transform an expression of <see cref="Func{TIn, Out}"/> to
        /// the expression of  <see cref="Func{object, object}"/>
        /// where the <typeparamref name="TIn"/> and <typeparamref name="TOut"/> both
        /// are an <see cref="object"/> class.
        /// </summary>
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

        /// <summary>
        /// Transform an expression of <see cref="Action{TIn}"/> to
        /// the expression of  <see cref="Action{object}"/>
        /// where the <typeparamref name="TIn"/>
        /// is an <see cref="object"/> class.
        /// </summary>
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
