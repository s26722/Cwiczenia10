using WebApplication2.Models;

namespace WebApplication2.Configs;

public class Prescription
{
    public int IdPrescription { get; set; }
    public int IdPatient { get; set; }
    public int IdDoctor { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public virtual Patient Patient { get; set; }
    public virtual Doctor Doctor { get; set; }
    
}