using Microsoft.EntityFrameworkCore;
using Restaurants.Data;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Repositories
{
    public class RestaurantRepository
    {
        private readonly DataContext _dataContext;
        public RestaurantRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<RestaurantModel>> GetAllAsync()
        {
            return await _dataContext.Restaurants.OrderBy(r => r.Title).ToListAsync();
        }

        public async Task<RestaurantModel> GetByIdAsync(int id)
        {
            return await _dataContext.Restaurants.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<RestaurantModel> CreateAsync(RestaurantModel restaurant)
        {
            _dataContext.Restaurants.Add(restaurant);
            await _dataContext.SaveChangesAsync();
            return restaurant;
        }

        public async Task UpdateAsync(RestaurantModel restaurant)
        {
            _dataContext.Restaurants.Update(restaurant);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(RestaurantModel restaurant)
        {
            _dataContext.Restaurants.Remove(restaurant);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<RestaurantModel>> GetByDishIdAsync(int dishId)
        {
            return await _dataContext.Restaurants.Where(r => r.DishId == dishId).ToListAsync();
        }

    }
}
