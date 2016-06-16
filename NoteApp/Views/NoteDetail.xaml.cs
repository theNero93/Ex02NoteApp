using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NoteApp.Views
{
    using NoteApp.ViewModels;
    using NoteApp.Models;
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NoteDetail : Page
    {
        
        public NoteDetail()
        {
            this.InitializeComponent();
        }
        public MainViewModel ViewModel => DataContext as MainViewModel;

        private void Save_Edited_Note(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectedNote.Title = EditedTitle.Text;
            ViewModel.SelectedNote.Text = EditedText.Text;
            ViewModel.NavigateBack();

        }

        private void Delete_Note(object sender, RoutedEventArgs e)
        {
            ViewModel.Notes.Remove(ViewModel.SelectedNote);
            ViewModel.NavigateBack();
        }
    }
}
