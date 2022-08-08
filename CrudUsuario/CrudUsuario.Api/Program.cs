using AutoMapper;
using CrudUsuario.Api.ViewModels.UserViewModel;
using CrudUsuario.Domain.Entities;
using CrudUsuario.Domain.Validators;
using CrudUsuario.Infra.Contexts;
using CrudUsuario.Infra.Interfaces;
using CrudUsuario.Infra.Repositories;
using CrudUsuario.Services.DTOs;
using CrudUsuario.Services.Interfaces;
using CrudUsuario.Services.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region MySql
// var connectionString = "server=localhost;user=root;password=12345678;database=dbCrudUsuario";
// // Replace with your server version and type.
// // Use 'MariaDbServerVersion' for MariaDB.
// // Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// // For common usages, see pull request #1233.
// //var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
// var serverVersion = ServerVersion.AutoDetect(connectionString);
//
// // Replace 'YourDbContext' with the name of your own DbContext derived class.
// builder.Services.AddDbContext<dbCrudUsuarioContext>(
//     dbContextOptions => dbContextOptions
//         .UseMySql(connectionString, serverVersion)
//         // The following three options help with debugging, but should
//         // be changed or removed for production.
//         .LogTo(Console.WriteLine, LogLevel.Information)
//         .EnableSensitiveDataLogging()
//         .EnableDetailedErrors()
// );


#endregion

#region Mapper

var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<User, UserDTO>().ReverseMap();
    cfg.CreateMap<User, GetUserDTO>().ReverseMap();
    cfg.CreateMap<User, UpdatedUserDTO>().ReverseMap();
    cfg.CreateMap<CreateUserViewModel, UserDTO>().ReverseMap();
    cfg.CreateMap<UpdateUserViewModel, UserDTO>().ReverseMap();
    cfg.CreateMap<UpdateUserViewModel, UpdatedUserDTO>().ReverseMap();
});

builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

builder.Services.AddSingleton(d => builder.Configuration);
builder.Services.AddDbContext<dbCrudUsuarioContext>(options => options.UseMySql("server=localhost;port=3306;User Id=root;database=dbCrudUser;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();