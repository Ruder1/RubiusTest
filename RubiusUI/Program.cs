using Microsoft.AspNetCore.Builder;

namespace RubiusUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// ��������� ��������� ������������, ������� ������������� � �������
			app.MapControllerRoute(
				name: "Account",
				pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

			// ��������� ��������� ��� ������������, ������� ������������� ��� �������
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
    }
}