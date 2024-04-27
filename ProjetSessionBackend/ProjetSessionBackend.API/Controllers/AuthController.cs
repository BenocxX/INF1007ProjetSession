using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetSessionBackend.Core.Interfaces.Repositories;
using ProjetSessionBackend.Core.Interfaces.Services;
using ProjetSessionBackend.Core.Models.DTOs.Auth;
using ProjetSessionBackend.Core.Models.Entities;

namespace ProjetSessionBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;

        public AuthController(IMapper mapper, IAuthService authService, IUserRepository userRepository)
        {
            _mapper = mapper;
            _authService = authService;
            _userRepository = userRepository;
        }
        
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetUserByEmail(loginRequest.Email);
            if (user == null)
                return Unauthorized();
            
            var authResponse = _authService.Login(user, loginRequest.Password);
            if (authResponse == null)
                return Unauthorized();
            
            return Ok(authResponse);
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<AuthResponse>> Register(RegisterRequest registerRequest)
        {
            var user = await _userRepository.GetUserByEmail(registerRequest.Email);
            if (user != null)
                return BadRequest("Email already exists");

            var userToRegister = _mapper.Map<User>(registerRequest);
            var authResponse = await _authService.Register(userToRegister);
            
            return Ok(authResponse);
        }
    }
}
