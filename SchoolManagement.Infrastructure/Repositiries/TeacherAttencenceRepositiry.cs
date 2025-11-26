using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class TeacherAttencenceRepositiry : GenericRepositoryAsync<Attendence>, ITeacherAttendence
    {
        #region Fields
        private readonly DbSet<Attendence> _dbSet;
        #endregion


        #region Constructor
        public TeacherAttencenceRepositiry(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbSet = dbContext.Set<Attendence>();
        }

        #endregion
        #region Handle Functions
        public async Task<List<Attendence>> GetAttendenceByClassId(int classId)
        {
            return await _dbSet.Where(a => a.ClassId == classId && a.Class.IsActive).ToListAsync();
        }
        #endregion
    }
}
