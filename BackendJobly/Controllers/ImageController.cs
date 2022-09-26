using System;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BackendJobly.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private IImageService _cityService;

        public ImageController(IImageService cityService)
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
        public IActionResult Add(Image city)
        {
            var result = _cityService.Add(city);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Image city, int id)
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
            var result = _cityService.Delele(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

