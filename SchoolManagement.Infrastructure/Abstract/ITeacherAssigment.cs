using SchoolManagement.Data.Entities;
using SchoolManagement.Infrastructure.InfrastrutureBases;

namespace SchoolManagement.Infrastructure.Abstract
{
    public interface ITeacherAssigment : IGenericRepositoryAsync<Assignment>
    {
        public Task<Assignment> GetAssigmentByClassId(int classId);
        public Task<string> PosTGrade(Submission sumssion);

        public Task<Assignment> GetAssigment(int id);

    }
}
