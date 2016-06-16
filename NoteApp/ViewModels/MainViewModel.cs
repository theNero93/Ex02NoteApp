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
            Notes = new ObservableCollection<Note> { new Note("TestNote", DateTime.Now)};
            Notes.Add(new Note("ASdkasdflöasdfas#dfasdfsadfnasdfopow", DateTime.Now));
            AddNoteCmd = new RelayCommand(AddNewNote);
            MaxNotes = 5;

            navigationService = new NavigationService();
            navigationService.Configure("CreateNote", typeof(NoteApp.Views.CreateNotePage));
            navigationService.Configure("ShowNotes", typeof(NoteApp.Views.ShowNotes));
            navigationService.Configure("SearchNote", typeof(NoteApp.Views.SearchPage));
            navigationService.Configure("Settings", typeof(NoteApp.Views.SettingsPage));
        }
        public void AddNewNote()
        {
            Notes.Add(new Note(NewText, DateTime.Now));
            NewText = string.Empty;
            NewDateTime = DateTime.MinValue;
        }
        public int MaxNotes { get; set; }
        public string NewText { get; set; }
        public DateTime NewDateTime { get; set; }
        public RelayCommand AddNoteCmd { get; }
        public ObservableCollection<Note> Notes { get; private set; }
        public ObservableCollection<Note> ShowingNotes { get; private set; }
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
        public void NavigateBack()
        {
            navigationService.GoBack();
        }
        
    }
}
