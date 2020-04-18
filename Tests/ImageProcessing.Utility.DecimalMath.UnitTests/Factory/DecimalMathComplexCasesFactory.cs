using System.Collections.Generic;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.Factory
{
    public static class DecimalMathComplexCasesFactory
    {
        public static  Dictionary<string, object[]> Factory { get; }
            = new Dictionary<string, object[]>()
        {
            ["Numbers"] = new object[]
            {
                (0M, 0M),
                (5M, 3M),
                (0M, 1M),
                (1M, 0M),
                (0.001M, 0M),
                (0M, 0.001M),
                (1000M, 3000M),
                (-1000M, -3000M)
            }
        };
    }
}
