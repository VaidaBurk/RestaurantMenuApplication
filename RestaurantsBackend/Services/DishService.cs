using AutoMapper;
using Restaurants.Dtos;
using Restaurants.Models;
using Restaurants.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurants.Services
{
    public class DishService
    {
        private readonly DishRepository _dishRepository;
        private readonly IMapper _mapper;

        public DishService(DishRepository dishRepository, IMapper mapper)
        {
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<List<DishModel>> GetAllAsync()
        {
            return await _dishRepository.GetAllAsync();
        }

        public async Task<DishModel> GetByIdAsync(int id)
        {
            var selectedDish = await _dishRepository.GetByIdAsync(id);
            if (selectedDish == null)
            {
                throw new ArgumentException("Restaurant does not exist.");
            }
            return selectedDish;
        }

        public async Task<DishModel> CreateAsync(DishCreateDto newDish)
        {
            if (newDish.MeatWeight > newDish.Weight)
            {
                throw new ArgumentException("Meat weight can't be higher than dish weight.");
            }
            DishModel dish = _mapper.Map<DishModel>(newDish);
            DishModel dishWithId = await _dishRepository.CreateAsync(dish);
            return dishWithId;
        }

        public async Task UpdateAsync(DishUpdateDto updatedDish)
        {
            if (updatedDish.MeatWeight > updatedDish.Weight)
            {
                throw new ArgumentException("Meat weight can't be higher than dish weight.");
            }
            var dish = await _dishRepository.GetByIdAsync(updatedDish.Id);
            dish.Id = updatedDish.Id;
            dish.Title = updatedDish.Title;
            dish.Weight = updatedDish.Weight;
            dish.MeatWeight = updatedDish.MeatWeight;
            dish.Description = updatedDish.Description;
            await _dishRepository.UpdateAsync(dish);
        }

        public async Task RemoveAsync(int id)
        {
            var selectedDish = await _dishRepository.GetByIdAsync(id);
            await _dishRepository.RemoveAsync(selectedDish);
        }

    }
}
