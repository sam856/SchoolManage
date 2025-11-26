using SchoolManagement.Data.Entities;

namespace SchoolManagment.Services.Abstract
{
    public interface ICourseServices
    {
        public Task<List<Course>> GetAllAsync();
        public Task<Course> GetByIdAsync(int id);
        public Task<string> DeleteAsync(int id);
        public Task<bool> ISCodeExist(string name);
        public Task<string> UpdateAsync(Course course);
        public Task<string> AddAsync(Course course);



    }
}
