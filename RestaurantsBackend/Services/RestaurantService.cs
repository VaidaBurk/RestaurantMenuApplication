using AutoMapper;
using Restaurants.Dtos;
using Restaurants.Models;
using Restaurants.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurants.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly DishRepository _dishRepository;

        private readonly IMapper _mapper;

        public RestaurantService(RestaurantRepository restaurantRepository, DishRepository dishRepository, IMapper mapper)
        {
            _restaurantRepository = restaurantRepository;
            _dishRepository = dishRepository;
            _mapper = mapper;
        }

        public async Task<List<RestaurantGetDto>> GetAllAsync()
        {
            List<RestaurantModel> restaurants = await _restaurantRepository.GetAllAsync();
            List<RestaurantGetDto> mappedRestaurants = new();
            List<DishModel> dishes = await _dishRepository.GetAllAsync();
            foreach (var restaurant in restaurants)
            {
                RestaurantGetDto mappedRestaurant = new()
                {
                    Id = restaurant.Id,
                    Title = restaurant.Title,
                    Customers = restaurant.Customers,
                    Employees = restaurant.Employees,
                    DishId = restaurant.DishId,
                    DishTitle = dishes.FirstOrDefault(d => d.Id == restaurant.DishId).Title.ToString()
                };
                mappedRestaurants.Add(mappedRestaurant);
            }
            return mappedRestaurants;
        }

        public async Task<RestaurantModel> GetByIdAsync(int id)
        {
            var selectedRestaurant = await _restaurantRepository.GetByIdAsync(id);
            if (selectedRestaurant == null)
            {
                throw new ArgumentException("Restaurant does not exist.");
            }
            return selectedRestaurant;
        }

        public async Task<RestaurantGetDto> CreateAsync(RestaurantCreateDto newRestaurant)
        {
            RestaurantModel restaurant = _mapper.Map<RestaurantModel>(newRestaurant);
            RestaurantModel restaurantWithId = await _restaurantRepository.CreateAsync(restaurant);
            DishModel dish = await _dishRepository.GetByIdAsync(restaurantWithId.DishId);
            string dishTitle = dish.Title;
            RestaurantGetDto restaurantForTable = new()
            {
                Id = restaurantWithId.Id,
                Title = restaurantWithId.Title,
                Customers = restaurantWithId.Customers,
                Employees = restaurantWithId.Employees,
                DishId = restaurantWithId.DishId,
                DishTitle = dishTitle
            };
            return restaurantForTable;
        }

        public async Task<RestaurantGetDto> UpdateAsync(RestaurantUpdateDto updatedRestaurant)
        {
            var restaurant = await _restaurantRepository.GetByIdAsync(updatedRestaurant.Id);
            restaurant.Id = updatedRestaurant.Id;
            restaurant.Title = updatedRestaurant.Title;
            restaurant.Employees = updatedRestaurant.Employees;
            restaurant.Customers = updatedRestaurant.Customers;
            restaurant.DishId = updatedRestaurant.DishId;
            await _restaurantRepository.UpdateAsync(restaurant);

            DishModel dish = await _dishRepository.GetByIdAsync(updatedRestaurant.DishId);
            string dishTitle = dish.Title;

            RestaurantGetDto restaurantForTable = new()
            {
                Id = updatedRestaurant.Id,
                Title = updatedRestaurant.Title,
                Customers = updatedRestaurant.Customers,
                Employees = updatedRestaurant.Employees,
                DishId = updatedRestaurant.DishId,
                DishTitle = dishTitle
            };
            return restaurantForTable;
        }

        public async Task RemoveAsync(int id)
        {
            var selectedRestaurant = await _restaurantRepository.GetByIdAsync(id);
            await _restaurantRepository.RemoveAsync(selectedRestaurant);
        }

        public async Task<List<RestaurantGetDto>> GetByDishIdAsync(int dishId)
        {
            if (dishId != 0)
            {
                List<RestaurantModel> filteredRestaurants = await _restaurantRepository.GetByDishIdAsync(dishId);
                List<RestaurantGetDto> mappedFilteredRestaurants = new();
                DishModel dish = await _dishRepository.GetByIdAsync(dishId);
                string dishTitle = dish.Title;

                foreach (var restaurant in filteredRestaurants)
                {
                    RestaurantGetDto restaurantForTable = new()
                    {
                        Id = restaurant.Id,
                        Title = restaurant.Title,
                        Customers = restaurant.Customers,
                        Employees = restaurant.Employees,
                        DishId = restaurant.DishId,
                        DishTitle = dishTitle
                    };
                    mappedFilteredRestaurants.Add(restaurantForTable);
                }

                return mappedFilteredRestaurants;
            }
            else
            {
                return await GetAllAsync();
            }
        }
    }
}
