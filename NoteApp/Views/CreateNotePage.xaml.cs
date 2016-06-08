using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    using Windows.UI.Popups;    /// <summary>
                                /// An empty page that can be used on its own or navigated to within a Frame.
                                /// </summary>
    public sealed partial class CreateNotePage : Page
    {
        public CreateNotePage()
        {
            this.InitializeComponent();
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

        }

        private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }
        public MainViewModel ViewModel => DataContext as MainViewModel;

        private async void onSubmitNote(object sender, RoutedEventArgs e)
        {
            if(NewTextTxt.Text == String.Empty)
            {
                MessageDialog dia = new MessageDialog("Can't add empty notes");
                dia.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                var answ = await dia.ShowAsync();
            }else
            {
                ViewModel.AddNewNote();
            }

        }

        private async void onCancleNote(object sender, RoutedEventArgs e)
        {
            if (NewTextTxt.Text != String.Empty)
            {
                MessageDialog dia = new MessageDialog("Cancle Note creation?");
                dia.Title = "Cancle Note creation";
                dia.Commands.Add(new UICommand { Label = "Ok", Id = 0 });
                dia.Commands.Add(new UICommand { Label = "Cancle", Id = 1 });
                var answ = await dia.ShowAsync();
                if ((int)answ.Id == 0)
                {
                    ViewModel.NavigateBack();
                }
            }
            ViewModel.NavigateBack();
        }
    }
}
