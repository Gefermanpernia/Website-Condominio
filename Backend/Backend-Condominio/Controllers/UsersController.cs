using Backend_Condominio.DTOs.User;
using Backend_Condominio.Entities;
using Backend_Condominio.Repositories;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Threading.Tasks;

namespace Backend_Condominio.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly UserRepository userRepository;

        public UsersController(UserManager<User> userManager,
            UserRepository userRepository)
        {
            this.userManager = userManager;
            this.userRepository = userRepository;
        }

        [HttpPost("userRole")]
        public async Task<ActionResult> SetRole(SetRoleDTO setRoleDTO)
        {
            var user = await userManager.FindByIdAsync(setRoleDTO.UserId);

            if (user == null)
            {
                return NotFound();
            }

            try
            {
                var result = await userManager.AddToRoleAsync(user, setRoleDTO.RoleName);
                if (result.Succeeded)
                {

                    return NoContent();
                }
                return BadRequest(result.Errors);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost("profile")]
        public async Task<ActionResult> UpdateData(UpdateDataDTO updateDataDTO)
        {
            var result = await userRepository.UpdateProfile(updateDataDTO);
            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }
        [HttpDelete("{UserId}/{roleName}")]
        public async Task<ActionResult> DeleteRol([FromRoute] string UserId, string roleName)
        {
            var user = await userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }
            var result = await userManager.RemoveFromRoleAsync(user, roleName);
            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result.Errors);
        }

        [HttpGet("profile/{UserId}")]
        public async Task<ActionResult<UserDTO>> GetUser([FromRoute] string UserId)
        {

            var user = await userRepository.GetUser(UserId);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
        [HttpPost("profile/{UserId}")]
        public async Task<ActionResult> ChangePassword([FromRoute] string UserId, UserPasswordDTO userPasswordDTO)
        {

            var user = await userManager.FindByIdAsync(UserId);
            if (user == null)
            {
                return NotFound();
            }

            var result = await userManager.ChangePasswordAsync(user, userPasswordDTO.CurrentPassword, userPasswordDTO.NewPassword);
            if (result.Succeeded)
            {
                return NoContent();
            }
            return BadRequest(result.Errors);
        }
    }
}

