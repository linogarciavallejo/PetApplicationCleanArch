using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PetApplication.Infrastructure;
using PetApplication.Domain;
using PetApplication.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Build Configuration
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("PetsDb");

// Add services to the container.
builder.Services.AddDbContext<PetContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<PetService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new() { Title = "PetApplication.API", Version = "v1" });
});

// Build application
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
