using System;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Configurations
{
    public class VacancyConfiguration : IEntityTypeConfiguration<Vacancy>
    {

        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.Property(n => n.CreatedDate)
                .IsRequired(true)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}

