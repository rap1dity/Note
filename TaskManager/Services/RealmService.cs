using MongoDB.Bson;
using Realms;
using TaskManager.Data.Models;
using TaskManager.Services.Interfaces;

namespace TaskManager.Services
{
    public class RealmService : IRealmService
    {
        private readonly RealmConfiguration _realmConfig;

        public RealmService(RealmConfiguration cfg)
        {
            _realmConfig = cfg;
        }

        private Realm GetRealmInstance()
        {
            return Realm.GetInstance(_realmConfig);
        }

        public IEnumerable<Note> GetAllNotes()
        {
            var _realm = GetRealmInstance();

            return _realm.All<Note>().ToList();
        }

        public Note GetNoteById(string id)
        {
            var _realm = GetRealmInstance();

            return _realm.Find<Note>(new ObjectId(id));
        }

        public void AddOrUpdateNote(Note note, string title, string content)
        {
            var _realm = GetRealmInstance();

            if (note.Color is null)
                note.Color = GetHexColor();

            _realm.Write(() =>
            {
                note.Title = title;
                note.Content = content;
                _realm.Add(note, update: true);
            });

        }
        public void DeleteNote(Note note)
        {
            var _realm = GetRealmInstance();

            if (note != null && note.IsManaged && note.IsValid)
            {
                using (var trans = _realm.BeginWrite())
                {
                    _realm.Remove(note);
                    trans.Commit();
                }
            }
        }

        private string GetHexColor()
        {
            Random random = new Random();
            string color = string.Format("#{0:X6}", random.Next(0x1000000));
            return color;
        }
    }
}
