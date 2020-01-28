namespace ImageProcessing.Core.Factory.Filter
{
    public interface IFilterFactory<out TFilter, in TEnum>
    {
        TFilter GetFilter(TEnum filter);
    }
}
