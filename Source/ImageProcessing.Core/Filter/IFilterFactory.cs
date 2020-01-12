namespace ImageProcessing.DomainModel.Factory.Filters.Interface
{
    public interface IFilterFactory<out TFilter>
    {
        TFilter GetFilter(string name);
    }
}
