using DietApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DietApp.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public SettingsViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SexValue = Preferences.Get("sexPreferences", "default_value");
            PlanValue = Preferences.Get("planPreferences", "default_value");
            ActivityValue = Preferences.Get("activityPreferences", "default_value");
            AgeValue = Preferences.Get("agePreferences", "0");
            HeightValue = Preferences.Get("heightPreferences", "0");
            WeightValue = Preferences.Get("weightPreferences", "0");
            double BMIcalculated = 0;
            double activityLevel = 1;

            if (ActivityValue.Equals("Sedentary - Little or no exercise"))
            {
                activityLevel = 1.2;
            }
            else if (ActivityValue.Equals("Light exercise / sports 1 - 3 days per week"))
            {
                activityLevel = 1.4;
            }
            else if (ActivityValue.Equals("Moderate exercise / sports 3 - 5 days per week"))
            {
                activityLevel = 1.6;
            }
            else if (ActivityValue.Equals("Hard exercise / sports 6 - 7 days per week"))
            {
                activityLevel = 1.8;
            }
            else if (ActivityValue.Equals("Extreme hard daily exercise / sports and physical job"))
            {
                activityLevel = 2.2;
            }
            else
            {

            };

            if (Preferences.Get("sexPreferences", "default_value").Equals("K"))
            {
                BMIcalculated = Math.Round((655 + 9.6 * Convert.ToDouble(HeightValue) + 1.8 * Convert.ToDouble(HeightValue)
                    - 4.7 * Convert.ToDouble(AgeValue))*activityLevel);
                if(Preferences.Get("planPreferences", "default_value").Equals("Redukcja"))
                {
                    BMIcalculated = BMIcalculated - 500;
                }
                else if(Preferences.Get("planPreferences", "default_value").Equals("Masa"))
                {
                    BMIcalculated = BMIcalculated + 500;
                }
                else
                {

                }
            }
            else if (Preferences.Get("sexPreferences", "default_value").Equals("M"))
            {
                BMIcalculated = Math.Round((66 + 13.7 * Convert.ToDouble(HeightValue) + 5 * Convert.ToDouble(HeightValue)
                    - 6.76 * Convert.ToDouble(AgeValue))*activityLevel);
                if (Preferences.Get("planPreferences", "default_value").Equals("Redukcja"))
                {
                    BMIcalculated = BMIcalculated - 750;
                }
                else if (Preferences.Get("planPreferences", "default_value").Equals("Masa"))
                {
                    BMIcalculated = BMIcalculated + 750;
                }
                else
                {

                }
            }
            else
            {

            };

            BMI = BMIcalculated.ToString();

            Preferences.Set("bmiPreferences", BMI);
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
