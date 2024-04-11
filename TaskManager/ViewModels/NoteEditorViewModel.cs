using Microsoft.AspNetCore.Components;
using TaskManager.Data.Models;
using TaskManager.Services.Interfaces;
using TaskManager.ViewModels.Interfaces;

namespace TaskManager.ViewModels
{
    public class NoteEditorViewModel : INoteEditorViewModel
    {
        private readonly IRealmService _realmService;
        private readonly NavigationManager _navigationManager;
        private Note _currentNote;

        public string Title { get; set; }
        public string Content { get; set; }

        public NoteEditorViewModel(IRealmService realmService, NavigationManager navigationManager)
        {
            _realmService = realmService;
            _navigationManager = navigationManager;
        }

        public void Initialize(string noteId)
        {
            if (!string.IsNullOrEmpty(noteId) && noteId != "new")
            {
                // Realm not allowing us to change any property without transaction,
                // that why we implementing two properties Title and Content

                _currentNote = _realmService.GetNoteById(noteId);
                Title = _currentNote.Title;
                Content = _currentNote.Content;
            }
            else
                _currentNote = new Note();
        }

        public void GoBack()
        {
            SaveData();

            _navigationManager.NavigateTo("/");
        }

        public void SaveData()
        {
            // check the Title and Content emptyness

            if(!string.IsNullOrWhiteSpace(Title))
            {
                _realmService.AddOrUpdateNote(_currentNote, Title, Content);
            }
            Title = string.Empty;
            Content = string.Empty;
        }
    }
}
