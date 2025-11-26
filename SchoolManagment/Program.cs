
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagement.Infrastructure;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.DataSeeder;
using SchoolManagment.Core;
using SchoolManagment.Core.MiddleWare;
using SchoolManagment.Services;
using Serilog;


namespace SchoolManagment
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCoreDependenices()
                .AddServicesRegestration(builder.Configuration)
                .AddInfrastrucureDependiences()
                .AddServicesBuilder();


            builder.Services.AddSerilog();


            #region AllowCORS
            var CORS = "_cors";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: CORS,
                                  policy =>
                                  {
                                      policy.AllowAnyHeader();
                                      policy.AllowAnyMethod();
                                      policy.AllowAnyOrigin();
                                  });
            });

            #endregion

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
  option.UseSqlServer(builder.Configuration.GetConnectionString("dbcontext"))


  );

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                await RoleSeeder.SeedingUser(roleManager);


            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseHttpsRedirection();
            app.UseCors(CORS);
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
