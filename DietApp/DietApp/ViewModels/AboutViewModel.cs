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
        }

        public ICommand OpenWebCommand { get; }
    }
}