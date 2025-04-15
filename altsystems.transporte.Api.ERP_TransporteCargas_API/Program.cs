using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;

var builder = WebApplication.CreateBuilder(args);

// Verificar se a ConnectionString est� presente
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conex�o 'DefaultConnection' n�o foi encontrada.");
}

// Adicionando DbContext para SQL Server
builder.Services.AddDbContext<ERPContext>(options =>
    options.UseSqlServer(connectionString));

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
app.UseAuthentication();

app.MapControllers();

app.Run();
