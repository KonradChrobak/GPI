using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DietApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DietApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            this.BindingContext = new SettingsViewModel();
    }

        private async void SaveButton_OnClicked(object sender, EventArgs e)
        {
            var sexLabel = new Label();
            
            sexLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: SexPicker));
            Preferences.Set("sexPreferences", sexLabel.Text.ToString());
            var planLabel = new Label();
            
            planLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: PlanPicker));
            Preferences.Set("planPreferences", planLabel.Text.ToString());
            var activityLabel = new Label();

            activityLabel.SetBinding(Label.TextProperty, new Binding("SelectedItem", source: ActivityPicker));
            Preferences.Set("activityPreferences", activityLabel.Text.ToString());

            //age = Convert.ToInt32(AgeEdit);

            Preferences.Set("agePreferences", AgeEdit.Text);
            Preferences.Set("weightPreferences", WeightEdit.Text);
            Preferences.Set("heightPreferences", HeightEdit.Text);

            await Navigation.PushAsync(new AboutPage());
            //sexLabel.GetValue(Label.TextProperty, "Title");
        }


    }
}