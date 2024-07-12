using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseInMemoryDatabase("PasswordManager"));
builder.Services.AddTransient<IRepository<PasswordRecord>, PasswordRecordRepository>();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapControllers();

app.Run();
