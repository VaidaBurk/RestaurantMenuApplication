using AutoMapper;
using Restaurants.Dtos;
using Restaurants.Models;

namespace Restaurants.Profiles
{
    public class MainProfile : Profile
    {
        public MainProfile()
        {
            CreateMap<RestaurantCreateDto, RestaurantModel>();
            CreateMap<RestaurantUpdateDto, RestaurantModel>();
            CreateMap<RestaurantModel, RestaurantGetDto>();
            CreateMap<DishCreateDto, DishModel>();
            CreateMap<DishUpdateDto, DishModel>();
        }
    }
}
