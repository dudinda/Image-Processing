using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.TypeExtensions;
using ImageProcessing.Core.Factory.RGBFiltersFactory;
using ImageProcessing.Core.Model.RGBFilters;
using ImageProcessing.RGBFilters.Binary;
using ImageProcessing.RGBFilters.Color;
using ImageProcessing.RGBFilters.Grayscale;
using ImageProcessing.RGBFilters.Inversion;

namespace ImageProcessing.Factory.Filters.RGBFilters
{
    /// <summary>
    /// A factory method
    /// where <see cref="RGBFilter"/> and <see cref="RGBColors"/> represent
    /// enumeration for types implementing <see cref="IDistribution"/>.
    /// </summary>
    public class RGBFiltersFactory : IRGBFiltersFactory
    {
        /// <summary>
        /// Provides a factory method for all <see cref="RGBFilter"/>
        /// implementing <see cref="IRGBFilter"/>.
        /// </summary>
        public IRGBFilter GetFilter(RGBFilter filter)
        {
            switch (filter)
            {
                case RGBFilter.Binary:
                    return new BinaryFilter();
                case RGBFilter.Grayscale:
                    return new GrayscaleFilter();
                case RGBFilter.Inversion:
                    return new InversionFilter();

                default: throw new NotImplementedException(nameof(filter));
            }
        }

        /// <summary>
        /// Provides a factory method for all <see cref="RGBColors"/>
        /// implementing <see cref="IRGBFilter"/>.
        /// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public IRGBFilter GetColorFilter(RGBColors color)
        {
            var filter = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .Where( type => type.GetInterface(nameof(IColor)) != null && type.IsClass)
                 .Where( type => type.HasAttribute<ColorAttribute>())
                 .Where( type => type.GetAttributeValue((ColorAttribute attr) => attr.Color == color))
                 .Select(type => (IColor)Activator.CreateInstance(type))
                 .Single();

            return new ColorFilter(filter);
        }
    }
}
