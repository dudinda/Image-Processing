using System;
using System.Collections.Concurrent;
using System.Drawing;

using ImageProcessing.App.CommonLayer.Enums;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Dropdown;
using ImageProcessing.App.PresentationLayer.Views.ViewComponent.Error;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.PresentationLayer.Views.Distribution
{
    public interface IDistributionView : IView,
         IDisposable, ITooltip, IDropdown<Distributions>
    {
        void EnableQualityQueue(bool isEnabled);

        /// <summary>
        /// Adds an image, transformed by a distribution to
        /// the quality measure container.
        /// </summary>
        void AddToQualityMeasureContainer(Bitmap transformed);
        ConcurrentQueue<Bitmap> GetQualityQueue();
        void ClearQualityQueue();
    }
}
