using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs.Restaurant;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.MapperProfiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantRequest, Restaurant>();
        CreateMap<Restaurant, RestaurantResponse>();
    }
}