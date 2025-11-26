using SchoolManagement.Data.Entities;

namespace SchoolManagment.Services.Abstract
{
    public interface ITeacherSevice
    {
        public Task<string> PosTGrade(Submission sumssion);
        public Task<Assignment> GetAssigmentByClassId(int classId);
        public Task<string> AddAssigment(Assignment assignment);
        public Task<List<Attendence>> GetAttendenceByClassId(int classId);

        public Task<string> AddAttendence(Attendence attendence);

        public Task<string> DeActiveCls(int id);
        public Task<string> AssignStudentTocls(StudentClass studentClass);
        public Task<string> CreateClass(Class cls);
        public Task<string> UpdateCls(Class cls);

    }
}
