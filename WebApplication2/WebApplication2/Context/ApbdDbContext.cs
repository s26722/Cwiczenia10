using Microsoft.EntityFrameworkCore;
using WebApplication2.Configs;
using WebApplication2.Models;

namespace WebApplication2.Context;

public class ApbdDbContext :DbContext
{
    public virtual DbSet<Medicament> Medicaments { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Prescription> Prescriptions { get; set; }
    public ApbdDbContext()
    {
    }

    public ApbdDbContext(DbContextOptions<ApbdDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicamentEfConfiguration).Assembly);
      
     

    }
    
}