using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Entities.Models
{
    public class Company :BaseEntity, IEntity
    {
        public Company()
        {
            Vacancy = new List<Vacancy>();
        }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string TelNumber { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }
        
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        List<Vacancy> Vacancy { get; set; }
         
    }
}

