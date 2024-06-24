﻿using WebApplication2.Configs;

namespace WebApplication2.Models;

public class Patient
{
    public int IdPatient { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    
    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}