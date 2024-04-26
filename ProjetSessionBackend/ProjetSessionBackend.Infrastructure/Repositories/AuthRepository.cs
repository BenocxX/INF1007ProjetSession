using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class AuthRepository: BaseRepository, IAuthRepository
{
    public AuthRepository(IMapper mapper) : base(mapper) { }

    public async Task<int> Register(RegisterResponse register)
    {
        return await CreatePersonAndUser(register, ERole.User);
    }

    public async Task<int> RegisterEmployee(RegisterResponse register)
    {
        return await CreatePersonAndUser(register, ERole.Employee);
    }

    public async Task<int> RegisterAdmin(RegisterResponse register)
    {
        return await CreatePersonAndUser(register, ERole.Admin);
    }

    public async Task<Person?> Login(UserLoginResponse userLoginResponse)
    {
        var person = await Db.People.Include(x => x.User).ThenInclude(x => x.Role).SingleOrDefaultAsync(x => x.Email == userLoginResponse.Email);

        if (person == null) return null;
        
        return BCryptHelper.CheckPassword(userLoginResponse.Password, person.User?.Password) ? person : null;
    }

    private async Task<int> CreatePersonAndUser(RegisterResponse register, ERole role)
    {
         if (await Db.People.AnyAsync(u => u.Email == register.Email))
             throw new ValidationException("Email already exists");
         
         var newPerson = new Person
         {
             Firstname = register.Firstname,
             Lastname = register.Lastname,
             Email = register.Email,
             Phone = register.Phone
         };
         
         Db.People.Add(newPerson);
         await Db.SaveChangesAsync();
         
         var salt = BCryptHelper.GenerateSalt(10);
         var hashedPassword = BCryptHelper.HashPassword(register.Password, salt);
         var user = new User
         {
             PersonId = newPerson.PersonId,
             Password = hashedPassword,
             PasswordSalt = salt,
             RoleId = (int) role
         };
         Db.Users.Add(user);
         await Db.SaveChangesAsync();
         return newPerson.PersonId;       
    }
}