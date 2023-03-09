using Microsoft.EntityFrameworkCore;
using ruleta_api.Data;
using ruleta_api.Mapper;
using ruleta_api.Repository;
using ruleta_api.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Configurar conexion a base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSQL"));
});

// Agregar repositorios
builder.Services.AddScoped<IBetRepository, BetRepository>();

// Agregar mapper
builder.Services.AddAutoMapper(typeof(Mapper));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(p => p.AddPolicy("PolicyCors", build =>
{
    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PolicyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
