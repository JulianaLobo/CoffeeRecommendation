using CoffeeRecommendationApi.Models;
using System.Collections.Generic;

namespace CoffeeRecommendationApi.Repositories
{
    public interface ICoffeeRepository
    {
        List<CoffeeModel> GetAllCoffees();
    }
}
