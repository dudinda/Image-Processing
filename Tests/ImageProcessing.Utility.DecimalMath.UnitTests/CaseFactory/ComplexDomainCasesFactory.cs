using System.Collections.Generic;
using ImageProcessing.Utility.DecimalMath.UnitTests.CaseFactory;
using ImageProcessing.Utility.DecimalMath.UnitTests.Extensions;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.CasesFactory
{
    public static class ComplexDomainCasesFactory
    {
        /// <summary>
        /// R x R
        /// </summary>
        public static IEnumerable<(decimal Re, decimal Im)> GetComplexNumbers()
        {
            
            foreach(var point in new[] {
                RealDomainCasesFactory.GetRealAxis(),
                RealDomainCasesFactory.GetRealAxis()
            }.Cartesian2DToTuple())
            {
                yield return point;
            }
        }
    }
}
