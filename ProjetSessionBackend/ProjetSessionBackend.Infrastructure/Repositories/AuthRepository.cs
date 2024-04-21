// using System.ComponentModel.DataAnnotations;
// using AutoMapper;
// using DevOne.Security.Cryptography.BCrypt;
// using Microsoft.EntityFrameworkCore;
// using ProjetSessionBackend.Core.Interfaces.Repositories;
// using ProjetSessionBackend.Core.Models.DTOs;
// using ProjetSessionBackend.Core.Models.Entities;
//
// namespace ProjetSessionBackend.Infrastructure.Repositories;
//
// public class AuthRepository: BaseRepository, IAuthRepository
// {
//     public AuthRepository(IMapper mapper) : base(mapper)
//     {
//     }
//
//     public async Task<User> Register(User user)
//     {
//         if (await Db.Users.AnyAsync(u => u.Email == user.Email))
//         {
//             throw new ValidationException("Email already exists");
//         }
//         user.PasswordSalt = BCryptHelper.GenerateSalt(10);
//         user.Password = BCryptHelper.HashPassword(user.Password, user.PasswordSalt);
//         Db.Users.Add(user);
//         await Db.SaveChangesAsync();
//         return user;
//     }
//
//     public async Task<User?> Login(UserLoginResponse userLoginResponse)
//     {
//         var user = await Db.Users.SingleOrDefaultAsync(x => x.Email == userLoginResponse.Email);
//         
//         if (user == null) return null;
//
//         return BCryptHelper.CheckPassword(userLoginResponse.Password, user.Password) ? user : null;
//     }
// }