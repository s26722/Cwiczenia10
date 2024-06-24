using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication2.Configs;

public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(p => p.IdPrescription).HasName("IdPrescripton_pk");
        builder.Property(p => p.Date).IsRequired();
        builder.Property(p => p.DueDate).IsRequired();
       


        builder.HasOne(pa => pa.Patient)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(pa => pa.IdPatient)
            .HasConstraintName("Prescription_Patient")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(d => d.Doctor)
            .WithMany(p => p.Prescriptions)
            .HasForeignKey(d => d.IdDoctor)
            .HasConstraintName("Prescription_Doctor")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.ToTable("Prescription");
    }
}