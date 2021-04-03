
using Backend_Condominio.DTOs.Auth;
using Backend_Condominio.DTOs.Mail;
using Backend_Condominio.Entities;
using Backend_Condominio.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        private readonly IMailSender _mailSender;

        public AccountsController(SignInManager<User> signInManager,
            UserManager<User> userManager,
            IConfiguration configuration, IMailSender mailSender)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._configuration = configuration;
            _mailSender = mailSender;
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

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (result.Succeeded)
            {
                return await BuildLoginToken(user);
            }

            return BadRequest(result.Errors);
        }

        private async Task<TokenResponse> BuildLoginToken(User user)
        {

            if (user == null)
            {
                return null;
            }
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);

            for (int i = 0; i < roles.Count; i++)
            {
                claims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var sigInkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["auth:key"]));

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
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginDTO.Password, false, true);
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

        [HttpPost("reset-password")]
        public async Task<ActionResult> ResetPassword(EmailDTO emailDTO)
        {
            var user = await _userManager.FindByEmailAsync(emailDTO.Email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var id = user.Id;

                var url = $"http://localhost:4200/reset-password?token={ HttpUtility.UrlEncode(token)}&id={HttpUtility.UrlEncode(id)}";

                await _mailSender.Send(
                    new MailRequest
                    {
                        Title = "Reset password",
                        Body = $"para cambiar tu password {url}",
                        Destination = emailDTO.Email
                    });
            }
            return NoContent();
        }

        [HttpPost("confirmed-password")]
        public async Task<ActionResult> ConfirmedPassword(ConfirmedUserPasswordDTO confirmedUserPasswordDTO)
        {
            var user = await _userManager.FindByIdAsync(confirmedUserPasswordDTO.UserId);

            if (user == null)
            {
                return NotFound();
            }
            var token = HttpUtility.UrlDecode(confirmedUserPasswordDTO.Token);

            var result = await _userManager.ResetPasswordAsync(user, token, confirmedUserPasswordDTO.Password);
            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}

    
    


