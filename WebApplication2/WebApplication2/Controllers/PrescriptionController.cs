using Microsoft.AspNetCore.Mvc;
using WebApplication2.Configs;
using WebApplication2.Context;
using WebApplication2.Models;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PrescriptionController : ControllerBase
{
    private readonly ApbdDbContext _context;

    public PrescriptionController(ApbdDbContext context)
    {
        _context = context;
    }
    
    
    [HttpPost]
    public async Task<IActionResult> CreatePrescription([FromBody] Prescription prescription)
    {
       
        var patient = await _context.Patients.FindAsync(prescription.IdPatient);
        if (patient == null)
        {
           
            patient = new Patient
            {
                FirstName = prescription.Patient.FirstName,
                LastName = prescription.Patient.LastName,
                Birthdate = prescription.Patient.Birthdate
            };
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            prescription.IdPatient = patient.IdPatient;
        }

       
        var doctor = await _context.Doctors.FindAsync(prescription.IdDoctor);
        if (doctor == null)
        {
            return BadRequest("Lekarz nie istnieje.");
        }

        
        if (prescription.Prescription_Medicaments.Count > 10)
        {
            return BadRequest("Recepta może obejmować maksymalnie 10 leków.");
        }

        foreach (var pm in prescription.Prescription_Medicaments)
        {
            var medicament = await _context.Medicaments.FindAsync(pm.IdMedicament);
            if (medicament == null)
            {
                return BadRequest($"Lek z Id {pm.IdMedicament} nie istnieje.");
            }
        }

       
        if (prescription.DueDate < prescription.Date)
        {
            return BadRequest("DueDate nie może być wcześniejszy niż Date.");
        }

        
        _context.Prescriptions.Add(prescription);
        await _context.SaveChangesAsync();

        return Ok(prescription);
    }
}
}