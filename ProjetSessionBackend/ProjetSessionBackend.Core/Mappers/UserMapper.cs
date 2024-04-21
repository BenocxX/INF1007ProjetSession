using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs;

namespace ProjetSessionBackend.Core.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserResponse>();
    }
}