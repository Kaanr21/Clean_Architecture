using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Persistance.AutoMapper;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Services;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReferance).Assembly);

var connString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddMediatR(cfr =>
{
    cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyRegister).Assembly);
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitecture.Application.AssemblyRegister).Assembly);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connString));

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ICustomMapper, CustomMapper>();
builder.Services.AddScoped<ICarService, CarService>();

//Serilog Configurations
SerilogConfig.Configure();
builder.Host.UseSerilog();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
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
