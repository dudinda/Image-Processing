﻿using System.Reflection;
using System;
using System.Linq;

using ImageProcessing.Factory.Abstract;
using ImageProcessing.RGBFilters.Abstract;
using ImageProcessing.Enum;
using ImageProcessing.RGBFilters.Binary;
using ImageProcessing.RGBFilters.Grayscale;
using ImageProcessing.RGBFilters.Inversion;
using ImageProcessing.RGBFilters.Color;
using ImageProcessing.Extensions.TypeExtensions;
using ImageProcessing.Attributes;


namespace ImageProcessing.Factory.RGBFilters
{
    public class RGBFiltersFactory : IRGBFiltersFactory
    {
        public IRGBFilter GetFilter(RGBFilter filter)
        {
            switch(filter)
            {
                case RGBFilter.Binary:
                    return new BinaryFilter();
                case RGBFilter.Grayscale:
                    return new GrayscaleFilter();
                case RGBFilter.Inversion:
                    return new InversionFilter();
            }

            throw new ArgumentException();
        }

        public IRGBFilter GetColorFilter(RGBColors color)
        {
            var filter = Assembly
                 .GetExecutingAssembly()
                 .GetTypes()
                 .Where(type => type.GetInterface(nameof(IColor)) != null && type.IsClass)
                 .Where(type => type.HasAttribute<ColorAttribute>())
                 .Where(type => type.GetAttributeValue((ColorAttribute attr) => attr.Color == color))
                 .Select(type => (IColor)Activator.CreateInstance(type))
                 .Single();

            return new ColorFilter(filter);
        }
    }
}
