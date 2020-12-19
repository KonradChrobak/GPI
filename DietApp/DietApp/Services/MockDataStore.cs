using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DietApp.Models;

namespace DietApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Rice", Description="This is an item description.", Calories="350" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Chicken breast", Description="This is an item description.", Calories="400" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Beef", Description="This is an item description.", Calories = "600" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Egg", Description="This is an item description.", Calories = "100" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Orange Juice", Description="This is an item description.", Calories = "45" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Pasta", Description="This is an item description.", Calories = "370" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}