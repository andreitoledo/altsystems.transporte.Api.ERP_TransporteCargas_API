using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)

// Adicionar suporte para CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // correto para React + Vite
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Verificar se a ConnectionString est� presente
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conex�o 'DefaultConnection' n�o foi encontrada.");
}

// Adicionando DbContext para SQL Server
builder.Services.AddDbContext<ERPContext>(options =>
    options.UseSqlServer(connectionString));

// Configura��o da autentica��o JWT (depois do builder estar criado)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

// Adicionando suporte a controllers e API
builder.Services.AddControllers();

// Adicionando Swagger para documenta��o da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configura��o do Swagger para visualizar a documenta��o da API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura��o do pipeline de requisi��es HTTP
app.UseHttpsRedirection();

app.UseRouting();

// Usar CORS
app.UseCors("AllowReact");  // Aplica o CORS com a pol�tica configurada

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
