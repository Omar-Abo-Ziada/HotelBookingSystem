using Microsoft.AspNetCore.Authentication.Cookies;

namespace HotelBookingSystem.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //.AddCookie(options =>
            //{
            //    options.Cookie.Name = "Hotel.Cookie";
            //    options.Cookie.HttpOnly = true;
            //    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Adjust as needed
            //    options.LoginPath = "/Account/Login"; 
            //    options.AccessDeniedPath = "/Account/AccessDenied"; 
            //    options.SlidingExpiration = true;
            //});

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //*************************************************

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            builder.Services.AddHttpClient();
          
            //*************************************************

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}