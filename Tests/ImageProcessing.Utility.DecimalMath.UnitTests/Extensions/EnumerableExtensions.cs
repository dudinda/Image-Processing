using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;

namespace ImageProcessing.Utility.DecimalMath.UnitTests.Extensions
{
    internal static class EnumerableExtensions
    {
        internal static IEnumerable<IEnumerable<TSet>> Cartesian<TSet>(
            this IEnumerable<IEnumerable<TSet>> sequences)
        {
            IEnumerable<IEnumerable<TSet>> emptyProduct = new[] { Enumerable.Empty<TSet>() };
            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
              {
                  var result = new List<IEnumerable<TSet>>();

                  foreach (var accseq in accumulator)
                  {
                      foreach (var item in sequence)
                      {
                          result.Add(accseq.Concat(new[] { item }));
                      }
                  }

                  return result;
              });
        }

        internal static IEnumerable<(decimal Re, decimal Im)> Cartesian2DToTuple(
            this IEnumerable<IEnumerable<decimal>> axes)
        {
            if(axes.Count() > 2)
            {
                throw new ArgumentNullException("Wrong dimension.");
            }

            foreach(var product in axes.Cartesian())
            {
                var result = product.ToArray();
                yield return (result[0], result[1]);
            }        
        }

    }
}
