using CoffeeRecommendationApi.Models;
using System.Collections.Generic;

namespace CoffeeRecommendationApi.Repositories
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly List<CoffeeModel> _coffees;

        public CoffeeRepository()
        {
            _coffees = new List<CoffeeModel>
            {
                new CoffeeModel { Name = "Black Coffee", Code = "blk", CaffeineLevel = 95, ServingSize = 235 },
                new CoffeeModel { Name = "Espresso", Code = "esp", CaffeineLevel = 63, ServingSize = 30 },
                new CoffeeModel { Name = "Cappuccino", Code = "cap", CaffeineLevel = 63, ServingSize = 235 },
                new CoffeeModel { Name = "Latte", Code = "lat", CaffeineLevel = 63, ServingSize = 235 },
                new CoffeeModel { Name = "Flat White", Code = "wht", CaffeineLevel = 63, ServingSize = 140 },
                new CoffeeModel { Name = "Cold Brew", Code = "cld", CaffeineLevel = 120, ServingSize = 235 },
                new CoffeeModel { Name = "Decaf Coffee", Code = "dec", CaffeineLevel = 5, ServingSize = 235 }
            };
        }

        public List<CoffeeModel> GetAllCoffees()
        {
            return _coffees;
        }
    }
}
