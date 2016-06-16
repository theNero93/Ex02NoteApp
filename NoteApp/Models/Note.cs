using System;

namespace NoteApp.Models
{
    using GalaSoft.MvvmLight;
    public class Note : ObservableObject
    {
        public Note(string title, string text, DateTime date)
        {
            Title = title;
            Text = text;
            Date = date;
        }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
