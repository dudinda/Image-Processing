using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.Factory
{
    public static class DecimalMathRealCasesFactory
    {
        public static Dictionary<string, object[]>
            Factory { get; } = new Dictionary<string, object[]>()
        {
            ["(-inf, +inf)"] = new object[]
            {
                 100000000000000M,
                 1000.125123123123M,
                 1000000000.0000000000007M,
                 0.000000000000010M,
                 0.1000412412512400M,
                 0.999999231241241123231M,
                 0M,
                -100000000000000M,
                -100000.125123123123M,
                -1000000000.0000000000007M,
                -0.000000000000010M,
                -0.1000412412512400M,
                -0.999999231241241123231M
            },

            ["Trigonometry"] = new object[]
            {
                3 * Math.PI / 2,
                Math.PI / 2,
                Math.PI,
                2 * Math.PI,
                Math.PI / 3,
                Math.PI / 4,
                Math.PI / 6,
             },

            ["[-1, 1]"] = new object[]
            {
                -1M,
                -0.5M,
                -0.0000000001M,
                 0M,
                 0.0000000001M,
                 0.5M,
                 1M
            },

            ["(-1, 1)"] = new object[]
            {
                -0.9999998M,
                -0.5M,
                -0.0000000001M,
                 0M,
                 0.0000000001M,
                 0.5M,
                 0.99999998M
            }

        };
    }
}
