using DataAccess;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<MaterialTypeRepo>(sp => new MaterialTypeRepo(builder.Configuration["sqlServer"]));
builder.Services.AddScoped<PackagedUnitRepo>(sp => new PackagedUnitRepo(builder.Configuration["sqlServer"]));
builder.Services.AddScoped<PackagingRepo>(sp => new PackagingRepo(builder.Configuration["sqlServer"]));
builder.Services.AddScoped<SpecificTypeRepo>(sp => new SpecificTypeRepo(builder.Configuration["sqlServer"]));

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
