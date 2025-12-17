using Microsoft.EntityFrameworkCore;

namespace EFMedical.Models
{
    // Класс контекста базы данных — основной мост между приложением и SQL-базой
    public class ClinicContext : DbContext
    {
        // Таблица врачей
        public DbSet<Doctor> Doctors { get; set; }

        // Таблица пациентов
        public DbSet<Patient> Patients { get; set; }

        // Таблица приёмов
        public DbSet<Appointment> Appointments { get; set; }

        // Таблица пользователей 
        public DbSet<User> Users { get; set; }



        // Конструктор контекста
        
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {

        }
    }
}
