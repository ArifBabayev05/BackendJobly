using System;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Utilities.Abstract;
using Utilities.DTO;

namespace BackendJobly.Controllers
{
    public class AuthanticationController
    {
        private IAuthRepository _authRepository;
        private IConfiguration _configuration;

        public AuthanticationController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            //var userToCreate = new User
            //{
            //    FirstName = userForRegisterDto.FirstName
            //};

            //var createdUser = await _authRepository.Register(userToCreate,userForRegisterDto.Password);
            ////return StatusCodes()
            throw new ArgumentNullException();
            

            
        }
    }
}

