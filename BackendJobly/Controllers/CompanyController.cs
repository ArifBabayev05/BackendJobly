using System;
using Business.Abstract;
using Entities.Concrete;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Migrations;

namespace BackendJobly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ICompanyService _companyService;
        private IImageService _imageSerivce;
        //[Obsolete]
        public IWebHostEnvironment _hostingEnvironment;

        public CompanyController(ICompanyService companyService, IWebHostEnvironment webHostEnvironment, IWebHostEnvironment hostingEnvironment, IImageService imageSerivce)
        {
            _companyService = companyService;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
            _imageSerivce = imageSerivce;
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
        public IActionResult Add([FromForm] Company company)
        {
           
            string fileName = Guid.NewGuid().ToString() + company.ImageFile.FileName;
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "assets", fileName);

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                company.ImageFile.CopyToAsync(fs);
            }
            Image image = new Image();
            image.Name = fileName;
            _imageSerivce.Add(image);

            company.ImageId = image.Id;
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
        
    }
}

