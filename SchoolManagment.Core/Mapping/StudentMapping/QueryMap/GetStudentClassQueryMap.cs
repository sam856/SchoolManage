using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {

        public void StudentClasses()
        {
            CreateMap<StudentClassesDto, StudentClass>()
                       .ForPath(src => src.Class.Name, opt => opt.MapFrom(dest => dest.ClassName))
                       .ForPath(src => src.Class.Course.Name, opt => opt.MapFrom(dest => dest.CourseName))
                       .ReverseMap();


        }
    }
}
