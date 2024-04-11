using TaskManager.Data.Models;

namespace TaskManager.ViewModels.Interfaces
{
    public interface INotesViewModel
    {
        IEnumerable<Note> Notes { get; }
        void LoadNotes();
        void CreateNote();
        void EditNote(string noteId);
        void DeleteNote(Note note);
        void Initialize();
    }
}
