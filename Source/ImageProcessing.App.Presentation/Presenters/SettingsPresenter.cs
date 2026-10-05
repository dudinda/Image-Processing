using System;
using System.Diagnostics;
using System.Threading.Tasks;

using ImageProcessing.App.Presentation.Code.Enums;
using ImageProcessing.App.Presentation.DomainEvents.CommonArgs;
using ImageProcessing.App.Presentation.DomainEvents.SettingsArgs;
using ImageProcessing.App.Presentation.Views;
using ImageProcessing.App.Domain.Win.Services.Logger;
using ImageProcessing.Microkernel.MVP.Aggregator.Subscriber;
using ImageProcessing.Microkernel.MVP.Presenter.Implementation;
using ImageProcessing.App.Domain.Models.Options;

namespace ImageProcessing.App.Presentation.Presenters
{
    internal sealed class SettingsPresenter : BasePresenter<ISettingsView>,
        ISubscriber<ChangeLumaEventArgs>, ISubscriber<ChangeRotationEventArgs>,
        ISubscriber<ChangeScalingEventArgs>, ISubscriber<FormIsClosedEventArgs>,
        ISubscriber<EnableControlEventArgs>
    {
        private readonly ILoggerService _logger;
        private readonly AppOptions _settings;

        public SettingsPresenter(
            ILoggerService logger,
            AppOptions settings)
        {
            _settings = settings;
            _logger = logger;
        }

        /// <inheritdoc cref="ChangeRotationEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeRotationEventArgs e)
        {
            try
            {
                _settings.Rotation = View.FirstDropdown;
            }
            catch(Exception ex)
            {
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        } 

        /// <inheritdoc cref="ChangeScalingEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeScalingEventArgs e)
        {
            try
            {
                _settings.Scaling = View.SecondDropdown;
            }
            catch (Exception ex)
            {
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        } 

        /// <inheritdoc cref="ChangeLumaEventArgs"/>
        public Task OnEventHandler(object publisher, ChangeLumaEventArgs e)
        {
            try
            {
                _settings.Rec = View.ThirdDropdown;
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
                _logger.WriteEntry(ex.Message, EventLogEntryType.Error);
            }

            return Task.CompletedTask;
        }
    }
}
