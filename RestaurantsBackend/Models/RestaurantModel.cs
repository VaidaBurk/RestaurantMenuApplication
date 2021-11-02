namespace Restaurants.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Customers { get; set; }
        public int Employees { get; set; }
        public int DishId { get; set; }
    }
}
