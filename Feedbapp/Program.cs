using Business;
using Dominio;
using Dominio.Accessors.Client;
using Dominio.Accessors.Email;
using Dominio.DTO;
using Feedbapp.Services;
using Microsoft.EntityFrameworkCore;

namespace Feedbapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddScoped<ISistema, Sistema>();
            builder.Services.AddScoped<IClientAccessor, ClientAccessor>();
            builder.Services.AddScoped<IEmailAccessor, EmailAccessor>();
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer("name=DefultConnection"));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default  HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();           

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
