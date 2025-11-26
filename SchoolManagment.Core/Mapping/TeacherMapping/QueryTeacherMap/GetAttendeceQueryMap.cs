using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.TeacherMapping
{
    public partial class TeacherProfile
    {

        public void GetAttendeceQueryMap()
        {
            CreateMap<TeacherAttendenceDto, SchoolManagement.Data.Entities.Attendence>()


                        .ForPath(src => src.Class.Name, opt => opt.MapFrom(dest => dest.ClassName))
                       .ForPath(src => src.Student.FullName, opt => opt.MapFrom(dest => dest.StudentName))
 .ForMember(dest => dest.Status,
                   opt => opt.MapFrom(src => Enum.Parse<AttendenceStatus>(src.Status)))


               .ReverseMap();
        }
    }
}
