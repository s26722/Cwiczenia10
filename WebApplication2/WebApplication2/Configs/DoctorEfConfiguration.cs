using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Configs;

public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.IdDoctor).HasName("IdDoctor_pk");
        builder.Property(d => d.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(d => d.LastName).IsRequired().HasMaxLength(100);
        builder.Property(d => d.Email).IsRequired().HasMaxLength(100);


        builder.ToTable("Doctor");

        Doctor[] doctors =
        {
            new Doctor { IdDoctor = 3, FirstName = "Maciek", LastName = "Kowalski", Email = "maciekkowal23@wp.pl" },
            new Doctor { IdDoctor = 4, FirstName = "Andrzej", LastName = "Nowak", Email = "andrzejnowl27@wp.pl" }
        };
        builder.HasData(doctors);
    }
    
}