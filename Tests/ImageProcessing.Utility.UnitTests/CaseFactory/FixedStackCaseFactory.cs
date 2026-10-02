using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory
{
    public static class FixedStackCaseFactory
    {
        public const int StackSize = 10;

        public static IEnumerable<int> GetStackValues
        {
            get
            {
                yield return 0;   // 0 <-- top
                yield return 1;
                yield return 2;
                yield return 3;
                yield return 4;
                yield return 5;
                yield return 6;
                yield return 7;
                yield return 8;
                yield return 9;   // 9 <-- bottom
            }
        }

        public static IEnumerable<int> GetInvalidCapacity
        {
            get
            {
                yield return -1;
                yield return 0;
                yield return -10;
            }
        }
    }
}
