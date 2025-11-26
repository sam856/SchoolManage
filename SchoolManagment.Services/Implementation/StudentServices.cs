using Microsoft.AspNetCore.Http;
using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.Abstract;
using SchoolManagment.Services.Abstract;
using SchoolManagment.Services.Abstract.AuthServices;

namespace SchoolManagment.Services.Implementation
{
    public class StudentServices : IStudentServices
    {
        #region Fields 
        private readonly IStudentRepositiry studentRepositiry;

        private readonly ICurrentUserServices currentUserServices;
        private readonly IFileServices fileServices;

        #endregion

        #region Constractor
        public StudentServices(IStudentRepositiry studentRepositiry, ICurrentUserServices currentUserServices, IFileServices fileServices)
        {
            this.studentRepositiry = studentRepositiry;
            this.currentUserServices = currentUserServices;
            this.fileServices = fileServices;
        }
        #endregion

        #region Handle Functions



        public async Task<List<Attendence>> GetAttendenceByStudentId()
        {
            var student = currentUserServices.GetUserId();
            var attendence = await studentRepositiry.GetAttendenceByStudentId(student);
            return attendence;


        }

        public async Task<List<Assignment>> GetStudentAssignmentsByStudentId()
        {
            var student = currentUserServices.GetUserId();
            return await studentRepositiry.GetStudentAssignmentsByStudentId(student);
        }

        public async Task<List<StudentClass>> GetClassBystudentId()
        {
            var student = currentUserServices.GetUserId();
            return await studentRepositiry.GetClassBystudentId(student);
        }

        public Task<List<Submission>> GetGradesByStudentId()
        {
            var student = currentUserServices.GetUserId();
            return studentRepositiry.GetGradesByStudentId(student);
        }

        public async Task<string> SubmitAssignment(Submission submission, IFormFile formFile)
        {
            var student = currentUserServices.GetUserId();
            var uploadresult = await fileServices.UploadFile("assignments", formFile);
            switch (uploadresult)
            {
                case "CaanotUploadFile":
                    return ("Canot  Upload File");
                case "File Not Found": return "no file uploaded ";

            }

            submission.FileUrl = uploadresult;
            submission.StudentId = student;
            var result = await studentRepositiry.SubmitAssignment(submission);
            return result;



        }
        #endregion

    }
}
