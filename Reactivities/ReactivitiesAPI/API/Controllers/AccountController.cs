using API.DTOs;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly UserManager<AppUser> _userManager;
        public readonly SignInManager<AppUser> _signInManager;
        public readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            AppUser user = await _userManager.Users.Include(p=>p.Photos)
                .FirstOrDefaultAsync(x=>x.Email ==loginDto.Email);
            if (user == null) return Unauthorized();

            var result = _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(result.IsCompletedSuccessfully)
            {
                return CreateUserObject(user);
            }
            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if(await _userManager.Users.AnyAsync(x=>x.Email == registerDto.Email))
            {
                return BadRequest("Email taken");
            }
            if(await _userManager.Users.AnyAsync(x=>x.UserName == registerDto.UserName))
            {
                return BadRequest("Username taken");
            }

            var user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                //PasswordHash = registerDto.Password
            };

            await _userManager.AddPasswordAsync(user, registerDto.Password);
            var result = await _userManager.CreateAsync(user);
            if(result.Succeeded)
            {
                return CreateUserObject(user);
            }
            return BadRequest("Problem in regestring user");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.Users.Include(p=>p.Photos)
                .FirstOrDefaultAsync(x=>x.Email == User.FindFirstValue(ClaimTypes.Email));
            return CreateUserObject(user);
        }

        private UserDto CreateUserObject(AppUser user)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Image = user?.Photos?.FirstOrDefault(x=>x.IsMain)?.Url,
                Token = _tokenService.CrateToken(user),
                UserName = user.UserName
            };
        }
    }
}
