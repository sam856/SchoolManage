using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class TeacherRepositiryCls : GenericRepositoryAsync<Class>, ITeacherRepositiryCls
    {
        #region Feilds
        private readonly DbSet<Class> _dbSet;

        private readonly DbSet<StudentClass> _context;




        #endregion


        #region Constractor
        public TeacherRepositiryCls(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Class>();
            _context = dbContext.Set<StudentClass>();

        }


        #endregion


        #region Handle Function

        public async Task<string> AssignStudentTocls(StudentClass studentClass)
        {
            var exists = await _context
             .AnyAsync(sc => sc.ClassId == studentClass.ClassId && sc.StudentId == studentClass.StudentId);

            if (exists)
            {
                return "Student is already assigned to this class.";
            }


            try
            {
                await _context.AddAsync(studentClass);
                await _dbContext.SaveChangesAsync();

                return "Student assigned to class successfully.";

            }
            catch (DbUpdateException ex)
            {
                return $"Error assigning student to class: {ex.Message}";
            }




        }

        public async Task<string> DeActiveCls(int id)
        {
            var cls = _dbSet.Find(id);
            if (cls == null)
            {
                return ("Class not found.");
            }
            cls.IsActive = false;
            await UpdateAsync(cls);
            return ("Class deactivated successfully.");

        }

        public async Task<bool> IsTeacherOwnClass(int classId, int teacherId)
        {
            return await _dbSet
                    .AnyAsync(c => c.Id == classId && c.TeacherId == teacherId);
        }

        #endregion
    }
}
