namespace TaskManager.ViewModels.Interfaces
{
    public interface INoteEditorViewModel
    {
        string Title { get; set; }
        string Content { get; set; }
        void SaveData();
        void GoBack();
        void Initialize(string noteId);
    }
}
