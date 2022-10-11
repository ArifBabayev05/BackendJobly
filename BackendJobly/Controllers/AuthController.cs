using System;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackendJobly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDTO)
        {
            var userToLogin = _authService.Login(userForLoginDTO);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }



            if (userToLogin.Success)
            {
                return Ok(userToLogin.Data);
            }
            else
            {
                return BadRequest(userToLogin.Message);
            }
        }
        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDTO)
        {
            var userExist = _authService.UserExists(userForRegisterDTO.Email);
            if (!userExist.Success)
            {
                return BadRequest(userExist.Message);
            }
            var registeResult = _authService.Register(userForRegisterDTO, userForRegisterDTO.Password);
            if (registeResult.Success)
            {
                return Ok(registeResult.Data);
            }
            return BadRequest(registeResult.Message);



        }
    }
}

