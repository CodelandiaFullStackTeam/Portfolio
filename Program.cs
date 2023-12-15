using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.Areas.Admin.Models;
using Portfolio.Classes;
using Portfolio.Contexts;

namespace Portfolio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<PortfolioDbContext>();

            builder.Services.AddDbContext<PortfolioDbContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/Auth/Login");
                options.Cookie = new CookieBuilder
                {
                    Name = "PortfolioIdentityCookie",
                    HttpOnly = false,
                    SameSite = SameSiteMode.Lax,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(2);
            });

            builder.Services.AddAuthorization(options =>
            {
                options.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Test}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
                    );

                
            });

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<User>>();

                // Call a method to seed the default user (use async)
                SeedData.GenerateFirstUser(userManager).GetAwaiter().GetResult();
            }

            app.Run();
        }
    }
}