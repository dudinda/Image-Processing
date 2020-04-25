using System;
using System.Collections.Generic;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory
{
    public static class RealDomainCasesFactory
    {
        /// <summary>
        /// (-1, 0)
        /// </summary>
        public static IEnumerable<object> GetOpenIntervalFromMinusOneToZero()
        {
            yield return -0.99999999999M;
            yield return -0.91111925125M;
            yield return -0.7555M;
            yield return -0.6123M;
            yield return -0.544M;
            yield return -0.412512M;
            yield return -0.000001M;
        }

        /// <summary>
        /// (0, 1)
        /// </summary>
        public static IEnumerable<object> GetOpenIntervalFromZeroToOne()
        {
            yield return 0.99999999999M;
            yield return 0.91111925125M;
            yield return 0.7555M;
            yield return 0.6123M;
            yield return 0.544M;
            yield return 0.412512M;
            yield return 0.000001M;
        }

        public static IEnumerable<object> GetLimitPoints(params object[] points)
        {
            foreach(var item in points)
            {
                yield return item;
            }
        }
       
        /// <summary>
        /// (-1, 1)
        /// </summary>
        public static IEnumerable<object> GetOpenIntervalFromMinusOneToOne()
        {
            foreach (var item in GetOpenIntervalFromMinusOneToZero())
            {
                yield return item;
            }

            foreach (var item in GetLimitPoints(0M))
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromZeroToOne())
            {
                yield return item;
            }
        }

        /// <summary>
        /// (-1, 1) \ {0}
        /// </summary>
        public static IEnumerable<object> GetOpenIntervalFromMinusOneToOneExceptZero()
        {
            foreach(var item in GetOpenIntervalFromMinusOneToZero())
            {
                yield return item;
            }
            
            foreach(var item in GetOpenIntervalFromZeroToOne())
            {
                yield return item;
            }
        }

        /// <summary>
        /// [1, +inf)
        /// </summary>
        public static IEnumerable<object> HalfOpenIntervalFromOneToPlusInf()
        {
            foreach(var item in GetLimitPoints(1M))
            {
                yield return item;
            }
            foreach(var item in GetOpenIntervalFromOneToPlusInf())
            {
                yield return item;
            }
        }

        /// <summary>
        /// (1, +inf)
        /// </summary>
        public static IEnumerable<object> GetOpenIntervalFromOneToPlusInf()
        {
            yield return 1.0000001M;
            yield return 1.25125125M;
            yield return 2M;
            yield return 10.125125125M;
            yield return 100M;
            yield return 10000.125125125M;
            yield return 10000000M;
        }

        /// <summary>
        /// (-inf, -1)
        /// </summary>
        public static IEnumerable<object> GetOpenIntervalFromMinusInfToMinusOne()
        {

            yield return -1.0000001M;
            yield return -1.25125125M;
            yield return -2M;
            yield return -10.125125125M;
            yield return -100M;
            yield return -10000.125125125M;
            yield return -10000000M;
        }

        /// <summary>
        /// (-inf, -1]
        /// </summary>
        public static IEnumerable<object> GetHalfOpenIntervalFromMinusInfToMinusOne()
        {
            foreach (var item in GetLimitPoints(-1M))
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromMinusInfToMinusOne())
            {
                yield return item;
            }
        }

        /// <summary>
        /// [-1, 1]
        /// </summary>
        public static IEnumerable<object> GetCloseIntervalFromMinusOneToOne()
        {
            foreach (var item in GetLimitPoints(-1M, 1M))
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromMinusOneToOne())
            {
                yield return item;
            }
        }

        /// <summary>
        /// (-inf, +inf)
        /// </summary>
        public static IEnumerable<object> GetRealAxis()
        {
            foreach(var item in GetOpenIntervalFromOneToPlusInf())
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromMinusInfToMinusOne())
            {
                yield return item;
            }

            foreach (var item in GetCloseIntervalFromMinusOneToOne())
            {
                yield return item;
            }
        }

        /// <summary>
        /// (-inf, +inf)
        /// </summary>
        public static IEnumerable<object> GetNonNegativeRealAxis()
        {
            foreach(var item in GetOpenIntervalFromOneToPlusInf())
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromZeroToOne())
            {
                yield return item;
            }

            foreach (var item in GetLimitPoints(0M, 1M))
            {
                yield return item;
            }
        }

        /// <summary>
        /// (-inf, -1) U (1, +inf)
        /// </summary>
        public static IEnumerable<object> GetRealAxisExceptClosedFromMinusToPlusOne()
        {
            foreach (var item in GetOpenIntervalFromOneToPlusInf())
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromMinusInfToMinusOne())
            {
                yield return item;
            }
        }

        public static IEnumerable<object> GetTrigonometryPoints()
        {
            yield return -3 * Math.PI / 2;
            yield return -Math.PI / 2;
            yield return -Math.PI;
            yield return -2 * Math.PI;
            yield return -Math.PI / 3;
            yield return -Math.PI / 4;
            yield return -Math.PI / 6;
            yield return 3 * Math.PI / 2;
            yield return Math.PI / 2;
            yield return Math.PI;
            yield return 2 * Math.PI;
            yield return Math.PI / 3;
            yield return Math.PI / 4;
            yield return Math.PI / 6;
        }
    }
}
