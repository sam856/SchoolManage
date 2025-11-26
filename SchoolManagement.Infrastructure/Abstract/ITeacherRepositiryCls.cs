using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface ITeacherRepositiryCls : IGenericRepositoryAsync<Class>
    {
        public Task<string> DeActiveCls(int id);
        public Task<string> AssignStudentTocls(StudentClass studentClass);

        public Task<bool> IsTeacherOwnClass(int classId, int teacherId);

    }
}
