using Hospital.API.Data;
using Microsoft.EntityFrameworkCore;
using Hospital.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//  JWT Settings
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

//  VALIDAÇÃO DA CHAVE (REMOVE WARNING E EVITA ERRO)
var secretKey = jwtSettings["SecretKey"] 
    ?? throw new Exception("JWT SecretKey não configurada no appsettings.json");

//  Controllers
builder.Services.AddControllers();

//  Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Services
builder.Services.AddScoped<PasswordService>();
builder.Services.AddScoped<TokenService>();

//  Banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

//  JWT Config
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secretKey)
        )
    };
});

var app = builder.Build();

//  Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//  ESSENCIAL
app.UseAuthentication();
app.UseAuthorization();

//  Controllers
app.MapControllers();

//  Teste
app.MapGet("/", () => "API Hospital rodando 🚀");

app.Run();