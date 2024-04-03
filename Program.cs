using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using task1.Models;
using task1.Repositories;

namespace task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TraineeContext>(
                op => op.UseSqlServer(builder.Configuration.GetConnectionString("myConn"))
                );

            builder.Services.AddScoped<ITrackRepo,TrackServices>();
            builder.Services.AddScoped<IcourseRepo, CourseServices>();
            builder.Services.AddScoped<ITraineeRepo, TraineeServices>();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(
                op =>
                {
                    op.Password.RequireLowercase=true;
                    op.Password.RequiredLength = 10;
                    op.Password.RequireUppercase = true;
                    op.Password.RequiredUniqueChars=1;
                    op.Password.RequireDigit = true;
                })
                .AddEntityFrameworkStores<TraineeContext>();
          

            //builder.Services.AddAuthentication().AddFacebook(op =>
            //{
            //    op.ClientId = "411550991445126";
            //    op.ClientSecret = "1699aaf5e4cc1e6d01e3bc7f7064230e";
            //});

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
          

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
               name: "default2",
               pattern: "{controller=Course}/{action=GetListTwoOptions}/{selectedValue?}");
            app.Run();
        }
    }
}