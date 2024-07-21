using Application.Interfaces;
using Application.Mappers.Profiles;
using Application.Services;
using Domain.Contexts;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Presentation
{
    public static class DI
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<AppDbContext>(op => op.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            return services;
        }

        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<ICourseService, CourseService>();

            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CommonProfile));

            return services;
        }

        public static async void AddAdmin(this WebApplication app)
        {
            var container = app.Services.CreateScope();
            var userManager = container.ServiceProvider.GetRequiredService<UserManager<User>>();


            var user = await userManager.FindByEmailAsync("admin@admin.com");
            if (user is null)
            {
                user = new User
                {
                    Firstname = "admin",
                    Lastname = "admin",
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, "Admin_2924");
            }
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(op =>
            {
                op.Password.RequiredLength = 8;
                op.Password.RequireNonAlphanumeric = false;
                op.Lockout.AllowedForNewUsers = true;
                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                op.Lockout.MaxFailedAccessAttempts = 5;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            return services;
        }
    }
}
