using EFMedical.Models;                     // Подключение моделей (Patient, ClinicContext и др.)
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;              // Атрибуты и базовые классы для Web API
using Microsoft.EntityFrameworkCore;         // Работа с Entity Framework Core
using Microsoft.Identity.Client.Extensions.Msal;

namespace ApiClinic.Controllers
{
    // Указываем, что это API-контроллер
    // Маршрут будет: api/Patient
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        // Контекст базы данных (Entity Framework)
        private ClinicContext db;

        // Конструктор контроллера
        // Через Dependency Injection получаем контекст БД
        public PatientController(ClinicContext _db)
        {
            db = _db;
        }

        // =========================
        // GET: api/Patient
        // Получение списка всех пациентов
        // =========================
        [HttpGet]
        public IActionResult GetPatients()
        {
            // Получаем всех пациентов из базы данных
            var patients = db.Patients.ToList();

            // Возвращаем список пациентов с кодом 200 (OK)
            return Ok(patients);
        }

        // =========================
        // GET: api/Patient/{id}
        // Получение пациента по идентификатору
        // =========================
        [HttpGet("{id}")]
        public IActionResult GetPatientById(int id)
        {
            // Ищем пациента по PatientId
            var patients = db.Patients
                .Where(p => p.PatientId == id)
                .ToList();

            // Если пациент не найден — возвращаем 404 (NotFound)
            if (patients == null || patients.Count == 0)
                return NotFound();

            // Если найден — возвращаем данные пациента
            return Ok(patients);
        }

        // =========================
        // POST: api/Patient
        // Создание нового пациента
        // =========================
        [HttpPost]
        public IActionResult Create(Patient newPatient)
        {
            // Добавляем нового пациента в контекст БД
            db.Patients.Add(newPatient);

            // Сохраняем изменения в базе данных
            db.SaveChanges();

            // Возвращаем созданного пациента и статус 200 (OK)
            return Ok(newPatient);
        }

        // =========================
        // PUT: api/Patient
        // Обновление данных пациента
        // =========================
        [HttpPut]
        public IActionResult EditPatient(Patient newPatient)
        {
            // Ищем пациента в базе по его ID
            var p = db.Patients.FirstOrDefault(p => p.PatientId == newPatient.PatientId);

            // Если пациент не найден — возвращаем 404
            if (p == null)
                return NotFound();

            // Обновляем данные пациента
            p.FullName = newPatient.FullName;
            p.Address = newPatient.Address;
       

            // Сохраняем изменения в базе данных
            db.SaveChanges();

            // Возвращаем обновлённого пациента
            return Ok(newPatient);
        }


        [HttpDelete("{id}")]
        public IActionResult DelPatientById(int id)
        {
            // Ищем пациента по PatientId
            var p = db.Patients.FirstOrDefault(p => p.PatientId == id);

            // Если пациент не найден — возвращаем 404 (NotFound)
            if (p == null)
                return NotFound();

            db.Patients.Remove(p);
            db.SaveChanges();

            // Если найден — возвращаем данные пациента
            return Ok(p);
        }
    }
}
