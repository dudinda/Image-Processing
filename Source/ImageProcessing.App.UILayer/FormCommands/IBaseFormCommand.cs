using ImageProcessing.App.UILayer.FormExposers;
using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormCommands
{
    internal interface IBaseFormCommand<in TExposer> : IFormExposer<TExposer>
        where TExposer: class, IView
    {
        object Function(string command, params object[] args);
        void Procedure(string command, params object[] args);
    }
}
