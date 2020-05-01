using System.Collections.Generic;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CasesFactory
{
    public static class ComplexDomainCasesFactory
    {
        public static IEnumerable<(decimal re, decimal im)> GetComplexNumbers()
        {
            yield return (1M, 2M);
            yield return (5M, 3M);
            yield return (0M, 1M);
            yield return (1M, 0M);
            yield return (0.001M, 0M);
            yield return (0M, 0.0001M);
            yield return (1000M, 3000M);
            yield return (25M, 30M);
            yield return (-1000M, -3000M);
        }
    }
}
