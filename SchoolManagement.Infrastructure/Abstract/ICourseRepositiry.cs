using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface ICourseRepositiry : IGenericRepositoryAsync<Course>
    {
        public Task<List<Course>> GetAllAsync();
        public Task<Course> GetByIdAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<bool> ISCodeExist(string name);
    }
}
