using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Core.EventAggregator.Interface.EventArgs
{
    public interface IBaseEventArgs<TArg> 
        where TArg : struct
    {
        TArg Arg { get; }
    }

    public interface IBaseEventArgs<TFirstArg, TSecondArg>
        where TFirstArg  : struct
        where TSecondArg : struct
    {
        TFirstArg FirstArg { get; }
        TSecondArg SecondArg { get; }
    }
}
