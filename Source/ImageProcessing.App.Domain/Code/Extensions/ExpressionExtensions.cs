using System;
using System.Linq.Expressions;

namespace ImageProcessing.App.Domain.Code.Extensions
{
    public static class ExpressionExtensions
    {
        extension<TIn, TOut>(Expression<Func<TIn, TOut>> function)
        {
            /// <summary>
            /// Transform an expression of <see cref="Func{TIn, Out}"/> to
            /// the expression of  <see cref="Func{object, object}"/>
            /// where the <typeparamref name="TIn"/> and <typeparamref name="TOut"/> both
            /// are an <see cref="object"/> class.
            /// </summary>
            public Expression<Func<object, object>> ConvertFunction()
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
        }
        
        extension<TIn>(Expression<Action<TIn>> function)
        {
            /// <summary>
            /// Transform an expression of <see cref="Action{TIn}"/> to
            /// the expression of  <see cref="Action{object}"/>
            /// where the <typeparamref name="TIn"/>
            /// is an <see cref="object"/> class.
            /// </summary>
            public Expression<Action<object>> ConvertFunction()
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
}
