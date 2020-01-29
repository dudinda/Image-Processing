namespace ImageProcessing.Utility.FixedStack.Interface
{
    public interface IFixedStack<T>
    {
        bool Any();
        T Pop();
        T Peek();
        void Push(T bmp);
    }
}
