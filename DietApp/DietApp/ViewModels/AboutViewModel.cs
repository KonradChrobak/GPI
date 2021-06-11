using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DietApp.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://kondzio.atlassian.net/jira/software/projects/GPI/boards/3"));
            OpenSettings = new Command(async () => await Shell.Current.GoToAsync(nameof(OpenSettings)));
        }

        public ICommand OpenWebCommand { get; }
        public ICommand OpenSettings { get; }
    }
}