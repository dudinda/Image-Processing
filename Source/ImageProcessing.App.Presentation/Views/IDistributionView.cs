using System;
using System.Collections.Concurrent;
using System.Drawing;

using ImageProcessing.App.Domain.Code.Enums;
using ImageProcessing.App.Presentation.Views.ViewComponents;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.Presentation.Views
{
    /// <summary>
    /// Represents a control panel which provides tools to
    /// get the information about a bitmap luminance.
    /// </summary>
    public interface IDistributionView : IView, IFormState,
        IDisposable, ITooltip, IDropdown<PrDistribution>
    {
        /// <summary>
        /// Enable the button to show the quality measure view.
        /// </summary>
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
    }
}
