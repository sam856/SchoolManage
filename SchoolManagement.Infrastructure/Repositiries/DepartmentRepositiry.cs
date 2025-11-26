using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class DepartmentRepositiry : GenericRepositoryAsync<Department>, IDepartmentRepositiry
    {
        #region   Fields
        private readonly DbSet<Department> _dbSet;
        #endregion
        #region Constractor
        public DepartmentRepositiry(ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<Department>();

        }

        #endregion
        #region Methods 
        public async Task<bool> DeleteAsync(int id)
        {
            var department = await _dbSet.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (department == null)
            {
                return false;
            }

            department.IsDeleted = true;

            await UpdateAsync(department);
            await SaveChangesAsync();

            return true;
        }

        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbSet
                       .Include(d => d.HeadOfDepartment)
                       .Where(d => !d.IsDeleted)
                        .ToListAsync();
        }


        public async Task<Department> GetByIdAsync(int id)
        {
            var Departments = await _dbSet
                         .Include(d => d.HeadOfDepartment)
                         .Where(d => !d.IsDeleted)
                         .FirstOrDefaultAsync(d => d.Id == id);

            if (Departments == null)
            {
                return null;
            }
            return Departments;
        }

        public async Task<bool> ISNameExist(string name)
        {
            return await _dbSet.AnyAsync(d => d.Name == name && !d.IsDeleted);
        }


        #endregion
    }
}
