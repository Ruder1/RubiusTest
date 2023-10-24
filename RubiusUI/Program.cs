using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Serilog.Configuration;
using Serilog;
using Serilog.Formatting;
using RubiusUI.Services.Logging;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repository;
using BuisnessLogicLayer.Services;
using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace RubiusUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Rubius API",
                    Description = "An ASP.NET Core Web API for managing Rubius items"
                });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Logging.AddSerilog(new LoggerConfig().Logger());

            builder.Services.AddTransient<IUserService, UserService>();            
            builder.Services.AddTransient<IFilterService, FilterService>();
            builder.Services.AddTransient<IPaginationService, PaginationService>();

            builder.Services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            builder.Services.AddTransient<IRepository<User>,UserRepository>();
            builder.Services.AddTransient<IRepository<Division>,DivisionRepository>();

            var connection = builder.Configuration.GetConnectionString("RubiusTest");
            builder.Services.AddDbContext<UserContext>
            (options =>
            options.UseNpgsql(connection, b => b.MigrationsAssembly("DataAccessLayer")));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.MapControllers();


            app.Run();
		}
    }
}