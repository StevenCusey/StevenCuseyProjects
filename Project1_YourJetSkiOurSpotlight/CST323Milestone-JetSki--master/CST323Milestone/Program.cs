using CST323Milestone.Services.Business;
using CST323Milestone.Services.Data;
using CST323Milestone.Services.DataAccess;

namespace CST323Milestone
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Application Insights (Logging)
            builder.Services.AddApplicationInsightsTelemetry();
            builder.Logging.AddApplicationInsights();



            //Add services
            builder.Services.AddSingleton<SecurityService>();
            builder.Services.AddSingleton<SecurityDAO>();
            builder.Services.AddSingleton<UserData>();

            builder.Services.AddSingleton<JetSkiService>();
            builder.Services.AddSingleton<JetSkiDAO>();
            builder.Services.AddSingleton<JetSkiData>();




            // Add services to the container.
            builder.Services.AddControllersWithViews();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");

			}



			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
