using System;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        //public IFormFile file{ get; set; }
    }
}

