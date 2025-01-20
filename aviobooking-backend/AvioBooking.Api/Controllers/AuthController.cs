using Application.Abstractions.Authentication;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Application.DTOs.Auth;
using Application.Abstractions.Services;

namespace AvioBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserService _userService;
        private readonly IUserContext _userContext;

        public AuthController(
            ITokenProvider tokenProvider,
            IPasswordHasher passwordHasher,
            IUserService userService,
            IUserContext userContext)
        {
            _tokenProvider = tokenProvider;
            _passwordHasher = passwordHasher;
            _userService = userService;
            _userContext = userContext;
        }

        // POST: api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Application.DTOs.Auth.RegisterRequest request)
        {
            if (await _userService.ExistsByEmail(request.Email))
                return Conflict("Email already in use.");

            var hashedPassword = _passwordHasher.Hash(request.Password);

            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Password = hashedPassword,
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                Type = request.Type
            };

            await _userService.CreateAsync(user);

            return CreatedAtAction(nameof(GetCurrentUser), new { id = user.Id }, user.Id);
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Application.DTOs.Auth.LoginRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
                return Unauthorized("Invalid credentials.");

            var token = _tokenProvider.Create(user);

            return Ok(new { Token = token });
        }

        // GET: api/auth/me
        [HttpGet("me")]
        [Authorize]
        public IActionResult GetCurrentUser()
        {
            var userId = _userContext.UserId;
            return Ok(new { UserId = userId });
        }
    }
}
