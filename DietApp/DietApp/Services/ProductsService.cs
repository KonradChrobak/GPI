using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using DietApp.Models;

namespace DietApp.Services
{
    public static class ProductsService
    {
        static SQLiteAsyncConnection db;
        
        static async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "MyData.db");

            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Product>();
            
        }

        public static async Task AddItem(string name, int cal, int fats, int carbohydrates, int proteins)
        {
            await Init();
            var product = new Product
            {
                Name = name,
                Calories = cal,
                Fats = fats,
                Carbohydrates = carbohydrates,
                Proteins = proteins
            };
            var id = await db.InsertAsync(product);
        }
        public static async Task RemoveItem()
        {
            await Init();
            //            await db.DeleteAsync(product); 
            await db.DropTableAsync<Product>();
            await db.CreateTableAsync<Product>();
        }
        public static async Task<IEnumerable<Product>> GetItem()
        {
            await Init();
            var product = await db.Table<Product>().ToListAsync();
            return product;
        }
    }
}
