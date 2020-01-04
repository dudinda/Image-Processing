﻿using System.Drawing;
using ImageProcessing.Distributions.Abstract;

namespace ImageProcessing.DomainModel.Services.Distribution
{
    public interface IDistributionService
    {
        Bitmap Distribute(Bitmap bitmap, IDistribution distribution);
    }
}
