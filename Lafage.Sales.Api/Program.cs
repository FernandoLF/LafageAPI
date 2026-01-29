using FluentValidation;
using FluentValidation.AspNetCore;
using Lafage.Sales.Application.Services;
using Lafage.Sales.Application.Validators;
using Lafage.Sales.Domain.Interfaces;
using Lafage.Sales.Infrastructure.Data;
using Lafage.Sales.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddDbContext<LafageDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<PersonaDtoValidator>();
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<PersonaService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<IAsesorComercialRepository, AsesorComercialRepository>();
builder.Services.AddScoped<AsesorComercialService>();
builder.Services.AddScoped<ILineaProductoRepository, LineaProductoRepository>();
builder.Services.AddScoped<LineaProductoService>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<PedidoService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
