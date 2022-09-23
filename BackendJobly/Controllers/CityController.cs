using System;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BackendJobly.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _cityService.Get(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _cityService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        //[Authorize(Roles ="Admin")]
        [HttpPost("add")]
        public IActionResult Add(City city)
        {
            var result = _cityService.Add(city);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(City city, int id)
        {
            var result = _cityService.Update(city, id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromQuery, FromBody] int id)
        {
            var result = _cityService.Delete(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

