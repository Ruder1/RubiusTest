using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Serilog.Configuration;
using Serilog;
using Serilog.Formatting;
using RubiusUI.Services.Logging;

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