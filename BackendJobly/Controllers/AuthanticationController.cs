using System;
using System.Threading.Tasks;
using Business.Constants;
using Core.Entities.Concrete;
using DataAccess.Identity;
using Entities.Dtos.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Utilities.Abstract;
using Utilities.DTO;

namespace BackendJobly.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthanticationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppUser> _roleManager;

        public AuthanticationController(UserManager<AppUser> userManager,
                                        SignInManager<AppUser> signInManager,
                                        RoleManager<AppUser> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }



            
        [HttpGet("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            AppUser appUser = new AppUser();
            appUser.FirstName = registerDTO.FirstName;
            appUser.LastName = registerDTO.LastName;
            appUser.Email = registerDTO.Email;
            appUser.UserName = registerDTO.Email;

            var result = await _userManager.CreateAsync(appUser, registerDTO.Password);

            if (!result.Succeeded)
            {
                string error = "";
                foreach (var item in result.Errors)
                {
                    error += item.Description += "\n";
                }
                return StatusCode(StatusCodes.Status404NotFound, Messages.UserNotFound);
            }
            return Ok();


        }
    }
}

