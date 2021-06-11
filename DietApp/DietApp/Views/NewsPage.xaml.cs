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
    public partial class NewsPage : ContentPage
    {
        public NewsPage()
        {
            InitializeComponent();
            this.BindingContext = new NewsViewModel();
        }
    }
}