using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory
{
    public static class BitMatrixCaseFactory
    {
        /// <summary>
        /// <para>10101</para>
        /// <para>01010</para>
        /// <para>10101</para>
        /// <para>01010</para>
        /// <para>10101</para>
        /// </summary>
        public static IEnumerable<bool> GetTraverseByColumnTheByRowCases
        {
            get
            {
                yield return true;  yield return false; yield return true;  yield return false; yield return true;
                yield return false; yield return true;  yield return false; yield return true;  yield return false;
                yield return true;  yield return false; yield return true;  yield return false; yield return true;
                yield return false; yield return true;  yield return false; yield return true;  yield return false;
                yield return true;  yield return false; yield return true;  yield return false; yield return true;
            }
        }
    }
}
