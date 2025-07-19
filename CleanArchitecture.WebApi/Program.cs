using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Interfaces.AutoMapper;
using CleanArchitecture.Application.Interfaces.Services;
using CleanArchitecture.Application.Interfaces.UnitOfWork;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Authentication;
using CleanArchitecture.Infrastructure.Services;
using CleanArchitecture.Persistance.AutoMapper;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Services;
using CleanArchitecture.WebApi.OptionsSetup;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.AddSingleton<IMailService, MailService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<ICustomMapper, CustomMapper>();
builder.Services.AddScoped<ICarService, CarService>();

//Serilog Configurations
SerilogConfig.Configure();
builder.Host.UseSerilog();


//JWT settings
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthentication();

builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                    { jwtSecuritySheme, Array.Empty<string>() }
    });
});
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
