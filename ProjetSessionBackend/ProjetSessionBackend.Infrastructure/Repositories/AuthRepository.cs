using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;
using ProjetSessionBackend.Core;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Models.DTOs;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.Infrastructure.Repositories;

public class AuthRepository: BaseRepository, IAuthRepository
{
    public AuthRepository(IMapper mapper) : base(mapper)
    {
    }

    public async Task<int> Register(RegisterResponse register)
    {
        if (await Db.People.AnyAsync(u => u.Email == register.Email))
        {
            throw new ValidationException("Email already exists");
        }
        
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
            RoleId = 2
        };
        Db.Users.Add(user);
        await Db.SaveChangesAsync();
        return 1;
    }

    public async Task<Person?> Login(UserLoginResponse userLoginResponse)
    {
        var person = await Db.People.Include(x => x.User).ThenInclude(x => x.Role).SingleOrDefaultAsync(x => x.Email == userLoginResponse.Email);

        if (person == null) return null;
        
        return BCryptHelper.CheckPassword(userLoginResponse.Password, person.User.Password) ? person : null;
    }
}