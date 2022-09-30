using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        List<Vacancy> Vacancy { get; set; }
        public string? Path { get; set; }
    }
}

