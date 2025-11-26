using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface IDepartmentRepositiry : IGenericRepositoryAsync<Department>
    {
        public Task<List<Department>> GetAllAsync();
        public Task<Department> GetByIdAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> ISNameExist(string name);

    }
}
