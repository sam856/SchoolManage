using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class TeacherAssigment : GenericRepositoryAsync<Assignment>, ITeacherAssigment
    {
        #region  Fields
        public readonly DbSet<Assignment> _dbSet;
        public readonly DbSet<Submission> _context;


        #endregion



        #region Constractor
        public TeacherAssigment(ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<Assignment>();
            _context = context.Set<Submission>();
        }



        #endregion


        #region Handle Function


        public async Task<Assignment> GetAssigmentByClassId(int classId)
        {
            return await _dbSet.FirstOrDefaultAsync(a => a.ClassId == classId && a.Class.IsActive);
        }


        public async Task<Assignment> GetAssigment(int id)
        {
            return await _dbSet.Include(a => a.Class).FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }

        public async Task<string> PosTGrade(Submission submission)
        {
            // نجيب الـ submission الصحيح من DB
            var sub = await _context
                .FirstOrDefaultAsync(s => s.AssignmentId == submission.AssignmentId
                                       && s.StudentId == submission.StudentId);

            if (sub == null)
            {
                return "Submission not found.";
            }

            sub.Grade = submission.Grade;
            sub.Remarks = submission.Remarks;
            sub.GradeByTeacher = submission.GradeByTeacher;
            _context.Update(sub);
            await SaveChangesAsync();

            return "Grade posted successfully.";
        }

        #endregion

    }
}
