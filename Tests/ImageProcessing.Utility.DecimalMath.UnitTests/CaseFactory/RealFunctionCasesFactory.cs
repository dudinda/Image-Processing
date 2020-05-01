using System.Collections.Generic;

using static ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory.RealDomainCasesFactory;
using static ImageProcessing.Utility.DecimalMath.RealAxis.DecimalMathReal;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory
{
    public static class RealFunctionCasesFactory
    {
        public static IEnumerable<decimal>  GetArccotValues()
        {
            foreach(var argument in GetRealAxis())
            {
                if(argument != 0)
                {
                    yield return argument;
                }

                yield return PI;
            }
        }

        public static IEnumerable<(decimal x, decimal mod, decimal result)> GetModValuesAndResult()
        {
            yield return (PI / 2.0M + 3.0M * PI, PI, PI / 2.0M);
            yield return (PI / 2.0M - 3.0M * PI, PI, PI / 2.0M);
            yield return (25M, 5M, 0.0M);
            yield return (-1M, 3M, 2.0M);
            yield return (-1.27M, 1M, 0.73M);
            yield return (2.000256M, 1M, 0.000256M);
            yield return (3.0M / 2.0M, 1.0M / 2.0M, 0);
        }
    }
}
