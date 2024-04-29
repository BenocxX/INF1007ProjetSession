using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs.Order;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.MapperProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<CreateOrderRequest, Order>();
        CreateMap<Order, OrderResponse>();
    }
}