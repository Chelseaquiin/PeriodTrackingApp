using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PeriodTracker.BLL.Implementation;
using PeriodTracker.BLL.Interfaces;
using PeriodTracker.DAL.Models;

namespace PeriodTrackerMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PeriodTrackerDbContext>(opts =>
            {
                var periodTracker = builder.Configuration.GetSection("ConnectionString")["PeriodTracker"];

                opts.UseSqlServer(periodTracker);

            });
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITrackerService, TrackerService>();

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tracker}/{action=GetNextPeriod}");

            app.Run();
        }
    }
}