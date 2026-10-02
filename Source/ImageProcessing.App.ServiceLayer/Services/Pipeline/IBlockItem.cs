using System;

namespace ImageProcessing.App.ServiceLayer.Services.Pipeline
{
    internal interface IBlockItem
    {
        Type InputType { get; }
        Type OutputType { get; }
        object Execute(object arg);
    }
}
