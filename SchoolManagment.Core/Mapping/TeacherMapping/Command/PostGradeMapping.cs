using SchoolManagment.Core.Feature.Teacher.Command.Models;


namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {
        public void PostGrade()
        {
            CreateMap<PostGradeModel, SchoolManagement.Data.Entities.Submission>().ReverseMap();

        }
    }
}
