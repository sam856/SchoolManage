using Microsoft.AspNetCore.Http;
using SchoolManagement.Data.Entities;

namespace SchoolManagment.Services.Abstract
{
    public interface IStudentServices
    {
        public Task<List<StudentClass>> GetClassBystudentId();
        public Task<List<Assignment>> GetStudentAssignmentsByStudentId();
        public Task<List<Attendence>> GetAttendenceByStudentId();
        public Task<List<Submission>> GetGradesByStudentId();

        public Task<string> SubmitAssignment(Submission submission, IFormFile formFile);
    }
}
