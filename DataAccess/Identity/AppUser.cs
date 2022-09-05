using System;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Identity
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

