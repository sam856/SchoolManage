using SchoolManagment.Core.Feature.Teacher.Command.Models;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void CreateNewAssigmentCommandMap()
        {
            CreateMap<SchoolManagement.Data.Entities.Assignment, CreateNewAssigmentModel>().ReverseMap();
        }
    }
}
