using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class CourseRepositiry : GenericRepositoryAsync<Course>, ICourseRepositiry
    {
        #region Feilds
        private readonly DbSet<Course> _dbSet;
        #endregion
        #region Constractor


        #endregion



        #region Constractor

        public CourseRepositiry(ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<Course>();

        }
        #endregion



        #region Handle Functions    

        public async Task<bool> DeleteAsync(int id)
        {
            var course = await _dbSet.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
            if (course == null)
            {
                return false;
            }
            else
            {
                course.IsDeleted = true;

                await UpdateAsync(course);
                await SaveChangesAsync();

                return true;
            }
        }

        public async Task<List<Course>> GetAllAsync()
        {
            return await _dbSet
                                 .Include(d => d.Department)
                                 .Include(C => C.Class)
                                 .Where(c => !c.IsDeleted && !c.Department.IsDeleted)
                                  .ToListAsync();

        }

        public Task<bool> ISCodeExist(string code)
        {


            return _dbSet.AnyAsync(c => c.Name == code && !c.IsDeleted);
        }


        public async Task<Course> GetByIdAsync(int id)
        {


            var course = await _dbSet
                         .Include(d => d.Department)
                         .Include(C => C.Class)
                         .Where(c => !c.IsDeleted && !c.Department.IsDeleted)
                         .FirstOrDefaultAsync(d => d.Id == id);

            if (course == null)

            {
                return null;
            }

            return course;


        }

        #endregion

    }
}
