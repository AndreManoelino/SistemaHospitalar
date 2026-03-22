using Npgsql.EntityFrameworkCore.PostgreSQL;
using Hospital.API.Data;
using Microsoft.EntityFrameworkCore;
using Hospital.API.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<PasswordService>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers(); // 🔥 ADD ISSO

app.MapGet("/", () => "API Hospital rodando 🚀");

app.Run();