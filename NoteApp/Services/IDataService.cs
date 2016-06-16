using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services
{
    using System.Collections.Generic;

    using NoteApp.Models;

    public interface IDataService
    {
        IEnumerable<Note> GetAllNotes();

        void AddNote(Note note);

        void SaveNote(Note note);

        void DeleteNote(Note note);
    }
}
