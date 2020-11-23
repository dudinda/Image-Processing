namespace ImageProcessing.App.DomainLayer.DomainEvent.CommonArgs
{
    /// <summary>
    /// Show tooltip on a form.
    /// </summary>
    public sealed class ShowTooltipOnErrorEventArgs : BaseEventArgs
    {
        public ShowTooltipOnErrorEventArgs(string message) : base()
        {
            Message = message;
        }
            
        public string Message { get; }
    }
}
