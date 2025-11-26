using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.InfrastrutureBases;
using SchoolManagment.Services.Abstract;
using SchoolManagment.Services.Abstract.AuthServices;
using SchoolManagment.Services.Implementation;
using SchoolManagment.Services.Implementation.AuthServices;

namespace SchoolManagment.Services
{
    public static class ModuleServicesBuilder
    {
        public static IServiceCollection AddServicesBuilder(
        this IServiceCollection services)
        {


            services.AddTransient<IAuthenticationServices, AuthenticationServices>();

            services.AddTransient<ICurrentUserServices, CurrentUserServices>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();

            services.AddTransient<ICourseServices, CourseServices>();

            services.AddTransient<IRegesiterServices, RegesiterServices>();


            services.AddTransient<IStudentServices, StudentServices>();
            services.AddTransient<IFileServices, FileServices>();
            services.AddTransient<ITeacherSevice, TeacherServices>();






            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));

            return services;

        }
    }
}


