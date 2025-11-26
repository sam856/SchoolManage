using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Repositiries;

namespace SchoolManagement.Infrastructure
{
    public static class ModuleInfrastrucureDependiences
    {
        public static IServiceCollection AddInfrastrucureDependiences(

            this IServiceCollection services)
        {
            services.AddScoped<IRefreshTokenRepositiry, RefreshTokenRepositiry>();
            services.AddScoped<IDepartmentRepositiry, DepartmentRepositiry>();
            services.AddScoped<ICourseRepositiry, CourseRepositiry>();
            services.AddScoped<IStudentRepositiry, StuentRepositiry>();
            services.AddScoped<ITeacherRepositiryCls, TeacherRepositiryCls>();
            services.AddScoped<ITeacherAttendence, TeacherAttencenceRepositiry>();
            services.AddScoped<ITeacherAssigment, TeacherAssigment>();






            return services;

        }


    }
}
