using SchoolManagment.Core.Feature.Teacher.Command.Models;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void AddClassCommandmap()
        {
            CreateMap<SchoolManagement.Data.Entities.Class, AddClassModel>().ReverseMap();

        }
    }
}
