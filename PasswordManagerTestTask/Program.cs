using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using Infrastructure.Database;
using Infrastructure.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseInMemoryDatabase("PasswordRecords"));
builder.Services.AddTransient<IRepository<PasswordRecord>, PasswordRecordRepository>();

var app = builder.Build();

app.Run();
