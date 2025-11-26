using SchoolManagement.Data.Entities;
using SchoolManagment.Core.Feature.Course.Commands.Models;
using SchoolManagment.Core.Result;

namespace SchoolManagment.Core.Mapping.CourseMapping
{
    public partial class CourseProfile
    {

        public void AddCourseMapping()
        {
            CreateMap<CourseDto, Course>().ForPath(dest => dest.Department.Name, opt => opt.MapFrom(src => src.Departname)).ReverseMap();

            CreateMap<AddCourseCommand, Course>().ReverseMap();
            CreateMap<AddCourseCommand, CourseDto>().ReverseMap();

        }
    }
}
