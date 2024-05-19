namespace CoffeeRecommendationApi.DTOs
{
    public class RecommendationDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Wait { get; set; } // Time to wait in minutes
    }
}
