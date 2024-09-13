using GerenciaLivro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using GerenciaLivro.Application;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("GerenciaLivroCs");

builder.Services.AddDbContext<GerenciadorLivroDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddApplication();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
