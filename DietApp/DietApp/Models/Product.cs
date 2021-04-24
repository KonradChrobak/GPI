using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietApp.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Fats { get; set; }
        public int Carbohydrates { get; set; }
        public int Proteins { get; set; }

    }
}
