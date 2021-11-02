namespace Restaurants.Dtos
{
    public class DishUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public int MeatWeight { get; set; }
        public string Description { get; set; }
    }
}
