using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Entities.Concrete;
using Entities.Models;

namespace Entities.Concrete
{
    public class Vacancy : BaseEntity,IEntity
    {

        public Vacancy()
        {
            Users = new List<User>();
        }
        public string Name { get; set; }
        public City? City { get; set; }
        public int? CityId { get; set; }
        public DateTime? Deadline { get; set; }
        public string TypeOfwork { get; set; }
        public string VəzifəÖhdəlikləri { get; set; }
        public string Tələblər { get; set; }
        public int Salary { get; set; }
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }
        public Company? Company { get; set; }
        public int? CompanyId { get; set; }
        //public int UserId { get; set; }
        List<User> Users { get; set; }
    }
}

