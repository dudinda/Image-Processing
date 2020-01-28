using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Core.EventAggregator.Interface.BaseEventArgs
{
    public interface IBaseEventArgs<TEnum> where TEnum : struct
    {
        TEnum Arg { get; }
    }
}
