using Microsoft.EntityFrameworkCore;
using programacion2proyecto.Application.Models;
using programacion2proyecto.Application.Services;
using programacion2proyecto.Infraestructure.Contex;
using programacion2proyecto.Infraestructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<EntregaRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<UnitOfwork>();

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<EntregaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
}, typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();// adding something
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
