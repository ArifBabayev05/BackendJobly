using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Company : BaseEntity,IEntity
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string TelNumber { get; set; }
        public Image Image { get; set; }
        public int ImageId { get; set; }
        public Vacancy Vacancy { get; set; }
        public int VacancyId { get; set; }


    }
}

