using Microsoft.AspNetCore.Components;
using TaskManager.Data.Models;
using TaskManager.Services.Interfaces;
using TaskManager.ViewModels.Interfaces;

namespace TaskManager.ViewModels
{
    public class NotesViewModel : INotesViewModel
    {
        private readonly IRealmService _realmService;
        private readonly NavigationManager _navigationManager;

        public IEnumerable<Note> Notes { get; private set; }

        public NotesViewModel(IRealmService realmService, NavigationManager navigationManager)
        {
            _realmService = realmService;
            _navigationManager = navigationManager;
            LoadNotes();
        }

        public void LoadNotes()
        {
            Notes = _realmService.GetAllNotes();
        }

        public void CreateNote()
        {
            _navigationManager.NavigateTo("/editor/new");
        }

        public void EditNote(string noteId)
        {
            _navigationManager.NavigateTo($"/editor/{noteId}");
        }

        public void DeleteNote(Note note)
        {
            _realmService.DeleteNote(note);
            LoadNotes();
        }

        public void Initialize()
        {
            LoadNotes();
        }
    }
}
