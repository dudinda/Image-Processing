using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

using ImageProcessing.Common.Attributes;
using ImageProcessing.Common.Enums;
using ImageProcessing.Common.Extensions.TypeExtensions;
using ImageProcessing.DomainModel.Factory.RgbFilters.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Binary;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Color;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Grayscale;
using ImageProcessing.DomainModel.Model.RgbFilters.Implementation.Inversion;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface;
using ImageProcessing.DomainModel.Model.RgbFilters.Interface.Color;

namespace ImageProcessing.DomainModel.Factory.RgbFilters.Implementation
{
    /// <summary>
    /// A factory method
    /// where <see cref="RgbFilter"/> and <see cref="RgbColors"/> represent
    /// enumeration for types implementing <see cref="IDistribution"/>.
    /// </summary>
    public sealed class RgbFilterFactory : IRgbFilterFactory
    {
        /// <summary>
        /// Provides a factory method for all <see cref="RgbFilter"/>
        /// implementing <see cref="IRgbFilter"/>.
        /// </summary>
        public IRgbFilter GetFilter(RgbFilter filter)
        {
            switch (filter)
            {
                case RgbFilter.Binary:
                    return new BinaryFilter();
                case RgbFilter.Grayscale:
                    return new GrayscaleFilter();
                case RgbFilter.Inversion:
                    return new InversionFilter();

                default: throw new NotImplementedException(nameof(filter));
            }
        }

        /// <summary>
        /// Provides a factory method for all <see cref="RgbColors"/>
        /// implementing <see cref="IRgbFilter"/>.
        /// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public IRgbFilter GetColorFilter(RgbColors color)
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
