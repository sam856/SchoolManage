using Microsoft.AspNetCore.Identity;
using SchoolManagement.Data.Entities;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagment.Services.Abstract;

namespace SchoolManagment.Services.Implementation
{
    public class DepartmentServices : IDepartmentServices
    {
        #region Feilds
        private readonly IDepartmentRepositiry departmentRepositiry;
        private readonly UserManager<User> _userManager;

        #endregion


        #region Constractor
        public DepartmentServices(IDepartmentRepositiry departmentRepositiry, UserManager<User> _userManager)
        {
            this.departmentRepositiry = departmentRepositiry;
            this._userManager = _userManager;
        }


        #endregion


        #region Handle Function 
        public async Task<string> AddDepartment(Department department)
        {
            var ISSuccess = await departmentRepositiry.AddAsync(department);
            if (ISSuccess == null)
            {
                return " Faild To add";


            }
            else
                return "Success";

        }

        public async Task<string> DeleteById(int department)
        {
            var trans = departmentRepositiry.BeginTransaction();

            var result = await departmentRepositiry.DeleteAsync(department);

            if (!result)
            {
                await trans.RollbackAsync();
                return "Not Found";
            }

            await trans.CommitAsync();
            return "Success";


        }
        public async Task<List<Department>> GetAll()
        {
            return await departmentRepositiry.GetAllAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await departmentRepositiry.GetByIdAsync(id);
        }

        public async Task<bool> ISNameExist(string name)
        {
            return await departmentRepositiry.ISNameExist(name);


        }

        public async Task<bool> IsTeacherAsync(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                return false;

            var roles = await _userManager.GetRolesAsync(user);

            return roles.Contains("Teacher");
        }

        public async Task<string> Update(Department department)
        {
            {
                var trans = departmentRepositiry.BeginTransaction();
                try
                {
                    await departmentRepositiry.UpdateAsync(department);
                    await trans.CommitAsync();
                    return "Success";
                }
                catch
                {
                    await trans.RollbackAsync();
                    return "Failed";

                }

            }
            #endregion
        }
    }
}
