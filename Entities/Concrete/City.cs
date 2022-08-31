using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        public int Name { get; set; }
    }
}

