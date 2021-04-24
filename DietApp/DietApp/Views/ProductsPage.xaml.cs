using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DietApp.Models;
using DietApp.Views;
using DietApp.ViewModels;

namespace DietApp.Views
{
    public partial class ProductsPage : ContentPage
    {
        ProductsViewModel _productviewModel;

        public ProductsPage()
        {
            InitializeComponent();

            BindingContext = _productviewModel = new ProductsViewModel();

        }

       
    }
}