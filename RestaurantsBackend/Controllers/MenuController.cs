using Microsoft.AspNetCore.Mvc;
using Restaurants.Dtos;
using Restaurants.Services;
using System;
using System.Threading.Tasks;

namespace Restaurants.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly DishService _dishService;

        public MenuController(DishService dishService)
        {
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _dishService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            return Ok(await _dishService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> Create(DishCreateDto newDish)
        {
            return Ok(await _dishService.CreateAsync(newDish));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(DishUpdateDto updatedDish)
        {
            await _dishService.UpdateAsync(updatedDish);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                await _dishService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode(404, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Something bad has happened");
            }

        }
    }
}
