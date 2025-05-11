using Microsoft.EntityFrameworkCore;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Models;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Implementations;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Repositories.Interfaces;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.Interfaces;
using AutoMapper;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Mappings;
using altsystems.transporte.Api.ERP_TransporteCargas_API.Services.altsystems.transporte.Api.ERP_TransporteCargas_API.Services;




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

// Verificar se a ConnectionString está presente
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A string de conexão 'DefaultConnection' não foi encontrada.");
}

// Adicionando DbContext para SQL Server
builder.Services.AddDbContext<ERPContext>(options =>
    options.UseSqlServer(connectionString));

// Configuração da autenticação JWT (depois do builder estar criado)
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


// Adicionando respositórios
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ICargaRepository, CargaRepository>();
builder.Services.AddScoped<ITransportadoraRepository, TransportadoraRepository>();
builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddScoped<IContatoRepository, ContatoRepository>();
builder.Services.AddScoped<IDadosGeraisRepository, DadosGeraisRepository>();
builder.Services.AddScoped<IClienteCnpjRepository, ClienteCnpjRepository>();
builder.Services.AddScoped<IClienteCnpjService, ClienteCnpjService>();
builder.Services.AddScoped<IInscricaoEstadualRepository, InscricaoEstadualRepository>();
builder.Services.AddScoped<IInscricaoEstadualService, InscricaoEstadualService>();


// Adicionando o serviços
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<CargaService>();
builder.Services.AddScoped<TransportadoraService>();
builder.Services.AddScoped<VeiculoService>();
builder.Services.AddScoped<IEnderecoService, EnderecoService>();
builder.Services.AddScoped<IContatoService, ContatoService>();
builder.Services.AddScoped<IDadosGeraisService, DadosGeraisService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));





builder.Services.AddControllers();

// Adicionando Swagger para documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();



// Configuração do Swagger para visualizar a documentação da API
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configuração do pipeline de requisições HTTP
app.UseHttpsRedirection();

app.UseRouting();

// Usar CORS
app.UseCors("AllowReact");  // Aplica o CORS com a política configurada

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
