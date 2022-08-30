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

            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.Success)
            {
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
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
            var result = _authService.CreateAccessToken(registeResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);



        }
    }
}

