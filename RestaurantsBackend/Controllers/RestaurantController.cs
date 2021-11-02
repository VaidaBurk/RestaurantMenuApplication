using Microsoft.AspNetCore.Mvc;
using Restaurants.Dtos;
using Restaurants.Services;
using System.Threading.Tasks;

namespace Restaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController : Controller
    {
        private readonly RestaurantService _restaurantService;
        public RestaurantController(RestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _restaurantService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _restaurantService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(RestaurantCreateDto newRestaurant)
        {
            return Ok(await _restaurantService.CreateAsync(newRestaurant));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(RestaurantUpdateDto updatedRestaurant)
        {
            return Ok(await _restaurantService.UpdateAsync(updatedRestaurant));
        }

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            await _restaurantService.RemoveAsync(id);
            return NoContent();
        }

        [HttpGet("/dishId={dishId}")]
        public async Task<ActionResult> GetByDishId(int dishId)
        {
            return Ok(await _restaurantService.GetByDishIdAsync(dishId));
        }
    }
}
