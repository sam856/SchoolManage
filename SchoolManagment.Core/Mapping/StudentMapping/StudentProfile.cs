using AutoMapper;

namespace SchoolManagment.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            AddSummssionCommandMap();
            GradeMapping();
            GetAttendence();
            GetAssigment();
            GetClass();
        }
    }
}
