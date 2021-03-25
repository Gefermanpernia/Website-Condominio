
using Backend_Condominio.DTOs.Auth;
using Backend_Condominio.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public AccountsController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult<TokenResponse>> Register(RegisterDTO registerDTO)
        {
            var user = new User
            {
                UserName = registerDTO.Email,
                Email = registerDTO.Email,
                FullName = registerDTO.FullName
            };

            var result = await userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                return await BuildLoginToken(user);
            }

            return BadRequest(result.Errors);
        }

        private async Task<TokenResponse> BuildLoginToken(User user)
        {

            if(user==null)
            {
                return null;
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };

            var roles =await userManager.GetRolesAsync(user);

            for(int i = 0; i < roles.Count; i++)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var sigInkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["auth:key"]));

            var creds = new SigningCredentials(sigInkey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(60);

            JwtSecurityToken token = new(
               issuer: null,
               audience: null,
               claims: claims,
               expires: expiration,
               signingCredentials: creds);

            return new TokenResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponse>> Login(LoginDTO loginDTO)
        {
            var user = await userManager.FindByEmailAsync(loginDTO.Email);
            if (user != null)
            {
               var result = await signInManager.PasswordSignInAsync(user, loginDTO.Password, false, true);
                if (result.Succeeded)
                {
                        return await BuildLoginToken(user);
                }
                if (result.IsLockedOut)
                {
                    if (user.LockoutEnd.HasValue)
                    {
                        var remaintime = user.LockoutEnd - DateTime.Now;
                        return BadRequest($"Espere { remaintime.Value.TotalMinutes:N2)} minutos");
                    }
                }
            }
            return BadRequest("Credenciales invalidas");
        }
    }
}
