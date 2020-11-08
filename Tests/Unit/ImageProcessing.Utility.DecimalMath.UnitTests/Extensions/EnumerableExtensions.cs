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
            if(sets is null)
            {
                throw new ArgumentNullException(nameof(sets));
            } 

            IEnumerable<IEnumerable<TSet>> emptyProduct
                = new[] { Enumerable.Empty<TSet>() };
            return sets.Aggregate(
              emptyProduct,
              (accumulator, sequence) => accumulator.SelectMany(
                  accseq => sequence,
                  (accseq, item) => accseq.Concat(new[] { item }))
              );
        }

        internal static IEnumerable<(decimal x, decimal y)> GeneratePlane(
            this IEnumerable<IEnumerable<decimal>> sets)
        {
            if(sets is null)
            {
                throw new ArgumentNullException(nameof(sets));
            }

            if(sets.Count() != 2)
            {
                throw new ArgumentException("Wrong dimension.");
            }

            foreach(var point in sets.Cartesian().Select(prod => prod.ToArray())) 
            {
                yield return (point[0], point[1]);
            }        
        }

    }
}
