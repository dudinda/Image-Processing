using ImageProcessing.Microkernel.MVP.View;

namespace ImageProcessing.App.UILayer.FormControls.Base
{
    internal interface IBaseEventBinder<in TForm>
        where TForm : class, IView
    {
        public void Bind(TForm source);
    }
}
