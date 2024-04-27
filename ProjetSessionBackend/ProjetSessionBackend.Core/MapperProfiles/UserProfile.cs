using AutoMapper;
using ProjetSessionBackend.Core.Database.Models;
using ProjetSessionBackend.Core.DTOs.Auth;
using ProjetSessionBackend.Core.DTOs.User;

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