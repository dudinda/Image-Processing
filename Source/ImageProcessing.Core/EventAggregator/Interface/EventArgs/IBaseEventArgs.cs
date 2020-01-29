using System;
using System.Collections.Generic;
using System.Text;

namespace ImageProcessing.Core.EventAggregator.Interface.EventArgs
{
    public interface IBaseEventArgs<TArg> where TArg : struct
    {
        TArg Arg { get; }
    }
}
