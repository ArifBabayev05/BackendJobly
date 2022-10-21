using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {

        public User()
        {
            Vacancies = new List<Vacancy>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        //List<UserOperationClaim> userOperationClaims;
        List<Vacancy> Vacancies { get; set; }
        //public int VacancyId { get; set; }
    }
}

