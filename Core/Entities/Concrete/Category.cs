using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            Vacancy = new List<Vacancy>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public int VacancyId { get; set; }
        List<Vacancy> Vacancy { get; set; }
    }
}

