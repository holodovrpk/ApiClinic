using EFMedical.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.Extensions.Msal;

namespace ApiClinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private ClinicContext  db;
        public PatientController(ClinicContext _db)
        {
            db = _db;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = db.Patients.ToList();

            return Ok(patients);
        }


        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            var patients = db.Patients
                .Where(p => p.PatientId == id)
                .ToList();

            if (patients == null)
                return NotFound();

            return Ok(patients);
        }

        [HttpPost] // обработка POST-запроса: /api/books
        public IActionResult Create(Patient newPatient)
        {
            db.Patients.Add(newPatient);
            db.SaveChanges();
            
            return Ok(newPatient);     // возвращаем созданную книгу (200 OK)
        }

        [HttpPut]
        public IActionResult EditPatient(Patient newPatient)
        {
            var p = db.Patients.FirstOrDefault(p => p.PatientId == newPatient.PatientId);

            p.FullName = newPatient.FullName;

            
            db.SaveChanges();

            return Ok(newPatient);     // возвращаем созданную книгу (200 OK)
        }


    }
}
