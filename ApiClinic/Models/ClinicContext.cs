using Microsoft.EntityFrameworkCore;    // Подключение Entity Framework Core

namespace EFMedical.Models
{
    // =========================
    // Контекст базы данных (DbContext)
    // =========================
    // Этот класс является "мостом" между приложением и базой данных.
    // Через него выполняются все операции:
    //  - чтение данных
    //  - добавление
    //  - обновление
    //  - удаление
    // Entity Framework автоматически сопоставляет классы с таблицами БД.
    public class ClinicContext : DbContext
    {
        // =========================
        // DbSet<T> — представление таблиц в базе данных
        // =========================

        // Таблица Doctors (врачи)
        // Каждая запись таблицы соответствует объекту класса Doctor
        public DbSet<Doctor> Doctors { get; set; }

        // Таблица Patients (пациенты)
        // Используется для CRUD-операций над пациентами
        public DbSet<Patient> Patients { get; set; }

        // Таблица Appointments (приёмы / записи на приём)
        // Связывает врача и пациента
        public DbSet<Appointment> Appointments { get; set; }

        // Таблица Users (пользователи системы)
        // Может использоваться для авторизации / ролей
        public DbSet<User> Users { get; set; }

        // =========================
        // Конструктор контекста базы данных
        // =========================
        // DbContextOptions содержит настройки:
        //  - строку подключения
        //  - тип базы данных (SQL Server)
        //  - дополнительные параметры EF Core
        //
        // Эти настройки передаются из Program.cs
        public ClinicContext(DbContextOptions<ClinicContext> options)
            : base(options)
        {
            // Внутри конструктора обычно ничего не пишут
            // Вся настройка происходит через options
        }
    }
}
