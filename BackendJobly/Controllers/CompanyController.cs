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

namespace BackendJobly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private ICompanyService _companyService;
        //[Obsolete]
        public IHostingEnvironment _hostingEnvironment;

        public CompanyController(ICompanyService companyService, IWebHostEnvironment webHostEnvironment, IHostingEnvironment hostingEnvironment)
        {
            _companyService = companyService;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
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
        //public ActionResult<string> UploadImages(IFormFile uploadFile)
        //{
        //    try
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        if (files!=null && files.Count>0)
        //        {
        //            foreach (var file in files)
        //            {
        //                FileInfo fi = new FileInfo(file.FileName);
        //                var newFileName = "Image" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
        //                var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "/Images/" + newFileName);
        //                using(var stream = new FileStream(path, FileMode.Create))
        //                {
        //                    file.CopyTo(stream);
        //                }
        //                Image image = new Image();
        //                image.Name = path;
        //            }
        //            return "Uğurla əlavə edildi";
        //        }
        //        else
        //        {
        //            return "Xəta Baş Verdi!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}
    }
}

