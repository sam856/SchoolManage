using SchoolManagement.Data.Entities;

namespace SchoolManagment.Services.Abstract
{
    public interface IDepartmentServices
    {
        public Task<Department> GetById(int id);
        public Task<List<Department>> GetAll();

        public Task<string> DeleteById(int department);
        public Task<string> Update(Department department);
        public Task<string> AddDepartment(Department department);
        public Task<bool> IsTeacherAsync(int userId);

        public Task<bool> ISNameExist(string name);



    }
}
