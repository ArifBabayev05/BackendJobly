using System;
using System.IO;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendJobly.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private IImageService _cityService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        [Obsolete]
        public IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public ImageController(IImageService cityService, IWebHostEnvironment webHostEnvironment, IHostingEnvironment hostingEnvironment)
        {
            _cityService = cityService;
            _webHostEnvironment = webHostEnvironment;
            _hostingEnvironment = hostingEnvironment;
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

     
        //[HttpPost("add")]
        //public ActionResult<string> Add(Image city, [FromForm] IFormFile formFile)
        //{
        //    var result = _cityService.Add(city);
        //    if (result.Success)
        //    {
        //        return Ok(result.Message);
        //    }
        //    return BadRequest(result.Message);
        //    //if (true) {
        //    //    var files = HttpContext.Request.Form.Files;
        //    //    if (files != null && files.Count > 0)
        //    //    {
        //    //        foreach (var file in files)
        //    //        {
        //    //            FileInfo fi = new FileInfo(file.FileName);
        //    //            var newFileName = "Image" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
        //    //            var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "/Images/" + newFileName);
        //    //            using (var stream = new FileStream(path, FileMode.Create))
        //    //            {
        //    //                file.CopyTo(stream);
        //    //            }
        //    //            Image image = new Image();
        //    //            image.Name = path;
        //    //        }
        //    //        return Ok("Uğurla əlavə edildi");
        //    //    }
        //    //    else
        //    //    {
        //    //        return Ok("Xəta Baş Verdi!");
        //    //    }

        //    //}

        //}
        ////[HttpPost("upload")]
        ////[Authorize(Roles ="Admin")]
        //[Consumes("multipart/form-data")]
        //[NonAction]
        //public ActionResult<string> UploadImage([FromForm] IFormFile formFile)
        //{

        //    if (true)
        //    {
        //        var files = HttpContext.Request.Form.Files;
        //        if (files != null && files.Count > 0)
        //        {
        //            foreach (var file in files)
        //            {
        //                FileInfo fi = new FileInfo(file.FileName);
        //                var newFileName = "Image" + DateTime.Now.TimeOfDay.Milliseconds + fi.Extension;
        //                var path = Path.Combine("", _hostingEnvironment.ContentRootPath + "/Images/" + newFileName);
        //                using (var stream = new FileStream(path, FileMode.Create))
        //                {
        //                    file.CopyTo(stream);
        //                }
        //                Image image = new Image();
        //                image.Name = path;
        //            }
        //            return Ok("Uğurla əlavə edildi");
        //        }
        //        else
        //        {
        //            return Ok("Xəta Baş Verdi!");
        //        }

        //    }

        //}



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

