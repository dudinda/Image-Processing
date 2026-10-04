using ImageProcessing.App.Presentation.Presenters;
using ImageProcessing.App.UI;
using ImageProcessing.Microkernel;
using ImageProcessing.Microkernel.MVP.Code.Enums;

using (var app = new AppLifecycle())
{
    app.Build<Startup>(DiContainer.LightInject);
    app.Run<MainPresenter>();
}