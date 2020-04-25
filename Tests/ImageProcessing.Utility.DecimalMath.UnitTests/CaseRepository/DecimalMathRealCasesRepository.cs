using System.Collections.Generic;

using ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CaseRepository
{
    public static class DecimalMathRealCasesRepository
    {
        public static Dictionary<string, object[]> Repository { get; }
            = new Dictionary<string, object[]>()
        {
            ["(-inf, +inf)"]  = RealDomainCasesFactory.GetRealAxis(),
            ["Trigonometry"]  = RealDomainCasesFactory.GetTrigonometryPoints(),
            ["[-1, 1]"]       = RealDomainCasesFactory.GetCloseIntervalFromMinusOneToOne(),
            ["(-1, 1)"]       = RealDomainCasesFactory.GetOpenIntervalFromMinusOneToOne(),
            ["[1, +inf)"]     = RealDomainCasesFactory.HalfOpenIntervalFromOneToPlusInf()
        };
    }
}
