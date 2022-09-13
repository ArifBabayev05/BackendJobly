using System;
using Business.Abstract;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace BackendJobly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ICompanyService _companyService;

        public CompanyController(ICompanyService companyService, IWebHostEnvironment webHostEnvironment)
        {
            _companyService = companyService;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _companyService.Get(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _companyService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);

        }

        [HttpPost("add")]
        public IActionResult Add(Company company)
        {
            //string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets", company.ImageFile.FileName);
            var result = _companyService.Add(company);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Company company,int id)
        {
            var result = _companyService.Update(company, id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromQuery, FromBody] int id)
        {
            var result = _companyService.Delele(id);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        //[HttpPost("fileUpload")]
        //public IActionResult UploadFile()
        //{
        //    //var ctx = HttpContext.
        //    return Ok("sa");
        //}
    }
}

