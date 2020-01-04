using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.DomainModel.Factory.Filters.Interface
{
    public interface IFilterFactory<out TFilter>
    {
        TFilter GetFilter(string name);
    }
}
