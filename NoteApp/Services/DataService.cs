using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services
{
    using System;
    using System.Collections.Generic;

    using NoteApp.Models;

    public class DataService : IDataService
    {
        private readonly List<Note> allNotes;

        
        public IEnumerable<Note> GetAllNotes()
        {
            return allNotes;
        }

        public void AddNote(Note note)
        {
            allNotes.Add(note);
        }

        public void SaveNote(Note note)
        {
            note.Date = DateTime.Now;
        }

        public void DeleteNote(Note note)
        {
            allNotes.Remove(note);
        }
    }
}
