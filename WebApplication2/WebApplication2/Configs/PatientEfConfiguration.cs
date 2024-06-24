using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Configs;

public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p => p.IdPatient).HasName("IdPatient_pk");
        builder.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.LastName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.FirstName).IsRequired();

        builder.ToTable("Patient");
        
        Patient [] patients =
        {
            new Patient { IdPatient = 1, FirstName = "Adam", LastName = "Kowalski",Birthdate = new DateTime(1999,7,7)},
            new Patient { IdPatient = 2, FirstName = "Alicja", LastName = "Nowak",Birthdate = new DateTime(1996,2,12)} 
        };
        builder.HasData(patients);
    }
}