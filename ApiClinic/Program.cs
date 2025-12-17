using EFMedical.Models;                 // Подключение пространства имён с моделями и DbContext
using Microsoft.EntityFrameworkCore;    // Подключение Entity Framework Core

// Создание билдера приложения ASP.NET Core
// builder содержит настройки сервисов и конфигурации приложения
var builder = WebApplication.CreateBuilder(args);

// =========================
// Регистрация сервисов
// =========================

// Добавляем поддержку контроллеров (Web API)
builder.Services.AddControllers();

// Регистрируем ClinicContext в контейнере зависимостей
// Указываем, что будем использовать SQL Server
// Строка подключения указывает на локальную базу данных LocalDB
builder.Services.AddDbContext<ClinicContext>(options =>
    options.UseSqlServer(
        @"Server=(localdb)\mssqllocaldb;Database=ClinicDB;Trusted_Connection=True;"
    )
);

// =========================
// Сборка приложения
// =========================
var app = builder.Build();

// =========================
// Конфигурация конвейера HTTP-запросов (Middleware)
// =========================

// Здесь могли бы быть:
// app.UseHttpsRedirection();
// app.UseAuthentication();
// app.UseAuthorization();

// =========================
// Маршрутизация контроллеров
// =========================

// Подключаем маршруты контроллеров (атрибуты [HttpGet], [HttpPost] и т.д.)
app.MapControllers();

// =========================
// Запуск приложения
// =========================

// Приложение начинает слушать входящие HTTP-запросы
app.Run();
