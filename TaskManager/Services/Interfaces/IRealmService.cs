using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Data.Models;

namespace TaskManager.Services.Interfaces
{
    public interface IRealmService
    {
        IEnumerable<Note> GetAllNotes();
        Note GetNoteById(string id);
        void AddOrUpdateNote(Note note, string title, string content);
        void DeleteNote(Note note);
    }
}
