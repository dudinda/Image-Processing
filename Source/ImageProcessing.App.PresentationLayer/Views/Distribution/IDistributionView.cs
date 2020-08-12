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

        /// <summary>
        /// Get the queue containing processed by a distribtuion
        /// grayscale images.
        /// </summary>
        ConcurrentQueue<Bitmap> GetQualityQueue();

        /// Get the specified parameters for a <see cref="Distributions"/>.
        public (string, string) Parameters { get; }
    }
}
