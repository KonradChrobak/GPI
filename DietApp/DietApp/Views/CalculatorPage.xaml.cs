using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DietApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CalculatorPage : ContentPage
    {
        private string wynikText;
        public string WynikText
        {
            get { return wynikText; }
            set
            {
                wynikText = value;
                OnPropertyChanged(nameof(WynikText)); 
            }
        }

        public CalculatorPage()
        {
            InitializeComponent();
            this.BindingContext = new CalculatorViewModel();
        }


        private void OnCalcClicked(object obj)
        {
            
            this.BindingContext = new CalculatorViewModel();
            WynikText = "qwe";
           // var txt = wagaEntry.Text;
            //wynikLabel.Text = "qwe";
            //wzrostEntry.SetValue(BindingFlags.Text,);
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            // await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}