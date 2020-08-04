using ImageProcessing.App.UILayer.ElementExposers;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.ElementCommands
{
    internal interface IBaseElementCommand<in TExposer> : IElementExposer<TExposer>
        where TExposer: class, IView
    {
        object Function(string command, params object[] args);
        void Procedure(string command, params object[] args);

    }
}
