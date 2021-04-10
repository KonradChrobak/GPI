using DietApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DietApp.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        public Command CalcCommand { get; }
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

        private string wagaText;
        public string WagaText
        {
            get { return wagaText; }
            set
            {
                wagaText = value;
                OnPropertyChanged(nameof(WagaText));
            }
        }

        private string wzrostText;
        public string WzrostText
        {
            get { return wzrostText; }
            set
            {
                wzrostText = value;
                OnPropertyChanged(nameof(WzrostText));
            }
        }

        public CalculatorViewModel()
        {
            CalcCommand = new Command(OnCalcClicked);
        }

        private async void OnCalcClicked(object obj)
        {
            double waga, wzrost, bmi;
            waga = Double.Parse(WagaText);
            wzrost = Double.Parse(WzrostText)/100;

            bmi = (waga / (wzrost * wzrost));


            //mniej niż 16 - wygłodzenie
            //16 - 16.99 - wychudzenie
            //17 - 18.49 - niedowaga
            //18.5 - 24.99 - wartość prawidłowa
            //25 - 29.99 - nadwaga
            //30 - 34.99 - I stopień otyłości
            //35 - 39.99 - II stopień otyłości
            //powyżej 40 - otyłość skrajna 
            WynikText = "Twoje BMI to: " + Math.Round(bmi, 2).ToString();
            if (bmi < 16) WynikText += "\nwygłodzenie";
            if (bmi > 16 && bmi < 16.99) WynikText += "\nwychudzenie";
            if (bmi > 17 && bmi < 18.49) WynikText += "\nniedowaga";
            if (bmi > 18.5 && bmi < 24.99) WynikText += "\nwartość prawidłowa";
            if (bmi > 25 && bmi < 29.99) WynikText += "\nnadwaga";
            if (bmi > 30 && bmi < 34.99) WynikText += "\nI stopień otyłości";
            if (bmi > 35 && bmi < 39.99) WynikText += "\nII stopień otyłości";
            if (bmi > 40) WynikText += "\notyłość skrajna";





            //WynikText = Math.Round(bmi, 2).ToString();
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            //await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
