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

namespace DietApp.ViewModels
{

    public class ProductsViewModel : BaseViewModel
    {
        
        
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
        }
        async Task Add()
        {
            var name = await App.Current.MainPage.DisplayPromptAsync("Name","Enter Name");
            int calories = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Calories", "Amount of Calories(100g)"));
            int carbohydrates = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Carbohydrates", "Amount of Carbohydrates(100g)"));
            int fats = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Fats", "Amount of Fats(100g)"));
            int proteins = int.Parse(await App.Current.MainPage.DisplayPromptAsync("Proteins", "Amount of Proteins(100g)"));
            await ProductsService.AddItem(name, calories, fats,carbohydrates,proteins);
            
        }
        async Task Remove(Product product)
        {
            await ProductsService.RemoveItem(product.Id);
            await Refresh();
        }
        async Task Refresh()
        {
            IsBusy = true;
            await Task.Delay(1000);
            Product.Clear();
            var products = await ProductsService.GetItem();
            Product.AddRange(products);
            IsBusy = false;
        }

    }
}
