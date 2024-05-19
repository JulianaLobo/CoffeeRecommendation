using CoffeeRecommendationApi.DTOs;
using CoffeeRecommendationApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoffeeRecommendationApi.Controllers
{
    [ApiController]
    [Route("v1/")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        [HttpGet("coffees")]
        public ActionResult<List<CoffeeDTO>> GetCoffees()
        {
            var coffees = _coffeeService.GetAllCoffees();
            return Ok(new { Coffees = coffees });
        }

        [HttpPost("calculate")]
        public ActionResult<List<RecommendationDTO>> CalculateRecommendations([FromBody] List<RecentConsumptionDTO> recentConsumptions)
        {
            var recommendations = _coffeeService.CalculateRecommendations(recentConsumptions);
            return Ok(new { Recommendations = recommendations });
        }
    }
}
