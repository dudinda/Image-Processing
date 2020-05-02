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
            yield return 0.000001M;
            yield return 0.412512M;
            yield return 0.544M;
            yield return 0.6123M;
            yield return 0.7555M;
            yield return 0.91111925125M;
            yield return 0.99999999999M;
        }

        public static IEnumerable<decimal> GetLimitPoints(params decimal[] points)
        {
            foreach(var x in points)
            {
                yield return x;
            }
        }
       
        /// <summary>
        /// (-1, 1)
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusOneToOne()
        {
            foreach (var x in GetOpenIntervalFromMinusOneToZero())
            {
                yield return x;
            }

            foreach (var x in GetLimitPoints(0M))
            {
                yield return x;
            }

            foreach (var x in GetOpenIntervalFromZeroToOne())
            {
                yield return x;
            }
        }

        /// <summary>
        /// (-1, 1) \ {0}
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusOneToOneExceptZero()
        {
            foreach(var x in GetOpenIntervalFromMinusOneToZero())
            {
                yield return x;
            }
            
            foreach(var x in GetOpenIntervalFromZeroToOne())
            {
                yield return x;
            }
        }

        /// <summary>
        /// [1, +inf)
        /// </summary>
        public static IEnumerable<decimal> HalfOpenIntervalFromOneToPlusInf()
        {
            foreach(var x in GetLimitPoints(1M))
            {
                yield return x;
            }
            foreach(var x in GetOpenIntervalFromOneToPlusInf())
            {
                yield return x;
            }
        }

        /// <summary>
        /// (-overflow(exp), overflow(exp))
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusExpOverflowToPlusExpOverflow()
        {
            foreach(var x in GetOpenIntervalFromMinusExpOverflowToMinusOne())
            {
                yield return x;
            }

            foreach(var x in GetClosedIntervalFromMinusOneToOne())
            {
                yield return x;
            }

            foreach(var x in GetOpenIntervalFromOneToExpOverflow())
            {
                yield return x;
            }
        }

        /// <summary>
        /// (1, overflow(exp))
        /// where overflow(exp) occurs on
        /// x > 65.370524M
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromOneToExpOverflow()
        {
            yield return 1.0000001M;
            yield return 1.25125125M;
            yield return 2M;
            yield return 10.125125125M;
            yield return 15.125215M;
            yield return 16.512126M;

            //   yield return 65.370524M;
        }

        /// <summary>
        /// (-overflow(exp), -1)
        /// where -overflow(exp) occurs on
        /// x < -65.370524M
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusExpOverflowToMinusOne()
        {
            yield return -16.512126M;
            yield return -15.125215M;
            yield return -10.125125125M;
            yield return -2M;
            yield return -1.25125125M;
            yield return -1.0000001M;

            //yield return -65.370524M;
        }

        /// <summary>
        /// (1, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromOneToPlusInf()
        {

            foreach (var x in GetOpenIntervalFromOneToExpOverflow())
            {
                yield return x;
            }

            yield return 78.5M;
            yield return 100M;
            yield return 10000.125125125M;
            yield return 14000M;
        }

        /// <summary>
        /// (-inf, -1)
        /// </summary>
        public static IEnumerable<decimal> GetOpenIntervalFromMinusInfToMinusOne()
        {
            yield return -14000M;
            yield return -10000.125125125M;
            yield return -100M;
            yield return -78.5M;

            foreach (var x in GetOpenIntervalFromMinusExpOverflowToMinusOne())
            {
                yield return x;
            }
        }

        /// <summary>
        /// (-inf, -1]
        /// </summary>
        public static IEnumerable<decimal> GetHalfOpenIntervalFromMinusInfToMinusOne()
        {
            foreach (var x in GetLimitPoints(-1M))
            {
                yield return x;
            }

            foreach (var x in GetOpenIntervalFromMinusInfToMinusOne())
            {
                yield return x;
            }
        }

        /// <summary>
        /// [-1, 1]
        /// </summary>
        public static IEnumerable<decimal> GetClosedIntervalFromMinusOneToOne()
        {
            foreach (var x in GetLimitPoints(-1M, 1M))
            {
                yield return x;
            }

            foreach (var x in GetOpenIntervalFromMinusOneToOne())
            {
                yield return x;
            }
        }

        /// <summary>
        /// (-inf, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetRealAxis()
        {
            foreach(var x in GetOpenIntervalFromOneToPlusInf())
            {
                yield return x;
            }

            foreach (var x in GetOpenIntervalFromMinusInfToMinusOne())
            {
                yield return x;
            }

            foreach (var x in GetClosedIntervalFromMinusOneToOne())
            {
                yield return x;
            }
        }

        /// <summary>
        /// [0, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetNonNegativeRealAxis()
        {
            foreach(var x in GetPositiveRealAxis())
            {
                yield return x;
            }

            yield return 0M;
        }

        /// <summary>
        /// (0, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetPositiveRealAxis()
        {
            foreach (var x in GetOpenIntervalFromOneToPlusInf())
            {
                yield return x;
            }

            foreach (var x in GetOpenIntervalFromZeroToOne())
            {
                yield return x;
            }

            yield return 1M;
        }


        /// <summary>
        /// (-inf, -1) U (1, +inf)
        /// </summary>
        public static IEnumerable<decimal> GetRealAxisExceptClosedFromMinusToPlusOne()
        {
            foreach (var x in GetOpenIntervalFromOneToPlusInf())
            {
                yield return x;
            }

            foreach (var x in GetOpenIntervalFromMinusInfToMinusOne())
            {
                yield return x;
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
