namespace ImageProcessing.Core.Factory.Filter
{
    public interface IFilterFactory<out TFilter>
    {
        TFilter GetFilter(string name);
    }
}
