using System;
using System.Threading;

namespace ImageProcessing.App.PresentationLayer.UnitTests.Services
{
    internal interface IAutoResetEventService : IDisposable
    {
        void WaitSignal();
        void Signal();
        void Reset();
    }
}
