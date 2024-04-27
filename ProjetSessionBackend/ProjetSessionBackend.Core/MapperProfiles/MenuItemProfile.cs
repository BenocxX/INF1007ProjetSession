using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs.MenuItem;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.MapperProfiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<CreateMenuItemRequest, MenuItem>();
        CreateMap<MenuItem, MenuItemResponse>();
    }
}