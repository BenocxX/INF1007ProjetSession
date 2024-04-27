using AutoMapper;
using ProjetSessionBackend.Core.Models.DTOs.Auth;
using ProjetSessionBackend.Core.Models.DTOs.User;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Core.MapperProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, UserResponse>();

        CreateMap<RegisterRequest, User>();
    }
}