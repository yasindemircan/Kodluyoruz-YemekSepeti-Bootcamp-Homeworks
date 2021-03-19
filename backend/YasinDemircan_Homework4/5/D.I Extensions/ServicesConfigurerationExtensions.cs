using System;
using Data.Repositories.Derived;
using Data.Repositories.Interface;
using Microsoft.Extensions.DependencyInjection;
using Services.Interface;
using Services.Services;

namespace D.I_Extensions
{
    public static class ServicesConfigurerationExtensions
    {
        public static void AddProjectRepositories(this IServiceCollection services){
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
        }
        public static void AddProjectServices(this IServiceCollection services){
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
        }
    }
}
