using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Image : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

