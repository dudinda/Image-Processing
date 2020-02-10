using System;

namespace ImageProcessing.Core.Pipeline.BlockItem.Interface
{
    internal interface IItem
    {
        Type InputType { get; }
        Type OutputType { get; }
        object Execute(object arg);
    }
}
