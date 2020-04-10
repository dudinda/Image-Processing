using System;

namespace ImageProcessing.ServiceLayer.Services.Pipeline.Item.Interface
{
    internal interface IBlockItem
    {
        Type InputType { get; }
        Type OutputType { get; }
        object Execute(object arg);
    }
}
