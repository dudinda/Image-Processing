using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

using ImageProcessing.App.PresentationLayer.Code.Enums;
using ImageProcessing.App.PresentationLayer.DomainEvents.CommonArgs;
using ImageProcessing.App.PresentationLayer.DomainEvents.TransformationArgs;
using ImageProcessing.App.PresentationLayer.Properties;
using ImageProcessing.App.PresentationLayer.ViewModels;
using ImageProcessing.App.PresentationLayer.Views;
using ImageProcessing.App.ServiceLayer.Providers.Transformation.Interface;
using ImageProcessing.App.ServiceLayer.Services.BitmapCopyReference.Interface;
using ImageProcessing.App.ServiceLayer.Services.Pipeline.Block.Implementation;
using ImageProcessing.App.ServiceLayer.Win.Services.Logger.Interface;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;

namespace ImageProcessing.App.PresentationLayer.Presenters
{
    internal sealed class TransformationPresenter : BasePresenter<ITransformationView, BitmapViewModel>,
        ISubscriber<ApplyTransformationEventArgs>, ISubscriber<ContainerUpdatedEventArgs>,
        ISubscriber<RestoreFocusEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<EnableControlEventArgs>
    {
        private readonly ILoggerService _logger;
        private readonly IBitmapCopyService _reference;
        private readonly ITransformationProvider _provider;

        public TransformationPresenter(
            IBitmapCopyService reference,
            ITransformationProvider provider,
            ILoggerService logger) 
        {
            _reference = reference;
            _logger = logger;
            _provider = provider;
        }

        /// <inheritdoc cref="ApplyTransformationEventArgs"/>
        public async Task OnEventHandler(object publisher, ApplyTransformationEventArgs e)
        {
            try
            {
                var (xStr, yStr) = e.Parameters;

                var x = Convert.ToDouble(xStr);
                var y = Convert.ToDouble(yStr);

                var copy = await _reference.GetCopy().ConfigureAwait(true);

                var transformation = View.Dropdown;

                Aggregator.PublishFromAll(publisher,
                    new AttachBlockToRendererEventArgs(
                        block: new PipelineBlock(copy)
                            .Add<Bitmap, Bitmap>(
                                (bmp) => _provider.Apply(bmp, x, y, transformation))
                    )
                 );
            }
            catch(Exception ex)
            {
                View.Tooltip(Errors.ApplyTransformation);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }
        }

        /// <inheritdoc cref="ContainerUpdatedEventArgs"/>
        public Task OnEventHandler(object publisher, ContainerUpdatedEventArgs e)
        {
            try
            {
                ViewModel.SelectedArea = e.Area;
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc cref="RestoreFocusEventArgs"/>
        public Task OnEventHandler(object publisher, RestoreFocusEventArgs e)
        {
            try
            {
                View.Focus();
            }
            catch(Exception ex)
            {
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, FormIsClosedEventArgs e)
        {
            try
            {
                View.Close();
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }

        public Task OnEventHandler(object publisher, EnableControlEventArgs e)
        {
            try
            {
                View.EnableControls(e.State != MenuBtnState.ImageEmpty);
            }
            catch (Exception ex)
            {
                View.Tooltip(Errors.UpdatingViewModel);
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }
    }
}
