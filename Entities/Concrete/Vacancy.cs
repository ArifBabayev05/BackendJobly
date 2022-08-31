using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Vacancy : BaseEntity,IEntity
    {
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public DateTime? Deadline { get; set; }
        public string TypeOfwork { get; set; }
        public string VəzifəÖhdəlikləri { get; set; }
        public string Tələblər { get; set; }
        public int Salary { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}

