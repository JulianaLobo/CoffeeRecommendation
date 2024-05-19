using CoffeeRecommendationApi.DTOs;
using System.Collections.Generic;

namespace CoffeeRecommendationApi.Services
{
    public interface ICoffeeService
    {
        List<CoffeeDTO> GetAllCoffees();
        List<RecommendationDTO> CalculateRecommendations(List<RecentConsumptionDTO> recentConsumptions);
    }
}
