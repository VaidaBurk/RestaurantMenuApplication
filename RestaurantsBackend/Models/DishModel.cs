using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurants.Models
{
    public class DishModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public int MeatWeight { get; set; }
        public string Description { get; set; }
        public List<RestaurantModel> Restaurants { get; set; }
    }
}
