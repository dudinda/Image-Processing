using System.Collections.Generic;

using static ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory
{
    public static class RealDomainCasesFactory
    {
        /// <summary>
        /// (-1, 0)
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusOneToZero()
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
        public static IEnumerable<decimal> GetOpenIntervalFromZeroToOne()
        {
            yield return 0.99999999999M;
            yield return 0.91111925125M;
            yield return 0.7555M;
            yield return 0.6123M;
            yield return 0.544M;
            yield return 0.412512M;
            yield return 0.000001M;
        }

        public static IEnumerable<decimal> GetLimitPoints(params decimal[] points)
        {
            foreach(var item in points)
            {
                yield return item;
            }
        }
       
        /// <summary>
        /// (-1, 1)
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusOneToOne()
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
        public static IEnumerable<decimal> GetOpenIntervalFromMinusOneToOneExceptZero()
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
        public static IEnumerable<decimal> HalfOpenIntervalFromOneToPlusInf()
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
        public static IEnumerable<decimal> GetOpenIntervalFromOneToPlusInf()
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
        public static IEnumerable<decimal> GetOpenIntervalFromMinusInfToMinusOne()
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
        public static IEnumerable<decimal> GetHalfOpenIntervalFromMinusInfToMinusOne()
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
        public static IEnumerable<decimal> GetCloseIntervalFromMinusOneToOne()
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
        public static IEnumerable<decimal> GetRealAxis()
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
        /// [0, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetNonNegativeRealAxis()
        {
            foreach(var item in GetPositiveRealAxis())
            {
                yield return item;
            }

            yield return 0M;
        }

        /// <summary>
        /// (0, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetPositiveRealAxis()
        {
            foreach (var item in GetOpenIntervalFromOneToPlusInf())
            {
                yield return item;
            }

            foreach (var item in GetOpenIntervalFromZeroToOne())
            {
                yield return item;
            }

            yield return 1M;
        }


        /// <summary>
        /// (-inf, -1) U (1, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetRealAxisExceptClosedFromMinusToPlusOne()
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

        public static IEnumerable<decimal> GetTrigonometryPoints()
        {
            yield return -3M * PI / 2M;
            yield return -PI / 2M;
            yield return -PI;
            yield return -2M * PI;
            yield return -PI / 3M;
            yield return -PI / 4M;
            yield return -PI / 6M;
            yield return 3M * PI / 2M;
            yield return PI / 2M;
            yield return PI;
            yield return 2M * PI;
            yield return PI / 3M;
            yield return PI / 4M;
            yield return PI / 6M;
        }
    }
}
