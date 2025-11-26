using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetAttendence()
        {
            CreateMap<GetAttendeceDto, Attendence>()
                        .ForPath(src => src.Class.Name, opt => opt.MapFrom(dest => dest.ClassName))

                        .ForPath(src => src.teacher.FullName, opt => opt.MapFrom(dest => dest.TeacherName))
              .ForMember(dest => dest.Status,
                   opt => opt.MapFrom(src => Enum.Parse<AttendenceStatus>(src.Status)))
                        .ReverseMap();


        }
    }
}
