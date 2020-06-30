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
            this IEnumerable<IEnumerable<TSet>> sets)
        {
            IEnumerable<IEnumerable<TSet>> emptyProduct
                = new[] { Enumerable.Empty<TSet>() };
            return sets.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                  from accseq in accumulator
                  from item in sequence
                  select accseq.Concat(new[] { item })
              );
        }

        internal static IEnumerable<(decimal Re, decimal Im)> GeneratePlane(
            this IEnumerable<IEnumerable<decimal>> sets)
        {
            if(sets.Count() > 2)
            {
                throw new ArgumentNullException("Wrong dimension.");
            }

            foreach(var z in sets.Cartesian().Select(prod => prod.ToArray())) 
            {
                yield return (z[0], z[1]);
            }        
        }

    }
}
