using System;
using System.Collections.Generic;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory
{
    public static class RealDomainCasesFactory
    {
        /// <summary>
        /// (-1, 0)
        /// </summary>
        public static object[] GetOpenIntervalFromMinusOneToZero()
        {
            var result = new List<object>();

            result.AddRange(new object[] {
                -0.99999999999M,
                -0.91111925125M,
                -0.7555M,
                -0.6123M,
                -0.544M,
                -0.412512M,
                -0.000001M
            });

            return result.ToArray();
        }

        /// <summary>
        /// (0, 1)
        /// </summary>
        public static object[] GetOpenIntervalFromZeroToOne()
        {
            var result = new List<object>();

            result.AddRange(new object[] {
                 0.99999999999M,
                 0.91111925125M,
                 0.7555M,
                 0.6123M,
                 0.544M,
                 0.412512M,
                 0.000001M
            });

            return result.ToArray();
        }

        public static object[] GetLimitPoints(params object[] points)
            => points;
       
        /// <summary>
        /// (-1, 1)
        /// </summary>
        public static object[] GetOpenIntervalFromMinusOneToOne()
        {
            var result = new List<object>();

            result.AddRange(
                GetOpenIntervalFromMinusOneToZero());

            result.AddRange(
                GetLimitPoints(0M));

            result.AddRange(
                GetOpenIntervalFromZeroToOne());

            return result.ToArray();
        }

        /// <summary>
        /// (-1, 1) \ {0}
        /// </summary>
        public static object[] GetOpenIntervalFromMinusOneToOneExceptZero()
        {
            var result = new List<object>();

            result.AddRange(
                GetOpenIntervalFromMinusOneToZero());

            result.AddRange(
                GetOpenIntervalFromZeroToOne());

            return result.ToArray();
        }

        /// <summary>
        /// [1, +inf)
        /// </summary>
        public static object[] HalfOpenIntervalFromOneToPlusInf()
        {
            var result = new List<object>();

            result.AddRange(
                GetLimitPoints(1M));

            result.AddRange(
                GetOpenIntervalFromOneToPlusInf());

            return result.ToArray();
        }

        /// <summary>
        /// (1, +inf)
        /// </summary>
        public static object[] GetOpenIntervalFromOneToPlusInf()
        {
            var result = new List<object>();

            result.AddRange(new object[] {
                 1.0000001M,
                 1.25125125M,
                 2M,
                 10.125125125M,
                 100M,
                 10000.125125125M,
                 10000000M
            });

            return result.ToArray();
        }

        /// <summary>
        /// (-inf, -1)
        /// </summary>
        public static object[] GetOpenIntervalFromMinusInfToMinusOne()
        {
            var result = new List<object>();

            result.AddRange(new object[] {
                 -1.0000001M,
                 -1.25125125M,
                 -2M,
                 -10.125125125M,
                 -100M,
                 -10000.125125125M,
                 -10000000M
            });

            return result.ToArray();
        }

        /// <summary>
        /// (-inf, -1]
        /// </summary>
        public static object[] GetHalfOpenIntervalFromMinusInfToMinusOne()
        {
            var result = new List<object>();

            result.AddRange(
                GetLimitPoints(-1M));

            result.AddRange(
                GetOpenIntervalFromMinusInfToMinusOne()
                );

            return result.ToArray();
        }

        /// <summary>
        /// [-1, 1]
        /// </summary>
        public static object[] GetCloseIntervalFromMinusOneToOne()
        {
            var result = new List<object>();

            result.AddRange(
                GetLimitPoints(-1M, 1M)
                );

            result.AddRange(
                GetOpenIntervalFromMinusOneToOne()
                );
          
            return result.ToArray();
        }

        /// <summary>
        /// (-inf, +inf)
        /// </summary>
        public static object[] GetRealAxis()
        {
            var result = new List<object>();

            result.AddRange(
                GetOpenIntervalFromOneToPlusInf()
                );

            result.AddRange(
                GetOpenIntervalFromMinusInfToMinusOne()
                );

            result.AddRange(
                GetCloseIntervalFromMinusOneToOne()
                );

            return result.ToArray();
        }

        public static object[] GetTrigonometryPoints()
        {
            var result = new List<object>();

            result.AddRange(
                GetLimitPoints(
                    3 * Math.PI / 2,
                    Math.PI / 2,
                    Math.PI,
                    2 * Math.PI,
                    Math.PI / 3,
                    Math.PI / 4,
                    Math.PI / 6
                    )
                );

            return result.ToArray();
        }

    }
}
