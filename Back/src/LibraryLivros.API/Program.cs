using System.Text;
using AutoMapper;
using LibraryLivros.API.Middleware;
using LibraryLivros.Application.Helpers;
using LibraryLivros.Application.Interfaces;
using LibraryLivros.Application.Services;
using LibraryLivros.Domain.Repository;
using LibraryLivros.Infra.Context;
using LibraryLivros.Infra.Repository;
using LibraryLivros.Infra.Repository.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddDbContext<LibraryLivrosContext>(context => context.UseSqlite(connectionString));

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new LivroProfile());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);




//scopeds
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<ApiKeyMiddleware>();


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseEndpoints(endpoints =>
    endpoints.MapControllers()
);

app.Run();
