using Microsoft.EntityFrameworkCore;
using Restaurants.Data;
using Restaurants.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Repositories
{
    public class DishRepository
    {
        private readonly DataContext _dataContext;
        public DishRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<DishModel>> GetAllAsync()
        {
            return await _dataContext.Menu.OrderBy(d => d.Price).ThenBy(d => d.Title).ToListAsync();
        }

        public async Task<DishModel> GetByIdAsync(int id)
        {
            return await _dataContext.Menu.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<DishModel> CreateAsync(DishModel dish)
        {
            _dataContext.Menu.Add(dish);
            await _dataContext.SaveChangesAsync();
            return dish;
        }

        public async Task UpdateAsync(DishModel dish)
        {
            _dataContext.Menu.Update(dish);
            await _dataContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(DishModel dish)
        {
            _dataContext.Menu.Remove(dish);
            await _dataContext.SaveChangesAsync();
        }
    }
}
