using SchoolManagment.Core.Feature.Teacher.Command.Models;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {

        public void MarkAttendenceCommandMap()
        {
            CreateMap<SchoolManagement.Data.Entities.Attendence, MarkAttendenceModel>().ReverseMap();
        }
    }
}
