namespace NoteApp.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Views;
    using GalaSoft.MvvmLight.Command;
    using NoteApp.Models;
    using NoteApp.Views;
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationService navigationService;
        public MainViewModel()
        {
            Notes = new ObservableCollection<Note> { new Note("TestNote","Just a TestNote", DateTime.Now)};
            Notes.Add(new Note("Was geht ab","ASdkasdflöasdfas#dfasdfsadfnasdfopow", DateTime.Now));
            AddNoteCmd = new RelayCommand(AddNewNote);
            MaxNotes = 5;
            SearchString = "";

            navigationService = new NavigationService();
            navigationService.Configure("CreateNote", typeof(NoteApp.Views.CreateNotePage));
            navigationService.Configure("ShowNotes", typeof(NoteApp.Views.ShowNotes));
            navigationService.Configure("SearchNote", typeof(NoteApp.Views.SearchPage));
            navigationService.Configure("Settings", typeof(NoteApp.Views.SettingsPage));
            navigationService.Configure("NoteDetail", typeof(NoteApp.Views.NoteDetail));
        }
        public void AddNewNote()
        {
            Notes.Add(new Note(NewTitle, NewText, DateTime.Now));
            NewTitle = string.Empty;
            NewText = string.Empty;
            NewDateTime = DateTime.Now;
        }
        public Note SelectedNote { get; set; }
        public int MaxNotes { get; set; }
        public string NewTitle { get; set; }
        public string NewText { get; set; }
        public DateTime NewDateTime { get; set; }
        public RelayCommand AddNoteCmd { get; }
        public ObservableCollection<Note> Notes { get; private set; }
        public Boolean IsAscending { get; set; }
        public string SearchString { get; set; }

        public List<Note> SearchedNotes
        {
            get
            {
                var notes = new List<Note>();
                if (SearchString != "")
                {
                    foreach (var nt in Notes
                            .Where(n => n.Text.ToUpper().Contains(SearchString.ToUpper()))
                                .OrderBy(n => n.Date)
                                .ToList())
                    {
                        notes.Add(nt);
                    }
                }
                return notes;
            }


        }

        public void NavigateToCreateNote()
        {
            navigationService.NavigateTo("CreateNote");
        }
        public void NavigateToShowNotes()
        {
            navigationService.NavigateTo("ShowNotes");
        }
        public void NavigateToSearchNote()
        {
            navigationService.NavigateTo("SearchNote");
        }
        public void NavigateToSettings()
        {
            navigationService.NavigateTo("Settings");
        }
        public void NavigateToDetails()
        {
            if (SelectedNote != null)
            {
                navigationService.NavigateTo("NoteDetail", SelectedNote);
            }
        }
        public void NavigateBack()
        {
            navigationService.GoBack();
        }

        
    }
}
