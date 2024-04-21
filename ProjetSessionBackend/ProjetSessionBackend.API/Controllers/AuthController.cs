// using System.IdentityModel.Tokens.Jwt;
// using System.Text;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.IdentityModel.Tokens;
// using ProjetSessionBackend.Core.Interfaces.Repositories;
// using ProjetSessionBackend.Core.Models.DTOs;
// using ProjetSessionBackend.Core.Models.Entities;
//
// namespace ProjetSessionBackend.API.Controllers;
//
// [ApiController]
// [Route("[controller]")]
// public class AuthController: ControllerBase
// {
//     private readonly IAuthRepository _repository;
//     private readonly IConfiguration _configuration;
//     
//     public AuthController(IAuthRepository repository, IConfiguration configuration)
//     {
//         _repository = repository;
//         _configuration = configuration;
//     }
//     
//     [HttpPost]
//     [Route("/login")]
//     public async Task<IActionResult> Login([FromBody] UserLoginResponse userLoginDto)
//     {
//         var user = await _repository.Login(userLoginDto);
//         if (user == null) return Unauthorized();
//
//         var tokenString = GenerateJsonWebToken();
//         return  Ok(new { token = tokenString });
//     }
//
//     [HttpPost]
//     [Route("/register")]
//     public ActionResult<UserResponse> Register([FromBody] User user)
//     {
//         if (user == null)
//         {
//             return BadRequest("User is null");
//         }
//         var response = _repository.Register(user);
//         return Ok(response);
//     }
//     
//     private string GenerateJsonWebToken()
//     {
//         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
//
//         var token = new JwtSecurityToken(
//             _configuration["Jwt:Issuer"],
//             _configuration["Jwt:Issuer"],
//             null,
//             expires: DateTime.Now.AddMinutes(120),
//             signingCredentials: credentials);
//         
//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }
// }