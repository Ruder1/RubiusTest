using Microsoft.AspNetCore.Builder;

namespace RubiusUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // добавляем поддержку контроллеров, которые располагаются в области
            app.MapControllerRoute(
				name: "Account",
				pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

			// добавляем поддержку для контроллеров, которые располагаются вне области
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
    }
}