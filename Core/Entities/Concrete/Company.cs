using System;
using System.Collections.Generic;
using Core.Entities;
using Entities.Concrete;

namespace Entities.Models
{
    public class Company : IEntity
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
        List<Vacancy> Vacancy { get; set; }
        public int VacancyId { get; set; }
    }
}

