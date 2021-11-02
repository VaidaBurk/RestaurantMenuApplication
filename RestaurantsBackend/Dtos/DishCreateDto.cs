namespace Restaurants.Dtos
{
    public class DishCreateDto
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public int MeatWeight { get; set; }
        public string Description { get; set; }
    }
}
