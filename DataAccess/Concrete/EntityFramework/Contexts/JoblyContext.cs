using System;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class JoblyContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BackendJoblyApi;User Id=sa;Password=MyPass@word");
        }

        
        //public DbSet<Category> Categories { get; set; }
        
        
        
    }
}

