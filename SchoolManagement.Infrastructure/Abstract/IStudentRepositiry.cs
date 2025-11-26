using SchoolManagement.Data.Entities;
using SchoolManagement.Data.Entities.Identiy;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface IStudentRepositiry : IGenericRepositoryAsync<User>
    {


        public Task<List<Attendence>> GetAttendenceByStudentId(int StudentId);
        public Task<List<Assignment>> GetStudentAssignmentsByStudentId(int StudentId);
        public Task<List<StudentClass>> GetClassBystudentId(int StudentId);
        public Task<List<Submission>> GetGradesByStudentId(int StudentId);

        public Task<string> SubmitAssignment(Submission submission);


    }
}
