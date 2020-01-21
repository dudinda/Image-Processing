namespace ImageProcessing.Utility.BitmapStack.Abstract
{
    public interface IFixedStack<T>
    {
        bool Any();
        T Pop();
        T Peek();
        void Push(T bmp);
    }
}
