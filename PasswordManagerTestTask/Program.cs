using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseInMemoryDatabase("PasswordRecords"));

var app = builder.Build();

app.Run();
