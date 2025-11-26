using SchoolManagment.Core.Feature.Teacher.Command.Models;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {

        public void AssignStudentToClsCommandMap()
        {
            CreateMap<SchoolManagement.Data.Entities.StudentClass, AssignStudentToClsCommandModel>().ReverseMap();
        }
    }
}
