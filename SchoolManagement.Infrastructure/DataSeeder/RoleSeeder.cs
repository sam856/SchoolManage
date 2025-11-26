using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities.Identiy;

namespace SchoolManagement.Infrastructure.DataSeeder
{






    public static class RoleSeeder
    {
        public static async Task SeedingUser(RoleManager<Role> userManager)

        {

            var Count = await userManager.Roles.CountAsync();
            if (Count == 0)
            {
                var defualtuserAdmin = new Role
                {
                    Name = "Admin"



                };

                var defualtuserTeacher = new Role
                {
                    Name = "Teacher"



                };


                var defualtuserRoleStudent = new Role
                {
                    Name = "Student"



                };
                await userManager.CreateAsync(defualtuserRoleStudent);
                await userManager.CreateAsync(defualtuserAdmin);
                await userManager.CreateAsync(defualtuserTeacher);
            }



        }
    }
}


