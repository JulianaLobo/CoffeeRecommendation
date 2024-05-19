using CoffeeRecommendationApi.DTOs;
using CoffeeRecommendationApi.Repositories;
using CoffeeRecommendationApi.Services;
using CoffeeRecommendationApi.DTOs;
using CoffeeRecommendationApi.Models;
using CoffeeRecommendationApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeRecommendationAPI.Services
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private const int OptimalCaffeineLevel = 175;
        private const double DecayConstant = 0.1386294; // constante de decaimento por hora

        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public List<CoffeeDTO> GetAllCoffees()
        {
            var coffees = _coffeeRepository.GetAllCoffees();
            return coffees.Select(c => new CoffeeDTO { Name = c.Name, Code = c.Code }).ToList();
        }

        public List<RecommendationDTO> CalculateRecommendations(List<RecentConsumptionDTO> recentConsumptions)
        {
            var allCoffees = _coffeeRepository.GetAllCoffees();
            var recommendations = new List<RecommendationDTO>();
            var currentCaffeineLevel = CalculateCurrentCaffeineLevel(recentConsumptions, allCoffees);

            foreach (var coffee in allCoffees)
            {
                var waitTime = CalculateWaitTime(currentCaffeineLevel, coffee.CaffeineLevel);
                recommendations.Add(new RecommendationDTO
                {
                    Name = coffee.Name,
                    Code = coffee.Code,
                    Wait = waitTime
                });
            }

            return recommendations.OrderBy(r => r.Wait).ToList();
        }

        private int CalculateCurrentCaffeineLevel(List<RecentConsumptionDTO> recentConsumptions, List<CoffeeModel> allCoffees)
        {
            int currentCaffeineLevel = 0;

            foreach (var consumption in recentConsumptions)
            {
                var coffee = allCoffees.FirstOrDefault(c => c.Code == consumption.Code);
                if (coffee != null)
                {
                    var hoursPassed = consumption.Time / 60.0;
                    var caffeineRemaining = coffee.CaffeineLevel * Math.Exp(-DecayConstant * hoursPassed);
                    currentCaffeineLevel += (int)caffeineRemaining;
                }
            }

            return currentCaffeineLevel;
        }

        private int CalculateWaitTime(int currentCaffeineLevel, int coffeeCaffeineLevel)
        {
            if (currentCaffeineLevel + coffeeCaffeineLevel <= OptimalCaffeineLevel)
            {
                return 0;
            }

            var excessCaffeine = currentCaffeineLevel + coffeeCaffeineLevel - OptimalCaffeineLevel;

            // Calculate the waiting time needed for excess caffeine to drop to zero
            var waitTimeHours = -Math.Log((double)OptimalCaffeineLevel / (currentCaffeineLevel + coffeeCaffeineLevel)) / DecayConstant;
            var waitTimeMinutes = (int)(waitTimeHours * 60);

            return waitTimeMinutes;
        }
    }
}
