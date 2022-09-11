using System;
using System.Collections.Generic;
using Core.Entities;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        //public Image Image { get; set; }
        //public int ImageId { get; set; }
        //public string Subtitle { get; set; }
        List<Vacancy> Vacancy { get; set; }
    }
}

