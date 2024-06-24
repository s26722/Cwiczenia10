using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.Models;

namespace WebApplication2.Configs;

public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(m => m.IdMedicament).HasName("IdMedicament_pk");
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Description).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Type).IsRequired().HasMaxLength(100);


        builder.ToTable("Medicament");
        Medicament[] medicaments =
        {
            new Medicament { IdMedicament = 1, Name = "Ibuprom", Description = "Na bol glowy", Type = "Kapsulki" },
            new Medicament { IdMedicament = 2, Name = "Syrop", Description = "Na kaszel", Type = "Plyn" }
        };
        builder.HasData(medicaments);


    }
}