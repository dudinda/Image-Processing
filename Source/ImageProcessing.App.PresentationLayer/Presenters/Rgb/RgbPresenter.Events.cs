using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageProcessing.App.DomainLayer.DomainEvent.RgbArgs;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;

namespace ImageProcessing.App.PresentationLayer.Presenters.Rgb
{
    internal sealed partial class RgbPresenter
        : ISubscriber<RgbFilterEventArgs>,
          ISubscriber<RgbColorFilterEventArgs>
    {
        public void OnEventHandler(RgbColorFilterEventArgs e)
            => ApplyColorFilter(e);
  
        public void OnEventHandler(RgbFilterEventArgs e)
            => ApplyRgbFilter(e);    
    }
}
