using AutoMapper;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            PostGrade();
            AddClassCommandmap();
            UpdateClassMap();
            CreateNewAssigmentCommandMap();
            AssignStudentToClsCommandMap();
            GetAttendeceQueryMap();
            GetAssigmentQueryMap();
            MarkAttendenceCommandMap();

        }
    }
}
