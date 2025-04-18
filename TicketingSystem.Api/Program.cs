using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TicketingSystem.Application.Interfaces;
using TicketingSystem.Application.Services;
using TicketingSystem.Persistence.Context;
using TicketingSystem.Domain.Models;
using TicketingSystem.Repositories.Interfaces;
using TicketingSystem.Repositories.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// ---------------- MSSQL - EF Core ----------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------- MongoDB ----------------
//builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
//builder.Services.AddSingleton<IMongoDbContext, MongoDbContext>();
//builder.Services.AddScoped<IMongoRepository<PaymentInfo>, MongoRepository<PaymentInfo>>();
//builder.Services.AddScoped<IMongoRepository<EventFeedback>, MongoRepository<EventFeedback>>();

// ---------------- Repository & Service Layer ----------------
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

// Eğer özel servisler varsa (örnek IEventService gibi), burada tanımlayabilirsin:
// builder.Services.AddScoped<IEventService, EventService>();

// ---------------- Controller & Swagger ----------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ---------------- Middleware Pipeline ----------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
