namespace ImageProcessing.Core.EventAggregator.Interface.EventArgs
{
    public interface IBaseEventArgs<TArg> 
    {
        TArg Arg { get; }
    }

    public interface IBaseEventArgs<TFirstArg, TSecondArg>
    {
        TFirstArg FirstArg { get; }
        TSecondArg SecondArg { get; }
    }
}
