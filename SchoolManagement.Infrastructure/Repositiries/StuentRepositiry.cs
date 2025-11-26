using Microsoft.EntityFrameworkCore;
using SchoolManagement.Data.Entities;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagement.Infrastructure.Context;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Repositiries
{
    public class StuentRepositiry : GenericRepositoryAsync<User>, IStudentRepositiry
    {
        private readonly DbSet<Attendence> _dbSet;
        private readonly DbSet<Assignment> _context;
        private readonly DbSet<StudentClass> _classes;
        private readonly DbSet<Submission> _submissions;




        public StuentRepositiry(ApplicationDbContext context) : base(context)
        {
            _dbSet = context.Set<Attendence>();
            _context = context.Set<Assignment>();
            _classes = context.Set<StudentClass>();
            _submissions = context.Set<Submission>();
        }

        public async Task<List<Attendence>> GetAttendenceByStudentId(int StudentId)
        {
            var StudentAttendence = await _dbSet.Include(a => a.teacher).Include(a => a.Class).Where
             (a => a.StudentId == StudentId && !a.IsDeleted).ToListAsync();
            return StudentAttendence;

        }

        public async Task<List<StudentClass>> GetClassBystudentId(int StudentId)
        {
            return await _classes
                 .Where(sc => sc.StudentId == StudentId && sc.Class.IsActive)
                 .Include(sc => sc.Class)
                 .Include(sc => sc.Class.Course)
                 .ToListAsync();

        }

        public async Task<List<Submission>> GetGradesByStudentId(int StudentId)
        {

            return await _submissions.
                    Include(s => s.Assignment)
                .Include(s => s.GradeByTeacher)
                .Where(s => s.StudentId == StudentId && !s.IsDeleted)

                .ToListAsync();
        }

        public async Task<List<Assignment>> GetStudentAssignmentsByStudentId(int StudentId)
        {

            var classes = await GetClassBystudentId(StudentId);

            if (classes == null || !classes.Any())
                return new List<Assignment>();

            var classIds = classes.Select(c => c.ClassId).ToList();

            var assignments = await _context
                .Where(a => classIds.Contains(a.ClassId))
                .Include(a => a.CreatedByTeacher)
                .ToListAsync();

            return assignments;



        }



        public async Task<string> SubmitAssignment(Submission submission)
        {

            var result = await _submissions.AddAsync(submission);
            await SaveChangesAsync();

            if (result != null)
            {
                return "Submission Successful";
            }
            else
            {
                return "Submission Failed";
            }

        }
    }
}
