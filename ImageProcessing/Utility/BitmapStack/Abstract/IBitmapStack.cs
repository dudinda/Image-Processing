namespace ImageProcessing.Utility.BitmapStack.Abstract
{
    interface IBitmapStack<T>
    {
        bool Any();
        T Pop();
        T Peek();
        void Push(T bmp);
    }
}
