using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface ITeacherAttendence : IGenericRepositoryAsync<Attendence>
    {
        public Task<List<Attendence>> GetAttendenceByClassId(int classId);
    }
}
