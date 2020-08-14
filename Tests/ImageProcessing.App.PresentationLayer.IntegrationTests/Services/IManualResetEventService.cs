using System;
using System.Threading;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Services
{
    internal interface IManualResetEventService : IDisposable
    {
        ManualResetEvent Event { get; }      
    }
}
