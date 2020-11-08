using System.Collections.Generic;

namespace ImageProcessing.Utility.DataStructure.UnitTests.CaseFactory
{
    public static class BitMatrixCaseFactory
    {
        public const int RowSize = 5;
        public const int ColumnSize = 5;

        /// <summary>
        /// <para>10101</para>
        /// <para>01010</para>
        /// <para>10101</para>
        /// <para>01010</para>
        /// <para>10101</para>
        /// </summary>
        public static IEnumerable<bool> GetTraverseByColumnThenByRowCases
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

        public static IEnumerable<(int width, int height)> GetInvalidIndices
        {
            get
            {
                yield return (-1, 2);
                yield return (0, -1);
                yield return (2, ColumnSize + 2);
                yield return (RowSize + 1, 2);
                yield return (RowSize + 1, ColumnSize + 10);
                yield return (-1, -1);
            }
        }
    }
}
