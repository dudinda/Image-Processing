using System.Drawing;
using System.Windows.Forms;

using ImageProcessing.App.Common.Enums;
using ImageProcessing.App.PresentationLayer.Views.Main;
using ImageProcessing.App.UILayer.Code.Enums;
using ImageProcessing.App.UILayer.Form.Base;
using ImageProcessing.Microkernel.DI.Controller.Interface;
using ImageProcessing.Utility.Interop.Code.Wrapper;

namespace ImageProcessing.App.UILayer.Form.Main
{
    internal sealed partial class MainForm : BaseMainForm, IMainView
    {
        public MainForm(ApplicationContext context,
                        IAppController controller)
            : base(context, controller)
        {
            InitializeComponent();
            Bind();
        }

        public Image SrcImageCopy { get; set; }
        public Image DstImageCopy { get; set; }

        public Image SrcImage
        {
            get => Src.Image;
            set => Src.Image = value;
        }

        public Image DstImage
        {
            get => Dst.Image;
            set => Dst.Image = value;
        }

        public string PathToFile
        {
            get => PathToImage.Text;
            set => PathToImage.Text = value;
        }

        public (string, string) Parameters
            => (FirstParam.Text, SecondParam.Text);

        public new void Show()
        {
            Context.MainForm = this;
            Application.Run(Context);
        }

        public void AddToUndoMainMetaInfo((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);

        public (Bitmap changed, ImageContainer from)? UndoAction()
            => Container.Undo();

        public (Bitmap changed, ImageContainer from)? RedoAction()
            => Container.Redo();

        public RgbColors GetSelectedColors(RgbColors color)
        {
            _command[
                 color.ToString()
            ].Method.Invoke(this, null);

            return (RgbColors)_command[
                 nameof(MainViewAction.GetColor)
            ].Method.Invoke(this, null);
        }

        public void ShowInfo(string info)
            => RandomVariableInformation.Show(info, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        public void ShowError(string error)
            => ErrorToolTip.Show(error, this, PointToClient(
                CursorPosition.GetCursorPosition()), 2000
            );

        public void AddToQualityMeasureMainMetaInfo(Bitmap transformed)
            => QualityMeasure.Add(transformed);

        public void ResetTrackBarValue(ImageContainer container, int value = 0, bool isEnabled = true)
            => _command[
                container.ToString() + nameof(MainViewAction.ResetTrackBar)
            ].Method.Invoke(this, new object[] { value, isEnabled });

        public Image ZoomImage(ImageContainer container)
            => _command[
                container.ToString() + nameof(MainViewAction.Zoom)
            ].Method.Invoke(this, null) as Image;

        public void SetImageToZoom(ImageContainer container, Image image)
            => _command[
                container.ToString() + nameof(MainViewAction.SetToZoom)
            ].Method.Invoke(this, new object[] { image });

        public Image GetImageCopy(ImageContainer container)
            => _command[
                container.ToString() + nameof(MainViewAction.GetCopy)
            ].Method.Invoke(this, null) as Image;

        public void SetImageCopy(ImageContainer container, Image copy)
            => _command[
                container.ToString() + nameof(MainViewAction.SetCopy)
            ].Method.Invoke(this, new object[] { copy });

        public void SetImage(ImageContainer container, Image image)
            => _command[
                container.ToString() + nameof(MainViewAction.SetImage)
            ].Method.Invoke(this, new object[] { image });

        public bool ImageIsNull(ImageContainer container)
            => (bool)_command[
                container.ToString() + nameof(MainViewAction.ImageIsNull)
            ].Method.Invoke(this, null);

        public void Refresh(ImageContainer container)
             => _command[
                 container.ToString() + nameof(MainViewAction.Refresh)
             ].Method.Invoke(this, null);

        public void SetCursor(CursorType cursor)
            => _command[
                cursor.ToString()
            ].Method.Invoke(this, null);

        public void AddToUndoContainer((Bitmap changed, ImageContainer from) action)
            => Container.Add(action);
        
        public void AddToQualityMeasureContainer(Bitmap transformed)
            =>  QualityMeasure.Add(transformed);     
    }
}
