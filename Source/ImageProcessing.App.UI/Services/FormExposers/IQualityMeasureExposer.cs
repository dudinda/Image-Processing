using System.Windows.Forms;

namespace ImageProcessing.App.UI.Services.FormExposers
{
    internal interface IQualityMeasureExposer
    {
        ///<inheritdoc cref="FormClosedEventHandler"/>
        event FormClosedEventHandler FormClosed;
    }
}
