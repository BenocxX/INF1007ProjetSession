using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs.Menu;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.MapperProfiles;

public class MenuProfile : Profile
{
    public MenuProfile()
    {
        CreateMap<CreateMenuRequest, Menu>();
        CreateMap<Menu, MenuResponse>();
    }
}