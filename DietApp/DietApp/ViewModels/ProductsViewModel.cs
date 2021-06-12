using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

using DietApp.Models;
using DietApp.Views;
using DietApp.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials;

namespace DietApp.ViewModels
{

    public class ProductsViewModel : BaseViewModel
    {
        public string bmiPreferences
        {
            get => Preferences.Get(nameof(bmiPreferences), "0");

            set
            {
                Preferences.Set(nameof(bmiPreferences), value);
                OnPropertyChanged(nameof(bmiPreferences));
            }
        }
        //public int kcal_sum
        //{
        //    get => Preferences.Get("kcal_sum", 0);

        //    set
        //    {
        //        Preferences.Set("kcal_sum", value);
        //        OnPropertyChanged("kcal_sum");
        //    }
        //}
        public int _kcal_sum;
        public int kcal_sum
        {
            get { return Preferences.Get("kcal_sum", 0); }
            set
            {
                _kcal_sum = value;
                Preferences.Set("kcal_sum", value);
                OnPropertyChanged(nameof(kcal_sum));
            }
        }



        public ObservableRangeCollection<Product> Product { get; set; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<Product> RemoveCommand { get; }
        public AsyncCommand RefreshCommand { get; }
        public ProductsViewModel()
        {
            Title = "Products";
            Product = new ObservableRangeCollection<Product>();
            RefreshCommand = new AsyncCommand(Refresh);
            AddCommand = new AsyncCommand(Add);
            RemoveCommand = new AsyncCommand<Product>(Remove);
            BMI = Preferences.Get("bmiPreferences", "0");
        }
        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name","Enter Name");
            int calories = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Calories", "Amount of Calories(kcal)"));
            int carbohydrates = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Carbohydrates", "Amount of Carbohydrates(g)"));
            int fats = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Fats", "Amount of Fats(g)"));
            int proteins = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Proteins", "Amount of Proteins(g)"));
            await ProductsService.AddItem(name, calories, fats, carbohydrates, proteins);
            
        }
        async Task Remove(Product product)
        {
            await ProductsService.RemoveItem();
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            Product.Clear();
            bmiPreferences = Preferences.Get("bmiPreferences", "0");
            kcal_sum = Preferences.Get("kcal_sum", 0);
            
            var products = await ProductsService.GetItem();
            kcal_sum = 0;
            foreach (var item in products)
            {
                kcal_sum += Convert.ToInt32(item.Calories);
            }

            Product.AddRange(products);
            IsBusy = false;
        }

    }
}
