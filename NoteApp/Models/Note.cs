using System;

namespace NoteApp.Models
{
    using GalaSoft.MvvmLight;
    public class Note : ObservableObject
    {
        public Note(string text, DateTime time)
        {
            Text = text;
            Time = time;
        }
        public string Text { get; set; }
        public DateTime Time { get; set; }
    }
}
