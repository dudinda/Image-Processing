namespace ImageProcessing.App.Domain.Models.Options
{
    public class UndoRedoOptions
    {
        public int MaxUndoCount { get; set; } = 10;
        public int MaxRedoCount { get; set; } = 10;
    }
}
